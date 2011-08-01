using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nn_simple.Neuron;

namespace nn_simple.Layer
{
    public class Layer : ILayer
    {
        public List<INeuron> Neurons { get; set; }

        public LayerType Type { get; set; }

        public void Calculate()
        {
            throw new NotImplementedException();
        }
    }
}
