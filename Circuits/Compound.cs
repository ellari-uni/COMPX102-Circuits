using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Circuits
{
    public class Compound : Gate
    {
        List<Gate> gates = new List<Gate>();

        public Compound(int x, int y)
        {
            left = x;
            top = y;
        }
        public void AddGate(Gate g)
        {
            gates.Add(g);
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
            Func<List<OutputLamp>, bool> AnyCheck = lampsLocal =>
            {
                foreach (OutputLamp output in lampsLocal)
                {
                    if (output.Active) return true;
                }
                return false;
            };
            foreach (Gate gate in gates) if (gate is OutputLamp lamp) lamps.Add(lamp);
            foreach (OutputLamp lamp in lamps) lamp.Active = lamp.Evaluate();
            return AnyCheck(lamps);

        }

        public override Gate Clone()
        {
            Compound cmpd = new Compound(Position[0], Position[1]);
            List<Gate> newGates = new List<Gate>();
            foreach(Gate g in gates)
            {
                newGates.Add(g.Clone());
            }

            cmpd.gates = newGates;

            return cmpd;
        }

        public List<Gate> Gates
        {
            get { return gates; }
            set { gates = value; }
        }
    }
}
