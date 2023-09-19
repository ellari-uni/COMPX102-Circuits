/*
 * NAME: Hayden Gillanders
 * ID NUMBER: 1636274
 */

using System;
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
        //Create new list of gates in the compound gate
        List<Gate> gates = new List<Gate>();
        //Set anchor gate to null
        Gate anchor = null;
        //Create new int array to store original anchor origin points
        int[] anchorOrigins = new int[2];
        /// <summary>
        /// When a new compound is created with an x and y value, initialize the compound to provided x and y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Compound(int x, int y)
        {
            left = x;
            top = y;
        }
        /// <summary>
        /// Add a gate to the list of gates in the compound
        /// </summary>
        /// <param name="g"></param>
        public void AddGate(Gate g)
        {
            //Set the current X difference to the difference between the Compound x and the gate X
            g.DiffX = g.Left - Left;
            //Set the current Y difference to the difference between the Compound y and the gate Y
            g.DiffY = g.Top - Top;
            //Add the provided gate to the list
            gates.Add(g);
            //Set selected of the current gate to true
            g.Selected = true;
            //If there is no anchor, set provided gate to anchor
            if (anchor is null) anchor = g;
            //Else if there is an anchor, if the current gate is further left than the previous anchor, set the anchor to current gate
            else if (g.Left < anchor.Left) anchor = g;
            //If anchor has a value
            if(anchor != null)
            {
                //Set origins of the anchor to the current anchor left and anchor Top 
                anchorOrigins = new int[] { anchor.Left, anchor.Top };
                //Set the current gate x difference to the difference between the anchor x and gate x
                g.DiffX = g.Left - anchorOrigins[0];
                //set the current gate y difference to the difference between the anchor y and gate y
                g.DiffY = g.Top - anchorOrigins[1];
            }
        }
        /// <summary>
        /// Draw the compound on the canvas
        /// </summary>
        /// <param name="paper"></param>
        public override void Draw(Graphics paper)
        { 
            //Foreach gate in the gate list
            foreach(Gate gate in gates)
            {
                //Call the gate's draw method
                gate.Draw(paper);
            }
        }
        /// <summary>
        /// Evalutate the compound
        /// </summary>
        /// <returns></returns>
        public override bool Evaluate()
        {
            //Create list of output lamps in the compound
            List<OutputLamp> lamps = new List<OutputLamp>();
            //Function to check if any of the lamps are active
            Func<List<OutputLamp>, bool> AnyCheck = lampsLocal =>
            {
                foreach (OutputLamp output in lampsLocal)
                {
                    if (output.Active) return true;
                }
                return false;
            };

            //For each gate in the list of gates, if the gate is an outputlamp, add the gate to the list of lamps
            foreach (Gate gate in gates) if (gate is OutputLamp lamp) lamps.Add(lamp);
            //Foreach lamp in the output lamp list, evaluate it and set it's active value to the result
            foreach (OutputLamp lamp in lamps) lamp.Active = lamp.Evaluate();
            //Return true if any of the lamps are true, and false if none are true
            return AnyCheck(lamps);

        }

        public override Gate Clone()
        {
            //Create new compound at current position
            Compound cmpd = new Compound(Position[0], Position[1]);
            //Create new list of gates in the compound
            List<Gate> newGates = new List<Gate>();
            //Foreach Gate in the compound
            foreach(Gate g in gates)
            {
                //Clone the gate, and add it to the new list of gates
                newGates.Add(g.Clone());
            }
            //Set the clone gates list to the processed new list
            cmpd.gates = newGates;
            //Return the final compound
            return cmpd;
        }
        /// <summary>
        /// Property that returns the list of gates in the compound
        /// </summary>
        public List<Gate> Gates
        {
            get { return gates; }
            set { gates = value; }
        }
        /// <summary>
        /// Move method for whole compound
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public override void MoveTo(int x, int y)
        {
            //Move the anchor to the mouse position
            anchor.MoveTo(x, y);
            //Foreach gate in the compound
            foreach (Gate g in gates)
            {
                //Select it 
                g.Selected = true;
                //If the gate is not the anchor, move it to the provided x and y, offset by its original offset
                if (g != anchor) g.MoveTo(x + (g.DiffX), y + (g.DiffY));
            }
        }
        

    }
}
