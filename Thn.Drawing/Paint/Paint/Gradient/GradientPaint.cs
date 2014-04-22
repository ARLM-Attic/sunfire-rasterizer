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
    /// Gradient paint supports gradient colors for fill and stroke
    /// </summary>
    public abstract class GradientPaint : Paint
    {
        /// <summary>
        /// Gets/Sets the gradient's repeat mode
        /// </summary>
        public GradientStyle Style = GradientStyle.Reflect;

        /// <summary>
        /// Gets/Sets the color ramp used for gradient interpolation
        /// </summary>
        public ColorRamp Ramp = null;

        //#region Ramp
        //ColorRamp mRamp;
        ///// <summary>
        ///// Gets/Sets Ramp
        ///// </summary>
        //public ColorRamp Ramp
        //{
        //    get { return mRamp; }
        //    set { mRamp = value; }
        //}
        //#endregion

        #region GetLinearColors
        /// <summary>
        /// Get linear colors
        /// </summary>
        /// <param name="opacity">apacity of paint (value in range 0-256)</param>
        /// <returns>512 element array of colors. When ramp is not set, array include 512 zero element</returns>
        internal uint[] GetLinearColors(uint opacity)
        {
            if (this.Ramp != null)
            {
                return this.Ramp.Build(Style, opacity);
            }
            return ColorRamp.EmptyColors;
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public GradientPaint()
        {
            this.Ramp = new ColorRamp();
        }
        #endregion
    }
}
