namespace BasicSynthesizer
{
    partial class BasicSynthesizer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            oscillator1 = new Oscillator();
            oscillator3 = new Oscillator();
            oscillator4 = new Oscillator();
            SuspendLayout();
            // 
            // oscillator1
            // 
            oscillator1.Location = new Point(12, 12);
            oscillator1.Name = "oscillator1";
            oscillator1.Size = new Size(433, 100);
            oscillator1.TabIndex = 0;
            oscillator1.TabStop = false;
            oscillator1.Text = "oscillator1";
            oscillator1.Enter += oscillator1_Enter_1;
            // 
            // oscillator3
            // 
            oscillator3.Location = new Point(12, 118);
            oscillator3.Name = "oscillator3";
            oscillator3.Size = new Size(433, 100);
            oscillator3.TabIndex = 2;
            oscillator3.TabStop = false;
            oscillator3.Text = "Oscillator 2";
            oscillator3.Enter += oscillator3_Enter;
            // 
            // oscillator4
            // 
            oscillator4.Location = new Point(12, 224);
            oscillator4.Name = "oscillator4";
            oscillator4.Size = new Size(433, 100);
            oscillator4.TabIndex = 3;
            oscillator4.TabStop = false;
            oscillator4.Text = "Oscillator 3";
            // 
            // BasicSynthesizer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(457, 342);
            Controls.Add(oscillator4);
            Controls.Add(oscillator3);
            Controls.Add(oscillator1);
            KeyPreview = true;
            Name = "BasicSynthesizer";
            Text = "BasicSynthesizer";
            KeyDown += BasicSynthesizer_KeyDown;
            ResumeLayout(false);
        }

        #endregion

        private Oscillator oscillator1;
        private Oscillator oscillator3;
        private Oscillator oscillator4;
    }
}
