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
    /// Path command using internal to determine current coordinate
    /// </summary>
    internal enum DrawingPathCommand
    {
        /// <summary>
        /// Special move to, when call direct ly move to in path object
        /// </summary>
        NewFigure,
        /// <summary>
        /// Special move to, this will implemented while using closeAllFigures
        /// </summary>
        NewFigureAndCloseLast,
        /// <summary>
        /// Move to new coordinate, this will create new polygon in 
        /// final result
        /// </summary>
        MoveTo ,
        /// <summary>
        /// Add a line to final polygon
        /// </summary>
        LineTo ,
        /// <summary>
        /// Add an ellipse arc to final polygon.
        /// This will include more information:
        ///     Radius X: radius x
        ///     Radius Y: radius y
        ///     Angle   : angle of ellipse
        ///     IsLagreArc  : Is draw large arc
        ///     IsSweepUpper: is sweep upper ellipse
        /// See picture in page 174, SVG specs
        /// </summary>
        ArcTo  ,
        /// <summary>
        /// Add an bezier curve to final polygon. This need more information
        /// about two middle control points: x1,y1; x2,y2
        /// </summary>
        CurveTo,

        /// <summary>
        /// Add quadratic,a type of bezier including 1 control point only
        /// </summary>
        QuadraticTo

    }
}
