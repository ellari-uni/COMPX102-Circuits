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
    public class OutputLamp : Gate
    {
        //Variable to store whether the lamp is activated
        bool active = false;
        public OutputLamp(int x, int y)
        {
            //Add one input pin, and no output pins
            pins.Add(new Pin(this, true, 20));
            //Move to provided values
            MoveTo(x, y);
        }
        /// <summary>
        /// Gets and sets active status of the lamp
        /// </summary>
        public bool Active
        {
            get { return active; }
            set { active = value; }
        }
        /// <summary>
        /// Draw the gate on the paper
        /// </summary>
        /// <param name="paper"></param>
        public override void Draw(Graphics paper)
        {
            //set initial value of image to null 
            Image image = null;
            //Checking selected
            switch (selected)
            {
                //If selected is true
                case true:
                    //If gate is active, set to OnSelected, else set to OffSelected
                    image =  active ? Properties.Resources.OutLampOnSelected : Properties.Resources.OutLampOffSelected;
                    break;
                //If selected is false
                case false:
                    //If gate is active, set to outLampOn, else set to outLampOff
                    image = active ? Properties.Resources.OutLampOn : Properties.Resources.OutLampOff;
                    break;
            }
            //For each pin in the pins list, draw on paper
            foreach (Pin p in pins) p.Draw(paper); 
            //Draw image on the paper
            paper.DrawImage(image, Left, Top);
        }
        /// <summary>
        /// Move gate to location, and offset pins appropriately
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public override void MoveTo(int x, int y)
        {
            //Call Gate.MoveTo(int, int)
            base.MoveTo(x, y);
            //Offset pins
            pins[0].X = x - 5;
            pins[0].Y = y + (HEIGHT / 2) + GAP + 3;
        }
        public override bool Evaluate()
        {
            //Return true if input is true, or return false if false
            return pins[0].InputWire.FromPin.Owner.Evaluate();
        }
        public override Gate Clone()
        {
            //Create new output lamp object at current gate location
            OutputLamp clone = new OutputLamp(Position[0], Position[1]);
            //Create new list of pins for clone
            List<Pin> pins = new List<Pin>();

            //For each pin in current pins list
            foreach (Pin pin in this.pins)
            {
                //Add new pin to the pins list of clone, passing current gate pin's properties
                pins.Add(new Pin(pin.Owner, pin.IsInput, 20));
            }
            //Set the clone object pins list to the new pins list
            clone.pins = pins;
            return clone;
        }
    }
}
