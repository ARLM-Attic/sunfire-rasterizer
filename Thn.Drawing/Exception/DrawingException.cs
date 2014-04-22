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
    public class DrawingExceptionBase : Thn.Application.ExceptionBase
    {
        #region OPTIONAL (if not inherited from Thn.Application.ExceptionBase)
        /*
        /// <summary>
        /// When true, static exception publishers will write exception to logs
        /// </summary>
        public static bool LogError;
        
        /// <summary>
        /// When true, static exception publishers will not throw exception
        /// </summary>
        public static bool SilentError;
        */
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new empty instance
        /// </summary>
        public DrawingExceptionBase() { }

        /// <summary>
        /// Creates a new instance with provided message
        /// </summary>
        public DrawingExceptionBase(string message) : base(message) { }

        /// <summary>
        /// Creates a new instance with message & inner as provided by the original error
        /// </summary>
        public DrawingExceptionBase(Exception original) : base(original.Message, original.InnerException) { }

        /// <summary>
        /// Creates a new instance that stacks above an inner exception
        /// </summary>
        /// <param name="message">The message for this exception</param>
        /// <param name="innerError">Inner stack exception</param>
        public DrawingExceptionBase(string message, Exception innerError) : base(message, innerError) { }
        #endregion
    }
}
