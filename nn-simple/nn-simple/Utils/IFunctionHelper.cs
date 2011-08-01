using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nn_simple.Utils
{
    public interface IFunctionHelper
    {
        double Sigmoid(double value);
        double Dsigmoid(double value);
    }
}
