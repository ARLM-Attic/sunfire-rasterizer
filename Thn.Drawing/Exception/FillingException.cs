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
    /// 
    /// </summary>
    public class FillingException : Thn.Application.ExceptionBase
    {
        #region Get Message
        /// <summary>
        /// Fully loaded message builder
        /// </summary>
        static string GetMessage(Type fillingType, string message)
        {
            string result = "";
            if (Thn.Application.Language.Language.Current == Thn.Application.Language.Vietnamese.Vietnamese.Instance)
                result = string.Format("Filling exception in {0}. Details : {1} ",fillingType,message);
            else
                result = string.Format("Filling exception in {0}. Details : {1} ", fillingType, message);
            return result;
        }
        #endregion

        #region Publish
        /// <summary>
        /// Publish exception
        /// </summary>
        /// <param name="sender">the subsystem that raises this error</param>
        /// <param name="control">the control that is not supported</param>
        [System.Diagnostics.DebuggerHidden]
        public static void Publish(Type fillingType,string message)
        {
            FillingException error = new FillingException(fillingType, message);
            //write error to log            
            if (Thn.Application.ExceptionBase.LogError) Thn.Log.Error(error);
            //throw error
            if (!Thn.Application.ExceptionBase.SilentError) throw error;
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Full constructor
        /// </summary>
        /// <param name="sender">the subsystem that raises this error</param>
        /// <param name="control">the control that is not supported</param>
        public FillingException(Type fillingType,string message)
            : base(GetMessage(fillingType,message)) { }
        #endregion
    }
}
