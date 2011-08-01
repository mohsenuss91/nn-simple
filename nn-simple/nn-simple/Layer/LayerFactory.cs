using System.Collections.Generic;
using nn_simple.Neuron;

namespace nn_simple.Layer
{
    public class LayerFactory : ILayerFactory
    {
        public INeuronFactory neuronFactory { get; set; }

        public ILayer CreateLayer(int neurons, LayerType type)
        {
            var layer = new Layer();
            layer.Type = type;
            layer.Neurons = (List<INeuron>) neuronFactory.CreateNeuronCollection(neurons);
            return layer;
        }        
    }
}
