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
    /// Inner paint of a shaped. Used for rendering inner region's texture
    /// </summary>
    public class Fill : PaintMaterial
    {
        #region Ambient Object Pattern

        #region Clone
        /// <summary>
        /// Create a new instance with same properties as this instance (shadow copy)
        /// <para>Notes: the cloned object will no longer be ambient object</para>
        /// </summary>
        public Fill Clone()
        {
            Fill result = new Fill();
            
            //deliberately assign using properties so that the properties
            //will no longer be ambient
            result.Paint = this.mPaint;
            result.Opacity = this.mOpacity;
            result.FillingRule = this.mFillingRule;
            result.TransformMatrix = this.mTransformMatrix;

            return result;
        }
        #endregion

        #region Is Ambient
        /// <summary>
        /// Check whether any property of this object is ambient
        /// </summary>
        public bool IsAmbient
        {
            get
            {
                return (mPaintAssigned == false)
                    || (mOpacityAssigned == false)
                    || (mFillingRuleAssigned == false)
                    || (mTransformMatrixAssigned == false);
            }
        }
        #endregion

        #region Merge
        /// <summary>
        /// Merge this object with a source object using ambient object pattern merging rule
        /// </summary>
        public void Merge(Fill source)
        {
            if (mPaintAssigned == false) mPaint = source.mPaint;
            if (mOpacityAssigned == false) mOpacity = source.mOpacity;
            if (mFillingRuleAssigned == false) mFillingRule = source.mFillingRule;
            if (mTransformMatrixAssigned == false) mTransformMatrix = source.mTransformMatrix;
        }
        #endregion

        #region Reset
        /// <summary>
        /// Resets all properties to default value and make them ambient
        /// </summary>
        public void Reset()
        {
            mPaint = null;
            mPaintAssigned = false;

            mOpacity = 1.0;
            ScaledOpacity = 256;
            mOpacityAssigned = false;

            mFillingRule = FillingRule.Default;
            mFillingRuleAssigned = false;

            mTransformMatrix = null;
            mTransformMatrixAssigned = false;
        }
        #endregion

        #endregion

        #region Constructors
        /// <summary>
        /// Create a new empty fill
        /// </summary>
        public Fill() { }

        /// <summary>
        /// Create a new fill with a specific paint
        /// </summary>
        public Fill(Paint paint)
            : base(paint) { }

        /// <summary>
        /// Create a new fill with a specific paint and opacity
        /// </summary>
        public Fill(Paint paint, double opacity)
            : base(paint, opacity) { }

        /// <summary>
        /// Create a new uniform color fill with paint is a ColorPaint
        /// </summary>
        public Fill(Color color)
        {
            Paint = new ColorPaint(color);
        }
        #endregion
    }
}
