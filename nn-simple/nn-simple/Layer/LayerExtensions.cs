using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nn_simple.Network;
using nn_simple.Neuron;

namespace nn_simple.Layer
{
    public static class LayerExtensions
    {
        public static ILayer GetOutputLayer(this List<ILayer> layers)
        {
            return (ILayer)(from layer in layers
                            where layer.Type == LayerType.Output
                            select layer);
        }

        public static ILayer GetInputLayer(this List<ILayer> layers)
        {
            return (ILayer)(from layer in layers
                            where layer.Type == LayerType.Input
                            select layer);
        }

        public static List<ILayer> GetHiddenLayers(this List<ILayer> layers)
        {
            return (List<ILayer>)(from layer in layers
                                  where layer.Type == LayerType.Hidden
                                  select layer);
        }

        public static IDictionary<INeuralSignal, INeuron> GetNeuronsOutputLayer(this List<ILayer> layers)
        {
            var outputLayers = GetOutputLayer(layers);
            return (IDictionary<INeuralSignal, INeuron>)
                                            (from neuron in outputLayers.Neurons
                                             select neuron).ToDictionary(q => q, o => o);
        }
    }
}
