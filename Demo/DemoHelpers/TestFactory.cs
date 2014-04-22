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

namespace DemoHelpers
{
    /// <summary>
    /// Helper class to provide coordinates used in common tests
    /// </summary>
    public class TestFactory
    {
        #region Triangle
        /// <summary>
        /// Get coordinates for triangle test
        /// </summary>
        public static double[] Triangle()
        {
            double[] data = null;

            //data = new double[]
            //{
            //    20.5, 3.3,
            //    55.3, 30.3,
            //     5.3, 49.3
            //};

            data = new double[]
            {
                20.0, 3.0,
                55.0, 30.0,
                5.0, 49.0
                //,20.0, 3.0
            };

            return data;
        }
        #endregion

        #region Star
        /// <summary>
        /// Get coordinates for star test
        /// </summary>
        public static double[] Star()
        {
            double[] data = null;

            data = new double[]
            {
                11.11, 13.11, 
                50.11, 50.11, 
                 2.11, 23.11,
                38.11, 16.11,
                 7.11, 45.11,
                 11.11, 13.11
            };

            return data;
        }
        #endregion

        #region Crown
        /// <summary>
        /// Get coordinates for Crown test
        /// </summary>
        public static double[] Crown()
        {
            double[] data = null;

            data = new double[]
            {
                15, 55,
                45, 55,
                55, 15,
                40, 40,
                30, 10,
                20, 40,
                 5, 15
                 //,15, 55
            };

            return data;
        }
        #endregion

        #region Circle Pattern 1
        /// <summary>
        /// Calculate coordinates for Circle Pattern 1 test
        /// </summary>
        public static double[] CirclePattern1(double w, double h)
        {
            //return CirclePattern1(w, h, 3.0, 1.5);
            return CirclePattern1(w, h, 6.0, 3.0);
        }

        /// <summary>
        /// Calculate coordinates for Circle Pattern 1 test
        /// </summary>
        public static double[] CirclePattern1(double w, double h, double angleIncrement, double angleFanSize)
        {
            double startAngle = 0;
            double endAngle = 360;

            //double diffAngle = 3;
            //double oneLineAngleWidth = 1.5;

            double startX = w / 2;
            double startY = h / 2;
            double innerRadius = 20;
            double outterRadius = 180;

            int numberOfLine = (int)((endAngle - startAngle) / angleIncrement);
            double[] data = new double[numberOfLine * 8];

            for (int line = 0; line < numberOfLine; line++)
            {
                data[line * 8] = startX + Math.Sin(startAngle * Math.PI / 180) * innerRadius;
                data[line * 8 + 1] = startY + Math.Cos(startAngle * Math.PI / 180) * innerRadius;
                data[line * 8 + 2] = startX + Math.Sin(startAngle * Math.PI / 180) * outterRadius;
                data[line * 8 + 3] = startY + Math.Cos(startAngle * Math.PI / 180) * outterRadius;
                data[line * 8 + 4] = startX + Math.Sin((startAngle + angleFanSize) * Math.PI / 180) * outterRadius;
                data[line * 8 + 5] = startY + Math.Cos((startAngle + angleFanSize) * Math.PI / 180) * outterRadius;
                data[line * 8 + 6] = startX + Math.Sin((startAngle + angleFanSize) * Math.PI / 180) * innerRadius;
                data[line * 8 + 7] = startY + Math.Cos((startAngle + angleFanSize) * Math.PI / 180) * innerRadius;
                startAngle += angleIncrement;
            }

            return data;
        }
        #endregion

        #region Circle Pattern 2
        /// <summary>
        /// Calculate coordinates for Circle Pattern 2 test
        /// </summary>
        public static double[] CirclePattern2(double w, double h)
        {
            double startAngle = 0;
            double endAngle = 360;

            double diffAngle = 1;
            double oneLineDiff = 0.5;

            double startX = w / 2;
            double startY = h / 2;
            double innerRadius = 50;
            double outterRadius = 180;

            int numberOfLine = (int)((endAngle - startAngle) / diffAngle);
            double[] data = new double[numberOfLine * 8];

            for (int line = 0; line < numberOfLine; line++)
            {
                data[line * 8] = startX + Math.Sin(startAngle * Math.PI / 180) * innerRadius;
                data[line * 8 + 1] = startY + Math.Cos(startAngle * Math.PI / 180) * innerRadius;
                data[line * 8 + 2] = startX + Math.Sin(startAngle * Math.PI / 180) * outterRadius;
                data[line * 8 + 3] = startY + Math.Cos(startAngle * Math.PI / 180) * outterRadius;
                data[line * 8 + 4] = startX + Math.Sin(startAngle * Math.PI / 180) * outterRadius + oneLineDiff;
                data[line * 8 + 5] = startY + Math.Cos(startAngle * Math.PI / 180) * outterRadius + oneLineDiff;
                data[line * 8 + 6] = startX + Math.Sin(startAngle * Math.PI / 180) * innerRadius + oneLineDiff;
                data[line * 8 + 7] = startY + Math.Cos(startAngle * Math.PI / 180) * innerRadius + oneLineDiff;
                startAngle += diffAngle;
            }

            return data;
        }
        #endregion

        #region Complex 1
        public static double[] Complex1()
        {
            ComplexDataHelper.BuildCache(1);
            return ComplexDataHelper.GetComplexPolygon();
        }
        #endregion

        #region Complex 2
        public static double[] Complex2()
        {
            ComplexDataHelper.BuildCache(2);
            return ComplexDataHelper.GetComplexPolygon();
        }
        #endregion

        #region Complex data 3
        public static double[] Complex3()
        {
            ComplexDataHelper.BuildCache(3);
            return ComplexDataHelper.GetComplexPolygon();
        }
        #endregion

        #region two polygon in one path
        /// <summary>
        /// Get two polygon in one path data
        /// </summary>
        /// <returns></returns>
        public static double[][] TwoPolygonInOnePath()
        {
            return new double[][]
                {
                    new double[]
                    {
                        50,50,
                        230,150,
                        10,350
                        
                    },
                    new double[]
                    {
                        50,60,
                        220,150,
                        30,320
                    }
                };
        }
        #endregion

        #region Offset
        /// <summary>
        /// Translate the input data
        /// </summary>
        public static double[] Offset(double[] data, double tx, double ty)
        {
            for (int i = 0; i < data.Length; i += 2)
            {
                data[i] += tx;
                data[i + 1] += ty;
            }

            return data;
        }
        #endregion

        #region Scale
        /// <summary>
        /// Scale the input data by a zoom factor
        /// </summary>
        public static double[] Scale(double[] data, double factor)
        {
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = data[i] * factor;
            }

            return data;
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public TestFactory()
        { }
        #endregion
    }
}
