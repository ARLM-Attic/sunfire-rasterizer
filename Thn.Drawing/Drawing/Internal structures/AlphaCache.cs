#region (c) 2014 THN Solutions LLC. - All rights reserved
/*
SUNFIRE VECTOR GRAPHIC ENGINE's RASTERIZER LIBRARY version 2

Copyright (c) 2014, THN Solutions LLC. ( www.ThnSolutions.com )
Author: Nguyễn, M. Hải                 ( www.Minh-Hai.com     )
All rights reserved.

This library is dual-licensed.
  + For commercial software, please obtain a commercial license from THN Solutions LLC.
    Our optimized-for-commercial product is available at www.SunFireEngine.com

  + For free software, this library is licensed under GPL version 3. A summary of GPLv3 is
    listed below. You should also find a copy of GPLv3 as file License_GPLv3.txt included
	with the source-code files.

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License version 3 as published by
    the Free Software Foundation  of the License.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
#endregion

#region Using directives
using System;
#endregion

namespace Thn.Drawing
{
    /// <summary>
    /// Cache of alpha values for alpha blending
    /// </summary>
    internal class AlphaCache
    {
        #region Cache
        private uint[] mCache;
        /// <summary>
        /// Gets alpha cache
        /// </summary>
        public static uint[] Cache
        {
            get { return Instance.mCache; }
        }
        #endregion

        #region Instance
        /// <summary>
		/// Static variable for thread locking
		/// </summary>
		static object SyncRoot = new object();
		
		/// <summary>
		/// Actual static variable for Instance
		/// </summary>
		static AlphaCache mInstance = null;
		
		/// <summary>
		/// Gets the static instance of this class
		/// </summary>
		static AlphaCache Instance
		{
			get
			{
				if (mInstance == null)
				{
					//initialize new instance
					AlphaCache tmp = new AlphaCache();
					
					//assign to static variable. Lock root for thread-safe locking
					lock (SyncRoot)
					{
						mInstance = tmp;
					}
				}

				return mInstance;
			}
		}
		#endregion
        
        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        AlphaCache()
        {
            mCache = new uint[256 * 256];
            for (int alpha = 0; alpha < 256; alpha++)
            {
                for (int beta = 0; beta < 256; beta++)
                {
                    int alphaIdx = alpha * 256 + beta;

                    // OLD CODE of HaiNM
                    //mCache[alphaIdx] = (uint)((alpha + beta) - ((beta * alpha + 255) >> 8));

                    //HUYHM CHANGE 26 Aug 2008
                    // all code using Alpha Cache will shift value to left 24,so this cache need to pre-built including shifting
                    mCache[alphaIdx] = (uint)((alpha + beta) - ((beta * alpha + 255) >> 8)) << 24;
                }
            }
        }
        #endregion
    }
}
