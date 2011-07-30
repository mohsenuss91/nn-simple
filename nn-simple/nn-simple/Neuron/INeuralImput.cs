using System.Collections.Generic;

namespace nn_simple.Neuron
{
    public interface INeuralImput
    {
        IDictionary<INeuralSignal, INeuralSignalWeight> Inputs { get; set; }
    }
}
