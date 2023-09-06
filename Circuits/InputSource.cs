/*
 * NAME: Hayden Gillanders
 * ID NUMBER: 1636274
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuits
{
    class InputSource : Gate
    {
        public InputSource(int x, int y)
        {
            pins.Add(new Pin(this, false, 20));

            MoveTo(x, y);

        }
    }
}
