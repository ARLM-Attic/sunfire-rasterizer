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

namespace Thn.Drawing.ColorSpaces
{
    /// <summary>
    /// A helper class to convert colors
    /// </summary>
    public class ColorConverter
    {
        #region Hexa

        #region From Hexa
        /// <summary>
        /// Converts a hex string to color
        /// </summary>
        public static Color FromHexa(string hexColor)
        {
            Color result = null;
            string r, g, b;

            if (hexColor != String.Empty)
            {
                hexColor = hexColor.Trim().ToUpper();
                if (hexColor[0] == '#') hexColor = hexColor.Substring(1, hexColor.Length - 1);

                r = hexColor.Substring(0, 2);
                g = hexColor.Substring(2, 2);
                b = hexColor.Substring(4, 2);

                r = Convert.ToString(16 * GetIntFromHex(r.Substring(0, 1)) + GetIntFromHex(r.Substring(1, 1)));
                g = Convert.ToString(16 * GetIntFromHex(g.Substring(0, 1)) + GetIntFromHex(g.Substring(1, 1)));
                b = Convert.ToString(16 * GetIntFromHex(b.Substring(0, 1)) + GetIntFromHex(b.Substring(1, 1)));

                result = Color.Create(Convert.ToInt32(r), Convert.ToInt32(g), Convert.ToInt32(b));
            }
            else result = Colors.Transparent;

            return result;
        }

        /// <summary>
        /// Gets the int equivalent for a hexadecimal value.
        /// </summary>
        private static int GetIntFromHex(string strHex)
        {
            switch (strHex)
            {
                case ("A"):
                    {
                        return 10;
                    }
                case ("B"):
                    {
                        return 11;
                    }
                case ("C"):
                    {
                        return 12;
                    }
                case ("D"):
                    {
                        return 13;
                    }
                case ("E"):
                    {
                        return 14;
                    }
                case ("F"):
                    {
                        return 15;
                    }
                default:
                    {
                        return int.Parse(strHex);
                    }
            }
        }
        #endregion

        #region To Hexa
        /// <summary>
        /// Converts a color to hex string
        /// </summary>
        public static string ToHexa(Color value)
        {
            return string.Format("#{0:x2}{1:x2}{2:x2}", value.Red, value.Green, value.Blue).ToUpper();
        }
        #endregion

        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public ColorConverter()
        { }
        #endregion
    }
}
