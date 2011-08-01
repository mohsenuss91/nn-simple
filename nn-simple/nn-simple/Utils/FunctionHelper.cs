using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nn_simple.Utils
{
    public class FunctionHelper : IFunctionHelper
    {
        public double Sigmoid(double value)
        {
            return 2 / (1 + Math.Exp(-2 * value)) - 1;
        }

        public double Dsigmoid(double value)
        {
            var s = Sigmoid(value);
            return 1 - (Math.Pow(s, 2));
        }
    }
}
