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
using System.IO;
#endregion

namespace DemoHelpers
{
    /// <summary>
    /// Helper class using for read complex.data file
    /// </summary>
    public class ComplexDataHelper
    {

        #region Helper
		/// <summary>
		/// Static variable for thread locking
		/// </summary>
		static object SyncRoot = new object();
		
		/// <summary>
		/// Actual static variable for Helper
		/// </summary>
		static ComplexDataHelper mInstance = null;
		
		/// <summary>
		/// Gets the static instance of this class
		/// </summary>
		static ComplexDataHelper Helper
		{
			get
			{
				if (mInstance == null)
				{
					//initialize new instance
					ComplexDataHelper tmp = new ComplexDataHelper();
					
					//assign to static variable. Lock root for thread-safe locking
					lock (SyncRoot)
					{
						mInstance = tmp;
					}
				}

				return mInstance;
			}
		}
		
		//private constructor
		ComplexDataHelper() { }
		#endregion


        double[] cachedPolygon = new double[0];
        System.Drawing.PointF[] cachedGdiPolygon = new System.Drawing.PointF[0];

        public static double[] GetComplexPolygon()
        {
            return Helper.cachedPolygon;
        }

        public static System.Drawing.PointF[] GetGdiComplexPolygon()
        {
            return Helper.cachedGdiPolygon;
        }

        public static void BuildCache(int complexDataId)
        {
            Helper.DoBuildCache(complexDataId);
        }

        void DoBuildCache(int complexDataId)
        {
            TextReader reader = null;
            try
            {
                reader = new StreamReader(string.Format("complex{0}.data", complexDataId));
                string extraString = reader.ReadToEnd();
                extraString=extraString.Replace('\n', ',');
                extraString = extraString.Replace(' ', ',');
                //extraString = extraString.Replace('', ',');
                string[] pos = extraString.Split(',');
                int needPosition = (pos.Length / 2 )* 2;
                cachedGdiPolygon = new System.Drawing.PointF[needPosition / 2];
                cachedPolygon = new double[needPosition];
                for (int i = 0; i < needPosition; i += 2)
                {
                    cachedPolygon[i] = double.Parse(pos[i], System.Globalization.CultureInfo.InvariantCulture);
                    cachedPolygon[i + 1] = double.Parse(pos[i + 1], System.Globalization.CultureInfo.InvariantCulture);
                    cachedGdiPolygon[i / 2] = new System.Drawing.PointF((float)cachedPolygon[i], (float)cachedPolygon[i + 1]);
                }
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
            
        }
    }
}
