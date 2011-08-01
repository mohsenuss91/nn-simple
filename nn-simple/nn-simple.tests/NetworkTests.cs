using System;
using System.Collections.Generic;
using Moq;
using nn_simple.Layer;
using nn_simple.Network;
using NUnit.Framework;
using SharpTestsEx;

namespace nn_simple.tests
{
    [TestFixture]
    public class NetworkTests
    {
        [Test]
        public void create_simple_network()
        {
            var network = new Network.Network();
            network.Layers = new List<ILayer>();
            var inputLayer = new Mock<ILayer>().Object;
            inputLayer.Type = LayerType.Input;
            var hiddenLayer = new Mock<ILayer>().Object;
            hiddenLayer.Type = LayerType.Hidden;
            var outputLayer = new Mock<ILayer>().Object;
            outputLayer.Type = LayerType.Output;

            network.AddLayer(inputLayer, hiddenLayer, outputLayer);

            network.Layers.Count.Should().Be.EqualTo(3);
        }

        [Test]
        public void can_be_only_one_input_layer()
        {
            var network = new Network.Network();
            network.Layers = new List<ILayer>();
            var inputLayer1 = new Mock<ILayer>().Object;
            inputLayer1.Type = LayerType.Input;
            var inputLayer2 = new Mock<ILayer>().Object;
            inputLayer2.Type = LayerType.Input;

            network.AddLayer(inputLayer1, inputLayer2);

            Executing.This(network.StartTrain).Should().Throw();
            Executing.This(network.StartTrain).Should().Throw<ApplicationException>();
            Executing.This(network.StartTrain).Should().Throw<ApplicationException>()
                                        .Exception.Message.Should().Be.EqualTo("There can be only one input layer and one output");
        }

        [Test]
        public void can_be_only_one_output_layer()
        {
            var network = new Network.Network();
            network.Layers = new List<ILayer>();
            var outputLayer1 = new Mock<ILayer>().Object;
            outputLayer1.Type = LayerType.Output;
            var outputLayer2 = new Mock<ILayer>().Object;
            outputLayer2.Type = LayerType.Output;

            network.AddLayer(outputLayer1, outputLayer2);

            Executing.This(network.StartTrain).Should().Throw();
            Executing.This(network.StartTrain).Should().Throw<ApplicationException>();
            Executing.This(network.StartTrain).Should().Throw<ApplicationException>()
                                        .Exception.Message.Should().Be.EqualTo("There can be only one input layer and one output");
        }
    }
}
