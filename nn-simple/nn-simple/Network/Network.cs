using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using nn_simple.Layer;
using nn_simple.Neuron;
using nn_simple.Utils;

namespace nn_simple.Network
{
    public class Network : INetwork
    {
        public List<ILayer> Layers { get; set; }

        public List<ITarget> Targets { get; set; }

        public double Rate { get; set; }

        public double Momentum { get; set; }

        public IFunctionHelper FunctionHelper { get; set; }

        public Network()
        {
        }

        public Network(List<ILayer> layers, List<ITarget> targets, IFunctionHelper functionhelper, double rate, double momentum)
        {
            Layers = layers;
            Targets = targets;
            FunctionHelper = functionhelper;
            Rate = rate;
            Momentum = momentum;
        }

        public void AddLayer(ILayer layer)
        {
            Layers.Add(layer);
        }

        public void AddLayer(params ILayer[] layers)
        {
            Layers.AddRange(layers);
        }

        public void StartTrain(IEnumerable<IDataPattern> pattern, int interations)
        {
            LoadTargets(pattern);
            CheckTargetData();
            CheckLayerCollection();

            for (var i = 0; i < interations; i++)
            {
                var error = 0.0;
                foreach (var p in pattern)
                {
                    //Update Inputs????
                    error = error + BackPropagation();
                    Console.Write(error);
                    Console.WriteLine();
                }

            }
        }

        private void Update(double[] inputs)
        {
            //Activate input layer
            foreach (var neuron in Layers.GetInputLayer().Neurons)
            {
                
            }
        }

        private void LoadTargets(IEnumerable<IDataPattern> patterns)
        {
            foreach (var pattern in patterns)
            {
                Targets.Add(new Target(pattern.Target));
            }
        }

        public double BackPropagation()
        {

            //Calculate error of outputs            
            var outputneurons = Layers.GetOutputLayer().Neurons;
            foreach (var neuron in outputneurons)
            {
                var error = Targets[outputneurons.IndexOf(neuron)].Output - neuron.Output;
                neuron.Delta = FunctionHelper.Sigmoid(neuron.Output) * error;
            }

            //Calculate errors hidden layers
            foreach (var layer in Layers)
            {
                if (layer.Type != LayerType.Hidden)
                    foreach (var neuron in layer.Neurons)
                    {
                        //error
                        var error = 0.0;
                        foreach (var outputneuron in outputneurons)
                            error = error + outputneuron.Delta * neuron.Inputs[outputneuron].Weight;

                        neuron.Delta = FunctionHelper.Dsigmoid(neuron.Output) * error;
                    }
            }

            //Update output weights
            var hiddenLayers = Layers.GetHiddenLayers();
            foreach (var layer in hiddenLayers)
            {
                foreach (var neuron in layer.Neurons)
                {
                    foreach (var outputneuron in outputneurons)
                    {
                        var change = outputneuron.Delta * neuron.Output;
                        outputneuron.Inputs[neuron].Weight += Rate * change +
                                                                Momentum * outputneuron.Inputs[neuron].ChangeWeight;
                        outputneuron.Inputs[neuron].ChangeWeight = change;
                    }
                }
            }

            //Update input weights
            var inputneurons = Layers.GetInputLayer().Neurons;
            foreach (var inputneuron in inputneurons)
            {
                foreach (var hiddenlayer in hiddenLayers)
                {
                    foreach (var hiddenneuron in hiddenlayer.Neurons)
                    {
                        var change = hiddenneuron.Delta * inputneuron.Output;
                        inputneuron.Inputs[hiddenneuron].Weight += Rate * change +
                                                                  Momentum * inputneuron.Inputs[hiddenneuron].ChangeWeight;
                        inputneuron.Inputs[hiddenneuron].ChangeWeight = change;
                    }
                }
            }

            //Calculate error
            var errorTarget = 0.0;
            var outputNeuronsDic = Layers.GetNeuronsOutputLayer();
            foreach (var target in Targets)
            {
                var potOut = Math.Pow(2, (target.Output - outputNeuronsDic[target].Output));
                errorTarget += 0.5 * (target.Output - potOut);
            }
            return errorTarget;
        }

        private void CheckTargetData()
        {
        }

        private void CheckLayerCollection()
        {
            var input = from p in Layers
                        where p.Type == LayerType.Input
                        select p;

            var output = from p in Layers
                         where p.Type == LayerType.Output
                         select p;

            if (input.Count() > 1 || output.Count() > 1)
                throw new ApplicationException("There can be only one input layer and one output");
        }
    }
}
