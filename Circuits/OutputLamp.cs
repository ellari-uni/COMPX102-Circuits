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
        bool active = false;
        public OutputLamp(int x, int y)
        {
            pins.Add(new Pin(this, true, 20));
            MoveTo(x, y);
        }

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

        public override void Draw(Graphics paper)
        {
            Image image = null;
            switch (selected)
            {
                case true:
                    image =  active ? Properties.Resources.OutLampOnSelected : Properties.Resources.OutLampOffSelected;
                    break;
                case false:
                    image = active ? Properties.Resources.OutLampOn : Properties.Resources.OutLampOff;
                    break;
            }
            foreach (Pin p in pins) p.Draw(paper); 
            paper.DrawImage(image, Left, Top);
        }

        public override void MoveTo(int x, int y)
        {
            base.MoveTo(x, y);

            pins[0].X = x - 5;
            pins[0].Y = y + (HEIGHT / 2) + GAP + 3;
        }
        public override bool Evaluate()
        {
            return pins[0].InputWire.FromPin.Owner.Evaluate();
        }
        public override Gate Clone()
        {
            OutputLamp clone = new OutputLamp(Position[0], Position[1]);
            clone.pins = pins.ToList();
            return clone;
        }
    }
}
