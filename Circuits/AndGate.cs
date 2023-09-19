/*
 * NAME: Hayden Gillanders
 * ID NUMBER: 1636274
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuits
{
    /// <summary>
    /// This class implements an AND gate with two inputs
    /// and one output.
    /// </summary>
    public class AndGate : Gate
    {
        

        /// <summary>
        /// Initialises the Gate.
        /// </summary>
        /// <param name="x">The x position of the gate</param>
        /// <param name="y">The y position of the gate</param>
        public AndGate(int x, int y)
        {
            //Add the two input pins to the gate
            pins.Add(new Pin(this, true, 20));
            pins.Add(new Pin(this, true, 20));
            //Add the output pin to the gate
            pins.Add(new Pin(this, false, 20));
            //move the gate and the pins to the position passed in
            MoveTo(x, y);
        }
        /// <summary>
        /// Move method to move the gate and its pins
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public override void MoveTo(int x, int y)
        {
            //Call base move method
            base.MoveTo(x, y);
            //Set all pins to location
            pins[0].X = x - GAP;
            pins[0].Y = y + 5 + GAP;
            pins[1].X = x - GAP;
            pins[1].Y = y + 5 + HEIGHT - GAP;
            pins[2].X = x + 10 + WIDTH + GAP;
            pins[2].Y = y + 5 + HEIGHT / 2;
        }

        /// <summary>
        /// Draws the gate in the normal colour or in the selected colour.
        /// </summary>
        /// <param name="paper"></param>
        public override void Draw(Graphics paper)
        {
            Image image;
            //Check if the gate has been selected
            if (selected)
            {
                image = Properties.Resources.AndGateAllRed;
            }
            else
            {
                image = Properties.Resources.AndGate;
            }
            //Draw each of the pins
            foreach (Pin p in pins)
                p.Draw(paper);

            

            //Note: You can also use the images that have been imported into the project if you wish,
            //      using the code below.  You will need to space the pins out a bit more in the constructor.
            //      There are provided images for the other gates and selected versions of the gates as well.
            paper.DrawImage(image, Left, Top);


        }
        /// <summary>
        /// Evaluate gate, returns true if both pins are true
        /// </summary>
        /// <returns></returns>
        public override bool Evaluate()
        {
            //Function to check if its true, using pins list as param
            Func<List<Pin>, bool> isTrue = pins =>
            {
                foreach (Pin p in pins)
                { 
                    if (p.InputWire != null && !(p.InputWire.FromPin.Owner.Evaluate() == true) ) return false;
                }
                return true;
            };
            //Return functioncall
            return isTrue(pins);
        }
        /// <summary>
        /// Returns a copy of the gate and it's pins 
        /// </summary>
        /// <returns></returns>
        public override Gate Clone()
        {
            //create new and gate as a clone, using the current gate's position
            AndGate clone = new AndGate(Position[0], Position[1]);
            //Create new list of pins for the new gate
            List<Pin> pins = new List<Pin>();

            //Foreach pin in the current object's list of pins
            foreach (Pin pin in this.pins)
            {
                //Add a new pin, using the current pin's parameters 
                pins.Add(new Pin(pin.Owner, pin.IsInput, 20));
            }
            //Add the new list of pins to the clone's pin list
            clone.pins = pins;
            //return the clone 
            return clone;
        }

    }
}
