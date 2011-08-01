using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nn_simple.Neuron;

namespace nn_simple.Layer
{
    public interface ILayer
    {
        List<INeuron> Neurons { get; set; }
        LayerType Type { get; set; }
        void Calculate();        
    }    
}
