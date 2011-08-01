using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nn_simple.Layer;
using nn_simple.Neuron;
using nn_simple.Utils;

namespace nn_simple.Network
{
    public interface INetwork
    {
        List<ILayer> Layers { get; set; }
        List<ITarget> Targets { get; set; }
        double Rate { get; set; }
        double Momentum { get; set; }
        void AddLayer(ILayer layer);
        void AddLayer(params ILayer[] layers);
        void StartTrain(IEnumerable<IDataPattern> pattern, int interations);
        double BackPropagation();
    }
}
