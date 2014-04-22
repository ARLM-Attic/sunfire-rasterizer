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
using System.ComponentModel;
using System.Windows.Forms;
using Thn.Drawing;

namespace DrawerDemo
{
    public partial class fmTransformDemo : Form
    {
        int w = 200;
        int h = 200;
        int cx, cy = 0;
        PixelBuffer buffer = null;
        IDrawer drawer = null;

        #region Initialize
        public fmTransformDemo()
        {
            InitializeComponent();
        }

        private void fmTransformDemo_Load(object sender, EventArgs e)
        {
            buffer = new PixelBuffer(w, h);
        }
        #endregion

        #region Translate
        private void btnTranslate_Click(object sender, EventArgs e)
        {
            double tx = 25;
            double ty = 25;

            //original view
            drawer = new Drawer(buffer);
            Prepare();
            DrawShape();
            DisplayOriginal(buffer);

            //after view 1
            drawer = new Drawer(buffer);
            Prepare();
            drawer.Translate(tx, 0);
            DrawShape();
            DisplayAfter1(buffer);
            txtDesc1.Text = string.Format("Translate X = {0}", tx);

            //after view 2
            drawer = new Drawer(buffer);
            Prepare();
            drawer.Translate(0, ty);
            DrawShape();
            DisplayAfter2(buffer);
            txtDesc2.Text = string.Format("Translate Y = {0}", ty);

            //after view 3
            drawer = new Drawer(buffer);
            Prepare();
            drawer.Translate(tx, ty);
            DrawShape();
            DisplayAfter3(buffer);
            txtDesc3.Text = string.Format("Translate X = {0}\r\nTranslate Y = {1}", tx, ty);
        }
        #endregion

        #region Rotate
        private void btnRotate_Click(object sender, EventArgs e)
        {
            double angle = 45;

            //original view
            drawer = new Drawer(buffer);
            Prepare();
            DrawShape();
            DisplayOriginal(buffer);

            //after view 1
            drawer = new Drawer(buffer);
            Prepare();
            drawer.Rotate(angle);
            DrawShape();
            DisplayAfter1(buffer);
            txtDesc1.Text = string.Format("Rotate Angle = {0}\r\nCenter (0, 0)", angle);

            //after view 2
            drawer = new Drawer(buffer);
            Prepare();
            drawer.Rotate(angle, cx, cy);
            DrawShape();
            DisplayAfter2(buffer);
            txtDesc2.Text = string.Format("Rotate Angle = {0}\r\nCenter ({1}, {2})", angle, cx, cy);

            //discard after view 3
            DisplayAfter3(null);
            txtDesc3.Text = "";
        }
        #endregion

        #region Scale
        private void btnScale_Click(object sender, EventArgs e)
        {           
            //original view
            drawer = new Drawer(buffer);
            Prepare();
            DrawShape();
            DisplayOriginal(buffer);

            //after view 1
            double sx = 0.3;
            double sy = 1.25;
            drawer = new Drawer(buffer);
            Prepare();
            drawer.Scale(sx, sy);
            DrawShape();
            DisplayAfter1(buffer);
            txtDesc1.Text = string.Format("Scale X = {0}, Scale Y = {1}", sx, sy);

            //after view 2
            sx = 0.5;
            sy = 0.5;
            drawer = new Drawer(buffer);
            Prepare();
            drawer.Scale(sx, sy);
            DrawShape();
            DisplayAfter2(buffer);
            txtDesc2.Text = string.Format("Scale X = {0}, Scale Y = {1}", sx, sy);

            //after view 3
            drawer = new Drawer(buffer);
            Prepare();
            drawer.Scale(sx, sy, cx, cy);
            DrawShape();
            DisplayAfter3(buffer);
            txtDesc3.Text = string.Format("Scale X = {0}, Scale Y = {1}\r\nCenter ({2}, {3})", sx, sy, cx, cy);
        }
        #endregion

        #region Skew
        private void btnSkew_Click(object sender, EventArgs e)
        {
            //original view
            drawer = new Drawer(buffer);
            Prepare();
            DrawShape();
            DisplayOriginal(buffer);

            //after view 1
            double sx = 45;
            double sy = 0.0;

            drawer = new Drawer(buffer);
            Prepare();
            drawer.Skew(sx, sy);
            DrawShape();
            DisplayAfter1(buffer);
            txtDesc1.Text = string.Format("Skew X = {0}, Skew Y = {1}", sx, sy);

            //after view 2
            sx = 0.0;
            sy = 45;

            drawer = new Drawer(buffer);
            Prepare();
            drawer.Skew(sx, sy);
            DrawShape();
            DisplayAfter2(buffer);
            txtDesc2.Text = string.Format("Skew X = {0}, Skew Y = {1}", sx, sy);

            //after view 3
            drawer = new Drawer(buffer);
            Prepare();
            drawer.Skew(sx, sy, cx, cy);
            DrawShape();
            DisplayAfter3(buffer);
            txtDesc3.Text = string.Format("Skew X = {0}, Skew Y = {1}\r\nCenter ({2}, {3})", sx, sy, cx, cy);
        }
        #endregion

