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
    /// Radial gradient paint
    /// </summary>
    public class RadialGradient:GradientPaint
    {
        #region RadiusX
        /// <summary>
        /// Gets/Sets radius for horizontal
        /// </summary>
        public double RadiusX;
        #endregion

        #region RadiusY
        /// <summary>
        /// Gets/Sets radius for vertical
        /// </summary>
        public double RadiusY;
        #endregion  

        #region Radius
        /// <summary>
        /// Sets both RadiusX and RadiusY to the same value
        /// </summary>
        public double Radius
        {
            set
            {
                RadiusX = value;
                RadiusY = value;
            }
        }
        #endregion  

        #region CenterX
        /// <summary>
        /// Gets/Sets center point x
        /// </summary>
        public double CenterX;
        #endregion  

        #region CenterY
        /// <summary>
        /// Gets/Sets center point y value
        /// </summary>
        public double CenterY;
        #endregion  

        #region FocusX
        /// <summary>
        /// Gets/Sets x coordinate that the gradient focus to
        /// </summary>
        public double FocusX;
        #endregion  

        #region FocusY
        /// <summary>
        /// Gets/Sets y coordinate that the gradient focus to
        /// </summary>
        public double FocusY;
        #endregion  
    }
}
