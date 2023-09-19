﻿using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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
        Gate anchor = null;
        int[] anchorOrigins = new int[2];
        public Compound(int x, int y)
        {
            left = x;
            top = y;
        }
        public void AddGate(Gate g)
        {
            g.DiffX = g.Left - Left;
            g.DiffY = g.Top - Top;
            gates.Add(g);
            g.Selected = true;
            if (anchor is null) anchor = g;
            else if (g.Left < anchor.Left) anchor = g;
            if(anchor != null)
            {
                anchorOrigins = new int[] { anchor.Left, anchor.Top };
                g.DiffX = g.Left - anchorOrigins[0];
                g.DiffY = g.Top - anchorOrigins[1];
            }
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
        public Gate Anchor
        {
            get { return anchor; }
            set { anchor = value; }
        }
        
        public override void MoveTo(int x, int y)
        {
            
            anchor.MoveTo(x, y);
            foreach (Gate g in gates)
            {
                g.Selected = true;
                if (g != anchor) g.MoveTo(x + (g.DiffX), y + (g.DiffY));
            }
        }
        

    }
}
