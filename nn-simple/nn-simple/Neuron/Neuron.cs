using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nn_simple.Neuron
{
    public class Neuron : INeuron
    {
        public double Output { get; set; }
        public IDictionary<INeuralSignal, INeuralSignalWeight> Inputs { get; set; }

        public Func<double[], double> ActivationFunction { get; set; }

        public void RunActivationFunction()
        {
            throw new NotImplementedException();
        }
    }
}
