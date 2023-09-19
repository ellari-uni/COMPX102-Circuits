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
    public class InputSource : Gate
    {
        //Boolean to store whether the gate is active
        bool active = false;
        /// <summary>
        /// Class constructor, adds one pin 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public InputSource(int x, int y)
        {
            //Add output pin to the gate
            pins.Add(new Pin(this, false, 20));
            //Move the gate to provided x and y
            MoveTo(x, y);

        }
        /// <summary>
        /// Draw the gate on the form
        /// </summary>
        /// <param name="paper"></param>
        public override void Draw(Graphics paper)
        {
            //Set initial value to null
            Image image = null;
            //Checking selected 
            switch (selected)
            {
                //If is selected
                case true:
                    //If gate is active, set to SelectedActive image, else set to SelectedInactive
                    image = active ? Properties.Resources.InputSrcActSelec : Properties.Resources.InputSrcInacSelec;
                    break;
                //If is not selected
                case false:
                    //If gate is active, set to Active image, else set to inactive image
                    image = active ? Properties.Resources.InputSrcAct : Properties.Resources.InputSrcInac;
                    break;
            }
            //Draw each pin in the pin list
            foreach (Pin p in pins) p.Draw(paper);
            
            //Draw the image of the gate on the form 
            paper.DrawImage(image, Left, Top);
        }
        /// <summary>
        /// Move the gate and it's pins to a provided location
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public override void MoveTo(int x, int y)
        {
            //Call Gate.MoveTo(int, int) method
            base.MoveTo(x, y);
            //Move pin x and y, with appropriate offset
            pins[0].X = x + (int)(2 * WIDTH);
            pins[0].Y = y + (GAP /2)+ (HEIGHT / 2);
            //Write where the gate is moved to, and where the pin is moved to, to the console
            Console.WriteLine(x + " " + y + "\n" + pins[0].X + " " + pins[0].Y);
        }
        public override bool Evaluate()
        {   
            return IsOn;
        }
        /// <summary>
        /// Gets and sets whether or not the gate is turned on
        /// </summary>
        public bool IsOn
        {
            get { return active; }
            set { active = value; }
        }
        public override Gate Clone()
        {
            //Create new inputsource for the clone, at this gates position
            InputSource clone = new InputSource(Position[0], Position[1]);
            //Create new pin list for the new list of pins
            List<Pin> pins = new List<Pin>();

            //For each pin in the current gate's pins list
            foreach (Pin pin in this.pins)
            {
                //Add new pin to the list, passing the current gate's values to the constructor 
                pins.Add(new Pin(pin.Owner, pin.IsInput, 20));
            }
            //Set the clone's pins list to the new list
            clone.pins = pins;
            //Return the clone
            return clone;
        }
    }
}
