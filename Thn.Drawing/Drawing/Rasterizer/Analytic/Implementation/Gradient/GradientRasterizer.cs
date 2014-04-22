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

namespace Thn.Drawing.Rasterizers.Analytical
{
    /// <summary>
    /// Base class for gradient rasterizer.
    /// </summary>
    /// <remarks>
    /// </remarks>
    public /*internal*/ abstract class GradientRasterizer : TranformableRasterizer
    {

        #region Const

        #region DISTANCE SCALE

        /// <summary>
        /// Shift for distance. 
        /// 4
        /// </summary>
        public const int DistanceShift = 4;

        /// <summary>
        /// Scale for multiply distance. 
        /// 16
        /// </summary>
        public const int DistanceScale = 1 << DistanceShift;

        /// <summary>
        /// DistanceScale * DistanceScale 
        /// 256
        /// </summary>
        public const int DistanceScaleSquared = DistanceScale * DistanceScale;

        /// <summary>
        /// Using for modulo with distance scale. 
        /// 255
        /// </summary>
        public const int DistanceMask = DistanceScale - 1;

        #endregion


        #region Color index scale

        /// <summary>
        /// Using to convert from ratio distance to color index in 256 element array. 
        /// 8
        /// </summary>
        public const int ColorIndexShift = 8;

        /// <summary>
        /// Scale for color index shift.
        /// 256
        /// </summary>
        public const int ColorIndexScale = 1 << ColorIndexShift;

        /// <summary>
        /// Modulo when lookup to color ramp built color array (512 elements).
        /// 255
        /// </summary>
        public const int ColorIndexMask = ColorIndexScale - 1;

        /// <summary>
        /// Modulo when lookup to color ramp built color array (512 elements).
        /// When color gradient style is reflect or repeat.
        /// 512
        /// </summary>
        public const int ColorIndexDoubleScale = (ColorIndexScale * 2);

        /// <summary>
        /// Modulo when lookup to color ramp built color array ( 512 elements)
        /// When color gradient style is reflect or repeat. 
        /// 511
        /// </summary>
        public const int ColorIndexDoubleMask = (ColorIndexScale * 2) - 1;
        #endregion
       

        #region Color index increment scale

        /// <summary>
        /// Shift for increment of color index. 
        /// 8
        /// </summary>
        public const int IncrementColorIndexShift = 8;

        /// <summary>
        /// Scale value for increment of color index. 
        /// 256
        /// </summary>
        public const int IncrementColorIndexScale = 1 << IncrementColorIndexShift;

        /// <summary>
        /// Mask using for increment of color index. 
        /// 255
        /// </summary>
        public const int IncrementColorIndexMask = IncrementColorIndexScale - 1;

        /// <summary>
        /// Mask using for increment of color index. 
        /// 511
        /// </summary>
        public const int IncrementColorIndexDoubleMask = IncrementColorIndexScale * 2 - 1;

        #endregion


        #region Color index including increment scaled

        /// <summary>
        /// Using to convert from distance to color index  in array 256, but this
        /// has been scaled by color incrementScale.
        /// Equal (256 &lt;&lt; 8)
        /// </summary>
        public const int ColorIndexIncludeIncrementScale = (256 << IncrementColorIndexShift);

        /// <summary>
        /// Modulo const when get modulo of increment index.
        /// </summary>
        public const int ColorIndexIncludeIncrementDoubleScale = (ColorIndexIncludeIncrementScale * 2);

        /// <summary>
        /// Modulo const when get modulo of increment index.
        /// </summary>
        public const int ColorIndexIncludeIncrementDoubleMask = (ColorIndexIncludeIncrementScale * 2) - 1;
        
        #endregion

        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor for GradientRasterizer
        /// </summary>
        public GradientRasterizer()
        { }
        #endregion

        #region Apply Opacity
        /// <summary>
        /// Apply opacity
        /// </summary>
        /// <param name="rawColors">raw color array including 512 element</param>
        /// <param name="opacity">opacity</param>
        /// <returns>apply opacity</returns>
        protected uint[] ApplyOpacity(uint[] rawColors,uint opacity,GradientStyle gradientStyle)
        {        
            uint[] result = new uint[rawColors.Length];
            for (int i = 0; i < 256; i++)
            {
                
            }
            return result;
        }
        #endregion

    }
}
