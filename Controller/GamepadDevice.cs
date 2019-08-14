using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoL_Observer_Tool.Controller
{
    class GamepadDevice
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name + " (" + Guid + ")";
        }
    }
}
