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
using System.Collections;
#endregion

namespace Thn.Drawing
{
    /// <summary>
    /// A stack collection for <see cref="Matrix3x3"/>
    /// </summary>
    public class Matrix3x3Stack
    {
        #region Fields
        Stack mStack = null;
        #endregion

        #region Count
        /// <summary>
        /// Gets the number of elements contained in this stack
        /// </summary>
        public int Count
        {
            get { return mStack.Count; }
        }
        #endregion

        #region Push
        /// <summary>
        /// Insert an item at the top of stack
        /// </summary>
        public void Push(Matrix3x3 item)
        {
            mStack.Push(item);
        }
        #endregion

        #region Pop
        /// <summary>
        /// Remove and return the item that the top of stack
        /// </summary>
        public Matrix3x3 Pop()
        {
            return (Matrix3x3)mStack.Pop();            
        }
        #endregion

        #region Clone
        /// <summary>
        /// Create an exact duplicate of this stack
        /// </summary>
        public Matrix3x3Stack Clone()
        {
            return new Matrix3x3Stack(this);
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public Matrix3x3Stack()
        {
            mStack = new Stack();
        }

        private Matrix3x3Stack(Matrix3x3Stack source)
        {
            mStack = new Stack(source.mStack);
        }
        #endregion
    }
}
