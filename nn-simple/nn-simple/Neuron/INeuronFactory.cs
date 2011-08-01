using System;
using System.Collections.Generic;

namespace nn_simple.Neuron
{
    public interface INeuronFactory
    {
        IEnumerable<INeuron> CreateNeuronCollection(int neurons);
    }
}
