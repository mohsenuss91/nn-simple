

using System;
using nn_simple.Neuron;

namespace nn_simple.Network
{
    public class Target : ITarget
    {
        public double Output { get; set; }
        public Target(double value){}
    }
}
