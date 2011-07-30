using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nn_simple.Layer;

namespace nn_simple.Network
{
    public interface INetwork
    {
        List<ILayer> Layers { get; set; }
        void AddLayer(ILayer layer);
        void AddLayer(params ILayer[] layers);
        void Run();
    }
}
