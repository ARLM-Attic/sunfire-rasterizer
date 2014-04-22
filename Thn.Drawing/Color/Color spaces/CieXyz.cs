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
    /// A single color in CIE XYZ color space
    /// <para>Also known as CIE 1931 color space, created by the International Commission on Illumination (CIE) in 1931</para>
    /// </summary>
    public class CieXyz
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

        #region X
        private double mX;
        /// <summary>
        /// Gets/Sets X component.
        /// <para>Value must be in range [0, 0.9505]</para>
        /// </summary>
        public double X
        {
            get { return mX; }
            set
            {
                if (value > 0.9505) mX = 0.9505;
                else if (value < 0) mX = 0;
                else mX = value;
            }
        }
        #endregion

        #region Y
        private double mY;
        /// <summary>
        /// Gets/Sets Y component
        /// <para>Value must be in range [0, 1]</para>
        /// </summary>
        public double Y
        {
            get { return mY; }
            set
            {
                if (value > 1) mY = 1;
                else if (value < 0) mY = 0;
                else mY = value;
            }
        }
        #endregion

        #region Z
        private double mZ;
        /// <summary>
        /// Gets/Sets Z component
        /// <para>Value must be in range [0, 1.089]</para>
        /// </summary>
        public double Z
        {
            get { return mZ; }
            set
            {
                if (value > 1.089) mZ = 1.089;
                else if (value < 0) mZ = 0;
                else mZ = value;
            }
        }
        #endregion

        #endregion

        #region Operators

        public static bool operator ==(CieXyz a, CieXyz b)
        {
            return (a.mX == b.mX && a.mY == b.mY && a.mZ == b.mZ && a.mAlpha == b.mAlpha);
        }

        public static bool operator !=(CieXyz a, CieXyz b)
        {
            return (a.mX != b.mX || a.mY != b.mY || a.mZ != b.mZ || a.mAlpha != b.mAlpha);
        }
        #endregion

        #region Equality

        /// <summary>
        /// Check quality of the object against this instance
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj is CieXyz) return this == (CieXyz)obj;
            else return false;
        }

        /// <summary>
        /// Returns the hash code for this instance
        /// </summary>
        public override int GetHashCode()
        {
            return mX.GetHashCode() ^ mY.GetHashCode() ^ mZ.GetHashCode() ^ mAlpha.GetHashCode();
        }
        #endregion

        #region To String
        /// <summary>
        /// Converts to display text
        /// </summary>
        public override string ToString()
        {
            return string.Format("X: {0} Y: {1} Z: {2} Alpha: {3}", mX, mY, mZ, mAlpha);
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public CieXyz()
        { }

        /// <summary>
        /// Create new instance
        /// </summary>
        public CieXyz(double x, double y, double z)
        {
            //x
            if (x > 0.9505) mX = 0.9505;
            else if (x < 0) mX = 0;
            else mX = x;

            //y
            if (y > 1) mY = 1;
            else if (y < 0) mY = 0;
            else mY = y;

            //z
            if (z > 1.089) mZ = 1.089;
            else if (z < 0) mZ = 0;
            else mZ = z;
        }
        #endregion
    }
}
