﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MathNet.Numerics.LinearAlgebra.Generic;

namespace MathNet.Numerics.UnitTests.OptimizationTests
{
    public static class RosenbrockFunction
    {
        public static double Value(Vector<double> input)
        {
            return Math.Pow((1 - input[0]), 2) + 100 * Math.Pow((input[1] - input[0] * input[0]), 2);
        }

        public static Vector<double> Gradient(Vector<double> input)
        {
            Vector<double> output = new MathNet.Numerics.LinearAlgebra.Double.DenseVector(2);
            output[0] = -2 * (1 - input[0]) + 200 * (input[1] - input[0] * input[0]) * (-2 * input[0]);
            output[1] = 2 * 100 * (input[1] - input[0] * input[0]);
            return output;
        }

        public static Matrix<double> Hessian(Vector<double> input)
        {

            Matrix<double> output = new MathNet.Numerics.LinearAlgebra.Double.DenseMatrix(2,2);
            output[0, 0] = 2 - 400 * input[1] + 1200 * input[0] * input[0];
            output[1, 1] = 200;
            output[0, 1] = -400 * input[0];
            output[1, 0] = output[0, 1];
            return output;
        }
    }
}
