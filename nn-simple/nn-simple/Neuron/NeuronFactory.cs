using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nn_simple.Neuron
{
    public class NeuronFactory : INeuronFactory
    {
        public IEnumerable<INeuron> CreateNeuronCollection(int neurons)
        {
            for (int i = 0; i < neurons; i++)
            {
                yield return new Neuron();
            }
        }
    }
}
