using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nn_simple.Neuron;
using NUnit.Framework;
using SharpTestsEx;

namespace nn_simple.tests.Neuron
{
    [TestFixture]
    public class NeuronFactoryTests
    {
        [Test]
        public void create_a_neurons_collections()
        {
            var factory = new NeuronFactory();
            var collection = factory.CreateNeuronCollection(100);

            collection.Count().Should().Be.EqualTo(100);
        }
    }
}