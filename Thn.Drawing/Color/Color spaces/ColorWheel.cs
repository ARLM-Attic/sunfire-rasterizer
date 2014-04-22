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
    /// Represents a natural color wheel
    /// </summary>
    public class ColorWheel
    {
        /// <summary>
        /// Gets the Yellow color
        /// </summary>
        public static Color Yellow
        { get { return new Color(255, 255, 51); } }

        /// <summary>
        /// Gets the medium color of Yellow and Orange
        /// </summary>
        public static Color YellowOrange
        { get { return new Color(255, 204, 51); } }

        /// <summary>
        /// Gets the Orange color
        /// </summary>
        public static Color Orange
        { get { return new Color(255, 153, 51); } }

        /// <summary>
        /// Gets the medium color of Red and Orange
        /// </summary>
        public static Color RedOrange
        { get { return new Color(255, 102, 51); } }

        /// <summary>
        /// Gets the Red color
        /// </summary>
        public static Color Red
        { get { return new Color(255, 51, 51); } }

        /// <summary>
        /// Gets the medium color of Red and Purple
        /// </summary>
        public static Color RedPurple
        { get { return new Color(204, 51, 102); } }

        /// <summary>
        /// Gets the Purple color
        /// </summary>
        public static Color Purple
        { get { return new Color(140); } }

        /// <summary>
        /// Gets the medium color of Blue and Purple
        /// </summary>
        public static Color BluePurple
        { get { return new Color(51, 51, 153); } }

        /// <summary>
        /// Gets the Blue color
        /// </summary>
        public static Color Blue
        { get { return new Color(51, 102, 204); } }

        /// <summary>
        /// Gets the medium color of Blue and Green
        /// </summary>
        public static Color BlueGreen
        { get { return new Color(51, 153, 153); } }

        /// <summary>
        /// Gets the Green color
        /// </summary>
        public static Color Green
        { get { return new Color(51, 153, 51); } }

        /// <summary>
        /// Gets the medium color of Yellow and Green
        /// </summary>
        public static Color YellowGreen
        { get { return new Color(153, 204, 51); } }
    }
}
