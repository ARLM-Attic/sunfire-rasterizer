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
    /// Contains information for a single stop in a <see cref="ColorRamp"/>
    /// </summary>
    public class ColorStop
    {
        /// <summary>
        /// Gets/Sets the color for this stop
        /// </summary>
        public Color Color = Colors.Transparent;

        #region Stop
        /// <summary>
        /// HuyHM change to internal field
        /// This internal use for better performance
        /// </summary>
        internal double mStop = 0;
        /// <summary>
        /// Gets/Sets stop value (must be within range [0..1] )
        /// </summary>
        public double Stop
        {
            get { return mStop; }
            set
            {
                if (mStop != value)
                {
                    mStop = value;
                    if (mStop < 0) mStop = 0;
                    else if (mStop > 1) mStop = 1;
                }
            }
        }
        #endregion

        #region To String
        /// <summary>
        /// Converts to display text
        /// </summary>
        public override string ToString()
        {
            return string.Format("Stop: {0} - Color: {1}", mStop, Color);
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public ColorStop()
        { }

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="color">Color value of stop</param>
        /// <param name="stop">Position of stop (must be in range [0..1]</param>
        public ColorStop(Color color, double stop)
        {
            this.Color = color;
            if (stop < 0) mStop = 0;
            else if (stop > 1) mStop = 1;
            else this.mStop = stop;
        }
        #endregion
    }
}
