using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week08.Abstractions;

namespace Week08.Entities
{
    class PresentFactory : IToyFactory
    {
        public Color ribbon { get; set; }
        public Color box { get; set; }
        public Toy CreateNew()
        {
            return new Present(ribbon, box);
        }
    }
}
