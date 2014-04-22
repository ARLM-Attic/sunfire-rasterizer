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
    /// Gamma function to build gamma lookup table by using power function
    /// <para>Default gamma value is 1.6</para>
    /// </summary>
    public class PowerGammaCorrector:IGammaCorrector
    {
     
        #region Gamma
        private double mGammaRed = 1.0;
        /// <summary>
        /// Gets/Sets gamma value
        /// </summary>
        public double GammaRed
        {
            get { return mGammaRed; }
            set
            {
                if (mGammaRed != value)
                {
                    mGammaRed = value;
                    BuildCache(mGammaRed,cachedArrayRed);
                }
            }
        }
        #endregion

        #region Gamma
        private double mGammaGreen = 1.0;
        /// <summary>
        /// Gets/Sets gamma value
        /// </summary>
        public double GammaGreen
        {
            get { return mGammaGreen; }
            set
            {
                if (mGammaGreen != value)
                {
                    mGammaGreen = value;
                    BuildCache(mGammaGreen, cachedArrayGreen);
                }
            }
        }
        #endregion

        #region Gamma
        private double mGammaBlue = 1.0;
        /// <summary>
        /// Gets/Sets gamma value
        /// </summary>
        public double GammaBlue
        {
            get { return mGammaBlue; }
            set
            {
                if (mGammaBlue != value)
                {
                    mGammaBlue = value;
                    BuildCache(mGammaBlue, cachedArrayBlue);
                }
            }
        }
        #endregion
  
        #region field

        /// <summary>
        /// Saving lookup table for red including 256 value
        /// </summary>
        byte[] cachedArrayRed = new byte[256];

        /// <summary>
        /// Saving lookup table for green including 256 value
        /// </summary>
        byte[] cachedArrayGreen = new byte[256];

        /// <summary>
        /// Saving lookup table for blue including 256 value
        /// </summary>
        byte[] cachedArrayBlue = new byte[256];
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor for gamma corector
        /// </summary>
        public PowerGammaCorrector()
        {
            BuildCache(mGammaRed,cachedArrayRed);
            BuildCache(mGammaGreen, cachedArrayGreen);
            BuildCache(mGammaBlue, cachedArrayBlue);
        }

        /// <summary>
        /// Constructor with custom gamma value
        /// </summary>
        /// <param name="gamma"></param>
        public PowerGammaCorrector(double gamma)
        {
            //Gamma = gamma;
            //mGamma = gamma;
            //BuildCache(mGamma);

            mGammaRed = gamma;
            mGammaGreen = gamma;
            mGammaBlue = gamma;

            BuildCache(mGammaRed, cachedArrayRed);
            BuildCache(mGammaGreen, cachedArrayGreen);
            BuildCache(mGammaBlue, cachedArrayBlue);
        }

        /// <summary>
        /// Constructor with custom gamma for red,green, blue
        /// </summary>
        /// <param name="gammaRed"></param>
        /// <param name="gammaGreen"></param>
        /// <param name="gammaBlue"></param>
        public PowerGammaCorrector(double gammaRed, double gammaGreen, double gammaBlue)
        {
            mGammaRed = gammaRed;
            mGammaGreen = gammaGreen;
            mGammaBlue = gammaBlue;

            BuildCache(mGammaRed, cachedArrayRed);
            BuildCache(mGammaGreen, cachedArrayGreen);
            BuildCache(mGammaBlue, cachedArrayBlue);
        }
        #endregion

        #region Get lookup table RED
        /// <summary>
        /// Get lookup table
        /// </summary>
        /// <returns></returns>
        public byte[] GetLookupTableRed()
        {
            return cachedArrayRed;
        }
        #endregion

        #region Get lookup table GREEN
        /// <summary>
        /// Get lookup table
        /// </summary>
        /// <returns></returns>
        public byte[] GetLookupTableGreen()
        {
            return cachedArrayGreen;
        }
        #endregion

        #region Get lookup table BLUE
        /// <summary>
        /// Get lookup table
        /// </summary>
        /// <returns></returns>
        public byte[] GetLookupTableBlue()
        {
            return cachedArrayBlue;
        }
        #endregion

        #region build cache
        /// <summary>
        /// Build cache
        /// </summary>
        /// <param name="gamma"></param>
        void BuildCache(double gamma,byte[] destArray)
        {
            double inverseGamma = 1.0 / gamma;
            for (uint i = 0; i < 256; i++)
            {
                destArray[i] = (byte)(Math.Pow(i / 255.0, inverseGamma) * 255.0);
            }
        }
        #endregion
    }
}
