

namespace nn_simple.Neuron
{
    public interface INeuralBias
    {
        double BiasWeight { get; set; }
        double Delta { get; set; }
        void ApplyDelta();
    }
}
