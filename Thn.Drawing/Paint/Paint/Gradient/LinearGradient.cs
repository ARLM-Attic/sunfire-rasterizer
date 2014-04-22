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
    /// Basic gradient, color in color ramp will fill from start to end point, and base on linear mode
    /// </summary>
    public class LinearGradient : GradientPaint
    {
        /// <summary>
        /// X-axis coordinate of starting point.
        /// <para>If value is [0..1], this value is interpreted as percentage</para>
        /// </summary>
        public double StartX;
        /// <summary>
        /// Y-axis coordinate of starting point.
        /// <para>If value is [0..1], this value is interpreted as percentage</para>
        /// </summary>
        public double StartY;
        /// <summary>
        /// X-axis coordinate of ending point.
        /// <para>If value is [0..1], this value is interpreted as percentage</para>
        /// </summary>
        public double EndX;
        /// <summary>
        /// Y-axis coordinate of ending point.
        /// <para>If value is [0..1], this value is interpreted as percentage</para>
        /// </summary>
        public double EndY;
        
        /// <summary>
        /// Linear mode
        /// </summary>
        public LinearGradientMode Mode = LinearGradientMode.ForwardDiagonal;

        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public LinearGradient()
        { }
        #endregion

        #region Horizontal Constructor
        ///// <summary>
        ///// Construct vertical linear gradient from start Y to end Y
        ///// </summary>
        ///// <param name="startY">start y</param>
        ///// <param name="endY">end y</param>
        ///// <param name="startColor">start color</param>
        ///// <param name="endColor">end color</param>
        //public LinearGradient(double startY, double endY, Color startColor, Color endColor)
        //{
        //    Mode = LinearGradientMode.Vertical;
        //    StartY = startY;
        //    EndY = endY;
        //    this.Ramp = new ColorRamp();
        //    this.Ramp.Add(startColor, 0.0);
        //    this.Ramp.Add(endColor, 0.0);
        //}

        ///// <summary>
        ///// Construct vertical linear gradient from start Y to end Y
        ///// </summary>
        ///// <param name="startY">start y</param>
        ///// <param name="endY">end y</param>
        ///// <param name="ramp">ramp</param>
        //public LinearGradient(double startY, double endY, ColorRamp ramp)
        //{
        //    Mode = LinearGradientMode.Vertical;
        //    Start = new Point(0, startY);
        //    End = new Point(0, endY);
        //    this.Ramp = ramp;
        //}
        #endregion
    }

    
}
