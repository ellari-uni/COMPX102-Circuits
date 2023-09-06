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

        public override void Draw(Graphics paper)
        {
            Image image = selected ? Properties.Resources.NotGateAllRed : Properties.Resources.NotGate;

            foreach (Pin p in pins) p.Draw(paper);
            paper.DrawImage(image, Left, Top);

        }
        public override void MoveTo(int x, int y)
        {
            base.MoveTo(x, y);
            pins[0].X = x + 5 - GAP;
            pins[0].Y = y + (HEIGHT / 2) + (GAP /2);
            pins[1].X = x + WIDTH + GAP + (GAP / 2);
            pins[1].Y = y + (HEIGHT / 2) + (GAP / 2);
            
        }
    }
}
