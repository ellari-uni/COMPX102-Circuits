/*
 * NAME: Hayden Gillanders
 * ID NUMBER: 1636274
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Circuits
{
    /// <summary>
    /// The main GUI for the COMPX102 digital circuits editor.
    /// This has a toolbar, containing buttons called buttonAnd, buttonOr, etc.
    /// The contents of the circuit are drawn directly onto the form.
    /// 
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// The (x,y) mouse position of the last MouseDown event.
        /// </summary>
        protected int startX, startY;

        /// <summary>
        /// If this is non-null, we are inserting a wire by
        /// dragging the mouse from startPin to some output Pin.
        /// </summary>
        protected Pin startPin = null;

        /// <summary>
        /// The (x,y) position of the current gate, just before we started dragging it.
        /// </summary>
        protected int currentX, currentY;

        /// <summary>
        /// The set of gates in the circuit
        /// </summary>
        protected List<Gate> gatesList = new List<Gate>();

        /// <summary>
        /// The set of connector wires in the circuit
        /// </summary>
        protected List<Wire> wiresList = new List<Wire>();

        /// <summary>
        /// The currently selected gate, or null if no gate is selected.
        /// </summary>
        protected Gate current = null;

        /// <summary>
        /// The new gate that is about to be inserted into the circuit
        /// </summary>
        protected Gate newGate = null;
        /// <summary>
        /// New compound gate
        /// </summary>
        protected Compound newCompound = null;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            //Show marker message
            MessageBox.Show("!!!!!!!!!!!!NOTE FOR THE MARKER!!!!!!!!!!!\n\nThe Input tool requires you to DOUBLE CLICK to change status\n\nThis is intentional - and means that the tool can be moved without changing states!", "A note for the Assessor");
        }

        /// <summary>
        /// Finds the pin that is close to (x,y), or returns
        /// null if there are no pins close to the position.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>The pin that has been selected</returns>
        public Pin findPin(int x, int y)
        {
            foreach (Gate g in gatesList)
            {
                foreach (Pin p in g.Pins)
                {
                    if (p.isMouseOn(x, y))
                        return p;
                }
            }
            return null;
        }

        /// <summary>
        /// Handles all events when the mouse is moving.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (startPin != null)
            {
                Console.WriteLine("wire from " + startPin + " to " + e.X + "," + e.Y);
                currentX = e.X;
                currentY = e.Y;
                this.Invalidate();  // this will draw the line
            }
            else if (startX >= 0 && startY >= 0 && current != null)
            {
                Console.WriteLine("mouse move to " + e.X + "," + e.Y);
                
                current.MoveTo(currentX + (e.X - startX), currentY + (e.Y - startY));
                this.Invalidate();
            }
            else if (newGate != null)
            {
                currentX = e.X;
                currentY = e.Y;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Handles all events when the mouse button is released.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (startPin != null)
            {
                // see if we can insert a wire
                Pin endPin = findPin(e.X, e.Y);
                if (endPin != null)
                {
                    Console.WriteLine("Trying to connect " + startPin + " to " + endPin);
                    Pin input, output;
                    if (startPin.IsOutput)
                    {
                        input = endPin;
                        output = startPin;
                    }
                    else
                    {
                        input = startPin;
                        output = endPin;
                    }
                    if (input.IsInput && output.IsOutput)
                    {
                        if (input.InputWire == null)
                        {
                            Wire newWire = new Wire(output, input);
                            input.InputWire = newWire;
                            wiresList.Add(newWire);
                        }
                        else
                        {
                            MessageBox.Show("That input is already used.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error: you must connect an output pin to an input pin.");
                    }
                }
                startPin = null;
                this.Invalidate();
            }
            // We have finished moving/dragging
            startX = -1;
            startY = -1;
            currentX = 0;
            currentY = 0;
        }

        /// <summary>
        /// This will create a new And gate.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonAnd_Click(object sender, EventArgs e)
        {
            newGate = new AndGate(0, 0);
        }



        /// <summary>
        /// Redraws all the graphics for the current circuit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Draw all of the gates
            foreach (Gate g in gatesList)
            {
                g.Draw(e.Graphics);
            }
            //Draw all of the wires
            foreach (Wire w in wiresList)
            {
                w.Draw(e.Graphics);
            }

            if (startPin != null)
            {
                e.Graphics.DrawLine(Pens.White,
                    startPin.X, startPin.Y,
                    currentX, currentY);
            }
            else if (newGate != null)
            {
                // show the gate that we are dragging into the circuit

                newGate.MoveTo(currentX, currentY);
                //If the newGate isn't a compound, draw it (will cause duplicates to show if drawn as a compound)
                if (!(newGate is Compound)) newGate.Draw(e.Graphics);
            }
        }
        /// <summary>
        /// Handles or gate toolbar button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonOr_Click(object sender, EventArgs e)
        {
            newGate = new OrGate(0, 0);
        }
        /// <summary>
        /// Handled NOT gate toolbar button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            newGate = new NotGate(0, 0);
        }
        /// <summary>
        /// Handles Input source toolbar button click event 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonInput_Click(object sender, EventArgs e)
        {
            newGate = new InputSource(0, 0);
        }
        /// <summary>
        /// Handles double click events on the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Foreach gate on the form
            foreach (Gate g in gatesList)
            {
                //If the mouse is on the gate
                if (g.IsMouseOn(e.X, e.Y))
                {
                    //If the gate is a inputsource
                    if (g is InputSource src)
                    {
                        //Checking isOn
                        switch (src.IsOn)
                        {
                            //If true, set to false
                            case true:
                                src.IsOn = false;
                                break;
                            //If false, set to true
                            case false:
                                src.IsOn = true;
                                break;
                        }
                    }
                    //Refresh the form
                    this.Refresh();
                }
            }
        }
        /// <summary>
        /// Handles output lamp toolbar button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonOutput_Click(object sender, EventArgs e)
        {
            newGate = new OutputLamp(0, 0);
        }

        
        /// <summary>
        /// Handles evaluate button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            //Create new list of output lamps in the circuit
            List<OutputLamp> lamps = new List<OutputLamp>();
            //Foreach gate in the circuit
            foreach (Gate gate in gatesList)
            {
                //If the gate is an output lamp, add it to the list of output lamps
                if (gate is OutputLamp lamp) lamps.Add(lamp);
            }
            //For each lamp in the output lamp list
            foreach (OutputLamp lamp in lamps)
            {
                //If the lamp evaluates to true, set active to true, else set to false
                lamp.Active = lamp.Evaluate();
            }
            //Refresh the form
            Refresh();
        }
        /// <summary>
        /// Handles clone button toolbar click event 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonClone_Click(object sender, EventArgs e)
        {
            if (newCompound != null)
            {
                /********************/
                //Set NewGate to the compound
                newGate = newCompound;
                newGate.MoveTo(currentX, currentY);
                //Set newcompound to null
                newCompound = null;
                /********************/

                newGate = newGate.Clone();
            }
            //If there is a value in current, and it is not a compound, then clone the current gate
            else if (current != null && !(newGate is Compound)) newGate = current.Clone();
            
            //Else show error saying a gate must be selected
            else MessageBox.Show("You must select a gate first!");
            //Refresh the form
            Refresh();
        }
        /// <summary>
        /// Handles compoundStart toolbar button click event 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonCompoundStart_Click(object sender, EventArgs e)
        {
            //If there is not already a compound being created, create a new compound at 0,0
            if (newCompound == null) newCompound = new Compound(0, 0);
            //Else if there is a compound currently being created, tell the user to finish the current compound first
            else if (newCompound != null) MessageBox.Show("Finish with your current Compound first!!", "Error");
        }
        /// <summary>
        /// Handles compoundEnd toolbar Button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonEndCompound_Click(object sender, EventArgs e)
        {
            //If there is currently a compound being created
            if (newCompound != null)
            {
                //Set NewGate to the compound
                newGate = newCompound;
                //Set newcompound to null
                newCompound = null;
            }
            //If there is not a compound being created, tell the user to create a compound first
            else if (newCompound == null) MessageBox.Show("Create a new Compound Group First!", "Error");
        }

        /// <summary>
        /// Handles events while the mouse button is pressed down.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (current == null)
            {
                // try to start adding a wire
                startPin = findPin(e.X, e.Y);
            }
            else if (current.IsMouseOn(e.X, e.Y))
            {
                // start dragging the current object around
                startX = e.X;
                startY = e.Y;
                currentX = current.Left;
                currentY = current.Top;
            }
        }

        /// <summary>
        /// Handles all events when a mouse is clicked in the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //Check if a gate is currently selected
            if (current != null)
            {
                //Unselect the selected gate
                current.Selected = false;
                current = null;
                this.Invalidate();
            }
            // See if we are inserting a new gate
            if (newGate != null)
            {
                newGate.MoveTo(e.X, e.Y);
                if (newGate is Compound c) foreach (Gate g in c.Gates) g.Selected = false;
                gatesList.Add(newGate);
                newGate = null;
                this.Invalidate();
            }
            else
            {
                // search for the first gate under the mouse position
                foreach (Gate g in gatesList)
                {
                    if (g.IsMouseOn(e.X, e.Y))
                    {
                        //If a new compound is being created
                        if (newCompound != null)
                        {
                            //If the compound gates list doesn't already contain the current gate, add the gate to the list of gates
                            if (!newCompound.Gates.Contains(g)) newCompound.AddGate(g);
                            //Show messagebox with amount of gates in the list (DEBUG)
                            //MessageBox.Show(newCompound.Gates.Count.ToString());
                        }
                        g.Selected = true;
                        current = g;
                        this.Invalidate();
                        break;
                    }
                    
                }
            }
        }

    }
}
