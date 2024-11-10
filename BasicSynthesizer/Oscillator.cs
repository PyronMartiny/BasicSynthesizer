namespace BasicSynthesizer
{
    public class Oscillator : GroupBox
    {
        public TrackBar FrequencyOffsetTrackbar { get; private set; }
        public ComboBox OctaveSelector { get; private set; }
        public TrackBar AmplitudeTrackBar { get; private set; }
        public float Amplitude { get; private set; } = 1.0f;
        public Oscillator()
        {
            this.Controls.Add(new Button()
            {
                Name = "Sine",
                Location = new Point(10, 15),
                Text = "Sine",
                BackColor = Color.LightSkyBlue
            });
            this.Controls.Add(new Button()
            {
                Name = "Square",
                Location = new Point(65, 15),
                Text = "Square",
            });
            this.Controls.Add(new Button()
            {
                Name = "Saw",
                Location = new Point(120, 15),
                Text = "Saw",
            });
            this.Controls.Add(new Button()
            {
                Name = "Triangle",
                Location = new Point(10, 50),
                Text = "Triangle",
            });
            this.Controls.Add(new Button()
            {
                Name = "Noise",
                Location = new Point(65, 50),
                Text = "Noise",
            });

            AmplitudeTrackBar = new TrackBar()
            {
                Name = "AmplitudeTrackBar",
                Location = new Point(210, 50),
                Size = new Size(90, 30),
                Minimum = 0,
                Maximum = 100,
                Value = 75,
                TickFrequency = 20,
                AutoSize = false
            };
            AmplitudeTrackBar.ValueChanged += (sender, e) =>
            {
                Amplitude = AmplitudeTrackBar.Value / 100.0f;
            };
            this.Controls.Add(AmplitudeTrackBar);

            foreach (Control control in this.Controls)
            {
                if (control is Button)
                {
                    control.Size = new Size(50, 30);
                    control.Font = new Font("Microsoft Sans Serif", 6.75f);
                    control.Click += WaveButton_Click;
                }
            }
            this.Controls.Add(new CheckBox()
            {
                Name = "OscillatorOn",
                Location = new Point(210, 10),
                Size = new Size(60, 30),
                Text = "On",
                Checked = true
            });
            FrequencyOffsetTrackbar = new TrackBar()
            {
                Name = "FrequencyOffsetTrackBar",
                Location = new Point(382, 16),
                Size = new Size(40, 80),
                Minimum = -7,
                Maximum = 7,
                Value = 0,
                TickFrequency = 2,
                LargeChange = 1,
                SmallChange = 1,
                Orientation = Orientation.Vertical,
                AutoSize = false
            };
            this.Controls.Add(FrequencyOffsetTrackbar);

            OctaveSelector = new ComboBox()
            {
                Name = "OctaveSelector",
                Location = new Point(270, 16),
                Size = new Size(50, 20),
                Items = { "1", "0", "-1" },
                SelectedIndex = 1,
                DropDownStyle = ComboBoxStyle.DropDownList,
            };

            this.Controls.Add(OctaveSelector);

            foreach (Control control in this.Controls)
            {
                if (control is not TrackBar)
                {
                    control.Size = new Size(50, 30);
                    control.Font = new Font("Microsoft Sans Serif", 6.75f);
                }
            }
        }

        public Waveform Waveform { get; private set; }
        public bool On => ((CheckBox)this.Controls["OscillatorOn"]).Checked;

        public float FrequencyOffset => FrequencyOffsetTrackbar.Value * 1.0f;

        public int SelectedOctave
        {
            get
            {


                if (OctaveSelector?.SelectedItem == null)
                {
                    return 0;
                }
                return int.Parse(OctaveSelector.SelectedItem.ToString());
            }
        }

        private void WaveButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            this.Waveform = (Waveform)Enum.Parse(typeof(Waveform), button.Text);
            foreach (Button otherButtons in this.Controls.OfType<Button>())
            {
                otherButtons.UseVisualStyleBackColor = true;
            }
            button.BackColor = Color.LightSkyBlue;
        }
    }
}