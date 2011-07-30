using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nn_simple.Layer
{
    public interface ILayer
    {
        LayerType Type { get; set; }
        void Calculate();        
    }    
}
