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
    /// 
    /// </summary>
    public interface IGammaCorrector
    {
        /// <summary>
        /// Prepare a lookup table for red
        /// </summary>
        /// <returns>Result must be a uint[256] array</returns>
        byte[] GetLookupTableRed();

        /// <summary>
        /// Prepare a lookup table for green
        /// </summary>
        /// <returns>result must be a uint[256] array</returns>
        byte[] GetLookupTableGreen();

        /// <summary>
        /// Prepare a lookup table for blue
        /// </summary>
        /// <returns>result must be a uint[256] array</returns>
        byte[] GetLookupTableBlue();
    }
}
