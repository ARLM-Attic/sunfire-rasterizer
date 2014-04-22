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
    /// Structure to saving cell data, coverage,area
    /// This in linked-list of RowData structure
    /// </summary>
    public /*internal*/ class CellData
    {
        #region public fields
        /// <summary>
        /// X position of current cell
        /// </summary>
        public int X;

        /// <summary>
        /// Coverage value
        /// </summary>
        public int Coverage;

        /// <summary>
        /// Area value
        /// </summary>
        public int Area;
        #endregion

        #region linked list field
        /// <summary>
        /// Next cell in current row
        /// </summary>
        public CellData Next = null;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x">x position</param>
        public CellData(int x)
        {
            X = x;
        }
        /// <summary>
        /// Create cell data by using some values
        /// </summary>
        /// <param name="x">x coordinate</param>
        /// <param name="coverage">coverage value</param>
        /// <param name="area">area</param>
        public CellData(int x, int coverage, int area)
        {
            X = x;
            Coverage = coverage;
            Area = area;
        }
        #endregion
    }
}
