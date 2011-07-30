using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using nn_simple.Layer;

namespace nn_simple.Network
{
    public class Network : INetwork
    {
        public List<ILayer> Layers { get; set; }

        public Network()
        {
            Layers = new List<ILayer>();
        }

        public void AddLayer(ILayer layer)
        {
            Layers.Add(layer);
        }

        public void AddLayer(params ILayer[] layers)
        {
            Layers.AddRange(layers);
        }

        public void Run()
        {
            CheckLayerCollection();
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
