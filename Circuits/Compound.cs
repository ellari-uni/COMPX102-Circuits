using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuits
{
    public class Compound : Gate
    {
        List<Gate> gates = new List<Gate>();

        public static List<Gate> operator + (Compound cmd, Gate gate)
        {
            cmd.gates.Add(gate);
            return cmd.gates;
        }

        public override void Draw(Graphics paper)
        { 
            foreach(Gate gate in gates)
            {
                gate.Draw(paper);
            }
        }

        public override bool Evaluate()
        {
            List<OutputLamp> lamps = new List<OutputLamp>();
            foreach (Gate gate in gates)
            {
                if (gate is OutputLamp lamp) lamps.Add(lamp);
            }

            foreach (Gate gate in gates) if (gate is OutputLamp lamp) lamps.Add(lamp);

        }
    }
}
