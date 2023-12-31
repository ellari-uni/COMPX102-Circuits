﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuits
{
    public class OrGate : Gate
    {
        public OrGate(int x, int y)
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
        /// Draw the gate on the paper with appropriate image sprite
        /// </summary>
        /// <param name="paper"></param>
        public override void Draw(Graphics paper)
        {
            //If the gate is selected, set image to AllRed, else set image to OrGate
            Image image = selected ? Properties.Resources.OrGateAllRed : Properties.Resources.OrGate;

            //For each pin in pins, draw the pin on the paper
            foreach (Pin p in pins) p.Draw(paper);
            //Draw the image on the paper
            paper.DrawImage(image, Left, Top);

        }
        /// <summary>
        /// Move the gate with appropriate pin offsets
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public override void MoveTo(int x, int y)
        {
            //Call Gate.MoveTo(int, int)
            base.MoveTo(x, y);
            //Set all X and Y with appropriate offsets
            pins[0].X = x + 5 - GAP;
            pins[0].Y = y + GAP;
            pins[1].X = x + 5 - GAP;
            pins[1].Y = y + 12 + HEIGHT - GAP;
            pins[2].X = x + 20 + WIDTH + GAP;
            pins[2].Y = y + 5 + HEIGHT / 2;
        }
        public override bool Evaluate()
        {
            //Function to check if the gate evaluates true
            Func<List<Pin>, bool> isTrue = pins =>
            {
                //For each pin in pins
                foreach (Pin p in pins)
                {
                    //if any of the pins are true, return true
                    if (p.InputWire.FromPin.Owner.Evaluate() == true) return true;
                }
                //else return false
                return false;
            };
            //Call function to check if true
            return isTrue(pins);
        }
        public override Gate Clone()
        {
            //Create new orgate object for the clone,passing current gate position
            OrGate clone = new OrGate(Position[0], Position[1]);
            //Create new pin list for the clone's pins 
            List<Pin> pins = new List<Pin>();
            //For each pin in the current gate's list of pins
            foreach (Pin pin in this.pins)
            {
                //Add new pin to the clone list, passing current gate pin properties into constructor
                pins.Add(new Pin(pin.Owner, pin.IsInput, 20));
            }
            //Set the clone's pins list to the newly created pin list
            clone.pins = pins;
            
            return clone;
        }
    }
}
