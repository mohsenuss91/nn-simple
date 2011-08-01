using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nn_simple.Neuron
{
    public interface INeuron : INeuralSignal, INeuralImput, INeuralBias
    {
        Func<double[], double> ActivationFunction { get; set; }
        void RunActivationFunction();
        double Error { get; set; }
    }
}
