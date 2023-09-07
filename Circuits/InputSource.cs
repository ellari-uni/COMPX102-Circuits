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
        bool active = false;
        public InputSource(int x, int y)
        {
            pins.Add(new Pin(this, false, 20));

            MoveTo(x, y);

        }

        public override void Draw(Graphics paper)
        {
            Image image = null;
            switch (selected)
            {
                case true:
                    image = active ? Properties.Resources.InputSrcActSelec : Properties.Resources.InputSrcInacSelec;
                    break;
                case false:
                    image = active ? Properties.Resources.InputSrcAct : Properties.Resources.InputSrcInac;
                    break;
            }
            foreach (Pin p in pins) p.Draw(paper);
            paper.DrawImage(image, Left, Top);
        }

        public override void MoveTo(int x, int y)
        {
            base.MoveTo(x, y);

            pins[0].X = x + (int)(2 * WIDTH);
            pins[0].Y = y + (GAP /2)+ (HEIGHT / 2);
            Console.WriteLine(x + " " + y + "\n" + pins[0].X + " " + pins[0].Y);


        }

        public override bool Evaluate()
        {
            return IsOn;
        }

        public bool IsOn
        {
            get { return active; }
            set { active = value; }
        }
        public override Gate Clone()
        {
            InputSource clone = new InputSource(Position[0], Position[1]);
            clone.pins = pins.ToList();
            return clone;
        }
    }
}
