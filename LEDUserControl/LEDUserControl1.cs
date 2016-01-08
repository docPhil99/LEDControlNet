using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LEDControlNet
{
    public partial class LEDUserControl1 : UserControl
    {
        Comms comm;
        bool clicked = false;


        public byte PWMValue
        {
            set
            {
                comm.WriteArdunioData(value.ToString());
            }
        }
        public LEDUserControl1()
        {
            InitializeComponent();
           
            //a simple latching method to ensure the mouse button is released before sending data to comm port.
            trackBar1.MouseDown += (s,
                        e) =>
            {
                clicked = true;
            };
            trackBar1.MouseUp += (s,
                                    e) =>
            {
                if (!clicked)
                    return;

                clicked = false;
                Console.WriteLine("Mouse up"+trackBar1.Value);
                if(this.checkBox1.Checked)
                    this.PWMValue=(byte)(255-trackBar1.Value);
            };
            comm = new Comms();
            comm.ScanPorts();
            try
            {
                comm.OpenArduinoConnection();
                this.checkBox1.Checked = true;
            }
            catch
            {
                this.checkBox1.Checked = false;
                this.trackBar1.Enabled = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
          //  if(System.Windows.Forms.MouseButtons.
            //System.Console.WriteLine(this.trackBar1.Value);
        }
        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {

            if (disposing)
                comm.Dispose();
    
    if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
       
    }
}
