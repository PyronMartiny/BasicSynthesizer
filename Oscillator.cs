using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;



namespace BasicSynthesizer
{
    public class Oscillator: GroupBox
    {
        public Oscillator()
        {
            this.Controls.Add(new Button()
            {
                Name = "Sine",
                Location = new System.Drawing.Point(10, 15),
                Text = "Sine",
            });
            this.Controls.Add(new Button()
            {
                Name = "Square",
                Location = new System.Drawing.Point(65, 15),
                Text = "Square",
            });
            this.Controls.Add(new Button()
            {
                Name = "Saw",
                Location = new System.Drawing.Point(120, 15),
                Text = "Saw",
            });
            this.Controls.Add(new Button()
            {
                Name = "Tri",
                Location = new System.Drawing.Point(10, 50),
                Text = "Tri",
            });
            this.Controls.Add(new Button()
            {
                Name = "Noise",
                Location = new System.Drawing.Point(65, 50),
                Text = "Noise",
            });
            foreach (Control control in this.Controls)
            {
                control.Size = new Size(50, 30);
                control.Font = new Font("Microsoft Sans Serif", 6.75f);
            }
        }
    
    }
}