using nn_simple.Neuron;

namespace nn_simple.Layer
{
    public interface ILayerFactory
    {
        INeuronFactory neuronFactory { get; set; }
        ILayer CreateLayer(int neurons, LayerType type);
    }
}
