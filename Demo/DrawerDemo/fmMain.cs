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

namespace DrawerDemo
{
    public partial class fmMain : Form
    {
        #region Initialize
        public fmMain()
        {
            InitializeComponent();
        }

        private void fmMain_Load(object sender, EventArgs e)
        {

        }
        #endregion

        #region Primitives
        private void btnPrimitives_Click(object sender, EventArgs e)
        {
            fmPrimitiveRendering fm = new fmPrimitiveRendering();
            fm.Show();
        }
        #endregion

        #region Transformations
        private void btnTransformations_Click(object sender, EventArgs e)
        {
            fmTransformDemo fm = new fmTransformDemo();
            fm.Show();
        }
        #endregion

        #region Fills
        private void btnFills_Click(object sender, EventArgs e)
        {
            //new fmFillDemo().Show();
            new fmFill().Show();
        }
        #endregion

        #region Gamma Correction
        private void btnGammaCorrection_Click(object sender, EventArgs e)
        {
            fmGammaCorrection fm = new fmGammaCorrection();
            fm.Show();
        }
        #endregion

        #region Pixel Buffer
        private void btnPixelBuffer_Click(object sender, EventArgs e)
        {
            fmPixelBufferDemo fm = new fmPixelBufferDemo();
            fm.Show();
        }
        #endregion

        #region Opacity Mask
        private void btnOpacityMask_Click(object sender, EventArgs e)
        {
            fmOpacityMask fm = new fmOpacityMask();
            fm.Show();
        }
        #endregion
    }
}
