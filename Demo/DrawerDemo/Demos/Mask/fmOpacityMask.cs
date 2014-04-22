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
using System;
using System.Collections;
using System.Windows.Forms;
using Thn.Drawing;
using DemoHelpers;

namespace DrawerDemo
{
    public partial class fmOpacityMask : Form
    {
        IDrawer drawer = null;
        PixelBuffer buffer = null;

        #region Initialize
        public fmOpacityMask()
        {
            InitializeComponent();
        }

        private void fmOpacityMask_Load(object sender, EventArgs e)
        {
            buffer = new PixelBuffer(400, 400);
            drawer = new Drawer(buffer);
        }
        #endregion

        #region Draw Mask Region
        private void btnDrawMask_Click(object sender, EventArgs e)
        {
            //clear background
            drawer.Clear(Colors.White);

            //render
            DrawMaskRegion();

            //show to screen
            DisplayBuffer(buffer);
        }
        #endregion

        #region Draw Lion
        private void btnDrawLion_Click(object sender, EventArgs e)
        {
            //clear background
            drawer.Clear(Colors.White);

            //render
            DrawLion();

            //show to screen
            DisplayBuffer(buffer);
        }
        #endregion

        #region Draw Lion With Mask
        private void btnDrawWithMask_Click(object sender, EventArgs e)
        {
            //clear background
            drawer.Clear(Colors.White);

            //render hint for mask region
            DrawMaskRegion();

            //create an opacity mask
            MaskBuffer mask = new MaskBuffer(buffer.Width, buffer.Height);
            double[] coordinates = TestFactory.Star();
            TestFactory.Scale(coordinates, 8.0);
            Fill fill = Fills.Black;
            MaskDrawer maskDrawer = new MaskDrawer(mask);
            maskDrawer.DrawPolygon(fill, coordinates);

            //render the lion using the opacity mask

            drawer.Mask = mask;
            DrawLion();

            //show to screen
            DisplayBuffer(buffer);

            //reset opacity mask so that other tests aren't afffected
            drawer.Mask = null;
        }
        #endregion

        #region Zoom
        private void sbZoom_Scroll(object sender, ScrollEventArgs e)
        {
            double zoom = (double)sbZoom.Value / 10.0;
            lblZoomFactor.Text = string.Format("{0:#,##}%", zoom * 100);
            pbView.Zoom = zoom;
        }
        #endregion

        #region Display Buffer
        System.Drawing.Bitmap bmp = null;

        /// <summary>
        /// Helper method to display result from a pixel buffer
        /// </summary>
        void DisplayBuffer(PixelBuffer buffer)
        {
            if (bmp != null) bmp.Dispose();
            bmp = DemoHelpers.BufferToBitmap.GetBitmap(buffer, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            pbView.Image = bmp;
        }
        #endregion

        #region Draw Lion
        void DrawLion()
        {
            //get coordinates and colors
            double[][] polygons = LionPathHelper.GetLionPolygons();
            Color[] colors = LionPathHelper.GetLionColors();

            drawer.GammaCorrected = false;//DEBUG - ColorRasterizer is not yet finished

            //iterate all polygons and draw them
            double[] coordinates = null;
            for (int i = 0; i < polygons.Length; i++)
            {
                coordinates = polygons[i];
                Fill fill = new Fill(colors[i]);
                fill.FillingRule = FillingRule.EvenOdd;//DEBUG - ColorRasterizer is not yet finished

                drawer.DrawPolygon(fill, coordinates);
            }
        }
        #endregion

        #region Draw Mask Region
        void DrawMaskRegion()
        {
            double[] coordinates = TestFactory.Star();
            TestFactory.Scale(coordinates, 8.0);

            Fill fill = new Fill(Colors.DodgerBlue);
            fill.Opacity = 0.3;

            drawer.DrawPolygon(fill, coordinates);
        }
        #endregion
    }
}
