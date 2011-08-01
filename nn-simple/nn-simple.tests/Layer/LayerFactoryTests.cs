using System.Collections.Generic;
using System.Linq;
using Moq;
using nn_simple.Layer;
using nn_simple.Neuron;
using NUnit.Framework;
using SharpTestsEx;

namespace nn_simple.tests.Layer
{
    [TestFixture]
    public class LayerFactoryTests
    {
        [Test]
        public void create_a_input_layer_with_100_neuron()
        {
            var factory = new LayerFactory();

            var mockFactoryNeuron = new Mock<INeuronFactory>();
            mockFactoryNeuron.Setup(a => a.CreateNeuronCollection(It.IsAny<int>()))
                                        .Returns(GetNeuronCollectionTest(100));

            factory.neuronFactory = mockFactoryNeuron.Object;
            var layer = factory.CreateLayer(100, LayerType.Input);

            layer.Type.Should().Be.Equals(LayerType.Input);
            layer.Neurons.Count().Should().Be.EqualTo(100);
        }

        private IEnumerable<INeuron> GetNeuronCollectionTest(int neurons)
        {
            for (int i = 0; i < neurons; i++)
            {
                yield return new nn_simple.Neuron.Neuron();
            }
        }
    }
}
