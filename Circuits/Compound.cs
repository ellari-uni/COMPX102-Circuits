using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuits
{
    public class Compound : Gate
    {
        List<Gate> gates = new List<Gate>();

        public static void operator + (List<Gate> gates, Gate gate)
        {
            gates.Add(gate);
            return gates;
        }
    }
}
