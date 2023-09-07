using System;
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

        public override void Draw(Graphics paper)
        {
            Image image = selected ? Properties.Resources.OrGateAllRed : Properties.Resources.OrGate;

            foreach (Pin p in pins) p.Draw(paper);
            paper.DrawImage(image, Left, Top);

        }

        public override void MoveTo(int x, int y)
        {
            base.MoveTo(x, y);
            pins[0].X = x + 5 - GAP;
            pins[0].Y = y + GAP;
            pins[1].X = x + 5 - GAP;
            pins[1].Y = y + 12 + HEIGHT - GAP;
            pins[2].X = x + 20 + WIDTH + GAP;
            pins[2].Y = y + 5 + HEIGHT / 2;
        }
        public override bool Evaluate()
        {
            Func<List<Pin>, bool> isTrue = pins =>
            {
                foreach (Pin p in pins)
                {
                    if (p.InputWire.FromPin.Owner.Evaluate() == true) return true;
                }
                return false;
            };
            return isTrue(pins);
        }
        public override Gate Clone()
        {
            OrGate clone = new OrGate(Position[0], Position[1]);
            List<Pin> pins = new List<Pin>();

            foreach (Pin pin in this.pins)
            {
                pins.Add(new Pin(pin.Owner, pin.IsInput, 20));
            }
            clone.pins = pins;
            return clone;
        }
    }
}