        #region Push, Pop
        private void btnPushPop_Click(object sender, EventArgs e)
        {
            //original view
            drawer = new Drawer(buffer);
            Prepare();

            Fill fill = Fills.Red;
            fill.Opacity = 0.2;
            drawer.DrawRectangle(fill, 50, 0, 150, 50);
            drawer.PushMatrix();
            drawer.Rotate(20);
            drawer.DrawRectangle(fill, 50, 0, 150, 50);
            drawer.PushMatrix();
            drawer.Rotate(30);
            drawer.DrawRectangle(fill, 50, 0, 150, 50);

            //revert transformations
            fill = Fills.Blue;
            fill.Opacity = 0.2;
            drawer.DrawRectangle(fill, 50, 0, 50, 20);
            drawer.PopMatrix();
            drawer.DrawRectangle(fill, 50, 0, 50, 20);
            drawer.PopMatrix();
            drawer.DrawRectangle(fill, 50, 0, 50, 20);

            DisplayOriginal(buffer);
            
            //discard after view 1, 2, 3
            DisplayAfter1(null);
            DisplayAfter2(null);
            DisplayAfter3(null);
            txtDesc1.Text = "";
            txtDesc2.Text = "";
            txtDesc3.Text = "";
        }
        #endregion

        #region Prepare
        void Prepare()
        {
            cx = w / 2;
            cy = h / 2;

            //clear background
            drawer.Clear(Colors.White);

            //draw a black rectangle in center
            Fill fill = Fills.Gray;
            int size = 15;
            drawer.DrawRectangle(fill, cx - size, cy - size, size * 2, size * 2);
        }
        #endregion

        #region Draw Shape
        void DrawShape()
        {
            Fill fill = Fills.YellowGreen;
            fill.Opacity = 0.5;

            double[] poly = new double[]
            {
                   50, 50
                ,  80, 50
                , 100, 20
                , 120, 50
                , 150, 50
                , 150, 150
                ,  50, 150
                ,  50, 50
            };

            drawer.DrawPolygon(fill, poly);
        }
        #endregion

        #region Display Buffers
        System.Drawing.Bitmap bmpOrg = null;
        System.Drawing.Bitmap bmpAfter1 = null;
        System.Drawing.Bitmap bmpAfter2 = null;
        System.Drawing.Bitmap bmpAfter3 = null;

        /// <summary>
        /// Helper method to display result from a pixel buffer to Original view
        /// </summary>
        void DisplayOriginal(PixelBuffer buffer)
        {
            if (bmpOrg != null) bmpOrg.Dispose();
            bmpOrg = DemoHelpers.BufferToBitmap.GetBitmap(buffer, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            pbOriginal.Image = bmpOrg;
        }

        /// <summary>
        /// Helper method to display result from a pixel buffer to After 1 view
        /// </summary>
        void DisplayAfter1(PixelBuffer buffer)
        {
            if (bmpAfter1 != null) bmpAfter1.Dispose();
            if (buffer != null)
            {
                bmpAfter1 = DemoHelpers.BufferToBitmap.GetBitmap(buffer, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                pbAfter1.Image = bmpAfter1;
            }
            else pbAfter1.Image = null;
        }

        /// <summary>
        /// Helper method to display result from a pixel buffer to After 2 view
        /// </summary>
        void DisplayAfter2(PixelBuffer buffer)
        {
            if (bmpAfter2 != null) bmpAfter2.Dispose();
            if (buffer != null)
            {
                bmpAfter2 = DemoHelpers.BufferToBitmap.GetBitmap(buffer, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                pbAfter2.Image = bmpAfter2;
            }
            else pbAfter2.Image = null;
        }

        /// <summary>
        /// Helper method to display result from a pixel buffer to After 3 view
        /// </summary>
        void DisplayAfter3(PixelBuffer buffer)
        {
            if (bmpAfter3 != null) bmpAfter3.Dispose();
            if (buffer != null)
            {
                bmpAfter3 = DemoHelpers.BufferToBitmap.GetBitmap(buffer, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                pbAfter3.Image = bmpAfter3;
            }
            else pbAfter3.Image = null;
        }
        #endregion
    }
}
