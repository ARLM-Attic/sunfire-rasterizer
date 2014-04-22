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
    /// Provides a memory buffer for masking (opacity, clipping, etc.). Each pixel's opacity is represented by a single byte (0-255)
    /// </summary>
    public class MaskBuffer
    {
        #region Fields
        /// <summary>
        /// The memory buffer. Each pixel's opacity is represented by a single byte (0-255)
        /// </summary>
        public byte[] Data = null;

        /// <summary>
        /// x-axis offset (relative to the underlying <see cref="PixelBuffer"/>
        /// </summary>
        public int Left = 0;

        /// <summary>
        /// y-axis offset (relative to the underlying <see cref="PixelBuffer"/>
        /// </summary>
        public int Top = 0;

        /// <summary>
        /// Horizontal size of buffer (in pixels)
        /// </summary>
        public int Width = 0;

        /// <summary>
        /// Vertical size of buffer (in pixels)
        /// </summary>
        public int Height = 0;

        /// <summary>
        /// The number of pixels a row contains
        /// </summary>
        public int Stride = 0;

        /// <summary>
        /// Starting index offset
        /// </summary>
        public int StartOffset = 0;
        #endregion

        #region Get Row Index
        /// <summary>
        /// Calculate the index of a specific row
        /// <para>NOTE: for performance optimzation, replace this method with inline code: rowIndex = StartOffset + row*Stride</para>
        /// </summary>
        public int GetRowIndex(int row)
        {
            return StartOffset + row * Stride;
        }
        #endregion

        #region Get Pixel Index
        /// <summary>
        /// Calculate the index of a pixel
        /// <para>NOTE: for performance optimzation, replace this method with inline code: rowIndex = StartOffset + row*Stride + column</para>
        /// </summary>
        public int GetPixelIndex(int column, int row)
        {
            return StartOffset + row * Stride + column;
        }
        #endregion

        #region Clear
        /// <summary>
        /// Resets all pixels to default value
        /// </summary>
        public void Clear()
        {
            Array.Clear(Data, 0, Data.Length);
        }

        /// <summary>
        /// Reset this buffer to a specific value
        /// </summary>
        public void Clear(byte value)
        {
            for (int i = 0; i < Data.Length; i++)
            {
                Data[i] = value;
            }
        }        
        #endregion
        
        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public MaskBuffer()
        { }

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="width">Horizontal size of buffer (in pixels)</param>
        /// <param name="height">Vertical size of buffer (in pixels)</param>
        public MaskBuffer(int width, int height)
        {
            Width = width;
            Height = height;
            Stride = width;
            Data = new byte[width * height];
        }

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="width">Horizontal size of buffer (in pixels)</param>
        /// <param name="height">Vertical size of buffer (in pixels)</param>
        /// <param name="stride">The number of pixels a row contains</param>
        public MaskBuffer(int width, int height, int stride)
        {
            Width = width;
            Height = height;
            Stride = stride;
            if (stride < 0)
            {
                StartOffset = -(height - 1) * stride;
                Data = new byte[-stride * height];
            }
            else Data = new byte[stride * height];
        }

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="data">The memory buffer to use instead of creating a new one</param>
        /// <param name="width">Horizontal size of buffer (in pixels)</param>
        /// <param name="height">Vertical size of buffer (in pixels)</param>
        /// <param name="stride">The number of pixels a row contains</param>
        public MaskBuffer(byte[] data, int width, int height, int stride)
        {
            Data = data;
            Width = width;
            Height = height;
            Stride = stride;
            if (stride < 0)
            {
                StartOffset = -(height - 1) * stride;
            }
        }
        #endregion
    }
}
