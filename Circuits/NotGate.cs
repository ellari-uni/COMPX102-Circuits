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
    public class NotGate : Gate
    {
        public NotGate(int x, int y) {
            pins.Add(new Pin(this, true, 20));
            //Add the output pin to the gate
            pins.Add(new Pin(this, false, 20));
            //move the gate and the pins to the position passed in
            MoveTo(x, y);
        }
        /// <summary>
        /// Draw the gate on the form
        /// </summary>
        /// <param name="paper"></param>
        public override void Draw(Graphics paper)
        {
            //If the gate is selected, set the image to AllRed, else set to NotGate
            Image image = selected ? Properties.Resources.NotGateAllRed : Properties.Resources.NotGate;
            //Foreach pin in the pin list, draw on the paper
            foreach (Pin p in pins) p.Draw(paper);
            //Draw the image on the paper
            paper.DrawImage(image, Left, Top);

        }
        /// <summary>
        /// Moves the gate and pins, with appropriate offset for the pins
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public override void MoveTo(int x, int y)
        {
            //Call the Gate.MoveTo(int, int) method
            base.MoveTo(x, y);
            //Move the pins with appropriate offset 
            pins[0].X = x + 5 - GAP;
            pins[0].Y = y + (HEIGHT / 2) + (GAP /2);
            pins[1].X = x + WIDTH + GAP + (GAP / 2);
            pins[1].Y = y + (HEIGHT / 2) + (GAP / 2);
            
        }
        public override bool Evaluate()
        {
            //If gate input is true, return false
            //If gate input is false, return true
            return !pins[0].InputWire.FromPin.Owner.Evaluate();
        }
        public override Gate Clone()
        {
            //Create new notgate object as clone, passing current position 
            NotGate clone = new NotGate(Position[0], Position[1]);
            //Create new pin list for the clone's list of pins
            List<Pin> pins = new List<Pin>();
            //for each pin in the current gate's list of pins
            foreach (Pin pin in this.pins)
            {
                //Add new pin to the clone list, passing current gate's properties
                pins.Add(new Pin(pin.Owner, pin.IsInput, 20));
            }
            //Set the clone's pins list to the created list
            clone.pins = pins;
            //Return the clone
            return clone;
        }
    }
}
