using Mikulas.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mikulas.Entities
{
    public class PresentFactory : IToyFactory
    {
        public Color PresentColorRibbon { get; set; }
        public Color PresentColorBox { get; set; }
        public Toy CreateNew()
        {
            return new Present(PresentColorRibbon, PresentColorBox);
        }
    }
}
