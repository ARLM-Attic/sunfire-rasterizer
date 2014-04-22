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
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Thn.Drawing;
#endregion

namespace DemoHelpers
{
    /// <summary>
    /// A helper class to obtain a gdi+ System.Drawing.Bitmap from <see cref="RenderingBuffer"/>
    /// </summary>
    public class BufferToBitmap
    {
        #region Get Buffer
        /// <summary>
        /// Obtains a rendering buffer from a gdi+ System.Drawing.Bitmap
        /// </summary>
        public static PixelBuffer GetBuffer(Image source)
        {
            PixelBuffer result = new PixelBuffer(source.Width, source.Height, source.Width);
            DrawBitmapToBuffer(source, result);
            return result;
        }
        #endregion

        #region Draw System.Drawing.Bitmap To Buffer
        /// <summary>
        /// Draw a gdi+ System.Drawing.Bitmap to the rendering buffer
        /// </summary>
        public static void DrawBitmapToBuffer(Image source, PixelBuffer buffer)
        {
            //make sure we have a ABGR System.Drawing.Bitmap
            System.Drawing.Bitmap bmp = null;
            bmp = new System.Drawing.Bitmap(source.Width, source.Height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);
            g.DrawImage(source, new Rectangle(0, 0, source.Width, source.Height));
            g.Dispose();

            //copy System.Drawing.Bitmap's data to buffer
            Rectangle r = new Rectangle(0, 0, source.Width, source.Height);
            BitmapData data = bmp.LockBits(r, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            IntPtr ptr = data.Scan0;
            int size = data.Stride * bmp.Height;
            byte[] tmpBuffer = new byte[bmp.Width * bmp.Height * 4];
            System.Runtime.InteropServices.Marshal.Copy(ptr, tmpBuffer, 0, size);
            bmp.UnlockBits(data);

            //copy to pixel buffer
            buffer.FromBytes(tmpBuffer, PixelFormats.Bgra);
        }
        #endregion

        #region Get System.Drawing.Bitmap
        /// <summary>
        /// Obtain a gdi+ System.Drawing.Bitmap from <see cref="RenderingBuffer"/>
        /// </summary>
        public static System.Drawing.Bitmap GetBitmap(PixelBuffer source, PixelFormat format)
        {
            System.Drawing.Bitmap bmp = null;
            int width = source.Width;
            int height = source.Height;
            Rectangle r = new Rectangle(0, 0, width, height);

            bmp = new System.Drawing.Bitmap(width, height, format);
            BitmapData data = bmp.LockBits(r, ImageLockMode.ReadWrite, format);
            IntPtr ptr = data.Scan0;

            //calculate buffer size
            int size = 0;
            int bpp = 0;
            switch (format)
            {
                case PixelFormat.Format24bppRgb:
                    bpp = 24;
                    break;
                case PixelFormat.Format32bppArgb:
                    bpp = 32;
                    break;
                case PixelFormat.Format32bppPArgb:
                    bpp = 32;
                    break;
                case PixelFormat.Format32bppRgb:
                    bpp = 32;
                    break;
                case PixelFormat.Format48bppRgb:
                    bpp = 48;
                    break;
                case PixelFormat.Format4bppIndexed:
                    bpp = 48;
                    break;
                case PixelFormat.Format64bppArgb:
                    bpp = 64;
                    break;
                case PixelFormat.Format64bppPArgb:
                    bpp = 64;
                    break;
                case PixelFormat.Format8bppIndexed:
                    bpp = 8;
                    break;
            }
            size = width * (bpp / 8) * height;

            //byte[] buffer = new byte[size];
            //System.Runtime.InteropServices.Marshal.Copy(ptr, buffer, 0, size);

            //copy from source to buffer
            byte[] buffer = source.ToBytes(PixelFormats.Bgra);
            //source.Buffer.CopyTo(buffer, 0);

            //copy back to System.Drawing.Bitmap
            System.Runtime.InteropServices.Marshal.Copy(buffer, 0, ptr, size);

            bmp.UnlockBits(data);

            return bmp;
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public BufferToBitmap()
        { }
        #endregion
    }
}
