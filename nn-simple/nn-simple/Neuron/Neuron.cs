using System;
using System.Collections.Generic;

namespace nn_simple.Neuron
{
    public class Neuron : INeuron
    {
        public double Output { get; set; }
        public double Bias { get; set; }
        public double Error { get; set; }
        public double Delta { get; set; }

        public IDictionary<INeuralSignal, INeuralSignalWeight> Inputs { get; set; }

        public Func<double[], double> ActivationFunction { get; set; }

        public void RunActivationFunction()
        {
            throw new NotImplementedException();
        }
    }
}
