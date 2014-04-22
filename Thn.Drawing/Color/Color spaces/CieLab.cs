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
    /// A single color in CIE LAB color space
    /// <para>Lab color space is a color-opponent space with dimension L for luminance and a and b for the color-opponent dimensions, based on nonlinearly-compressed CIE XYZ color space coordinates.</para>
    /// </summary>
    public class CieLab
    {
        #region Properties

        #region Alpha
        private byte mAlpha = 255;
        /// <summary>
        /// Gets/Sets the alpha property
        /// <para>Value must be in range [0, 255]</para>
        /// <para>Notes: this colorspace actually does not have Alpha component. The component is kept for conversion between ARGB and this colorspace</para>
        /// </summary>
        public byte Alpha
        {
            get { return mAlpha; }
            set { mAlpha = value; }
        }
        #endregion

        #region L
        private double mL;
        /// <summary>
        /// Gets/Sets L component
        /// </summary>
        public double L
        {
            get { return mL; }
            set { mL = value; }
        }
        #endregion

        #region A
        private double mA;
        /// <summary>
        /// Gets/Sets A
        /// </summary>
        public double A
        {
            get { return mA; }
            set { mA = value; }
        }
        #endregion

        #region B
        private double mB;
        /// <summary>
        /// Gets/Sets B component 
        /// </summary>
        public double B
        {
            get { return mB; }
            set { mB = value; }
        }
        #endregion

        #endregion

        #region Operators

        public static bool operator ==(CieLab a, CieLab b)
        {
            return (a.mL == b.mL && a.mA == b.mA && a.mB == b.mB && a.mAlpha == b.mAlpha);
        }

        public static bool operator !=(CieLab a, CieLab b)
        {
            return (a.mL != b.mL || a.mA != b.mA || a.mB != b.mB || a.mAlpha != b.mAlpha);
        }
        #endregion

        #region Equality

        /// <summary>
        /// Check quality of the object against this instance
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj is CieLab) return this == (CieLab)obj;
            else return false;
        }

        /// <summary>
        /// Returns the hash code for this instance
        /// </summary>
        public override int GetHashCode()
        {
            return mL.GetHashCode() ^ mA.GetHashCode() ^ mB.GetHashCode() ^ mAlpha.GetHashCode();
        }
        #endregion

        #region To String
        /// <summary>
        /// Converts to display text
        /// </summary>
        public override string ToString()
        {
            return string.Format("L*: {0} A*: {1} B*: {2} Alpha: {3}", mL, mA, mB, mAlpha);
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public CieLab()
        { }

        /// <summary>
        /// Create new instance
        /// </summary>
        public CieLab(double l, double a, double b)
        {
            mL = l;
            mA = a;
            mB = b;
        }
        #endregion
    }
}
