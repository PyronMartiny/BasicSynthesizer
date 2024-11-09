using System.Media;
using System.Windows.Forms;

namespace BasicSynthesizer
{
    public partial class BasicSynthesizer : Form
    {
        private const int SAMPLE_RATE = 44100;
        private const short BIT_PER_SAMPLE = 16;

        public BasicSynthesizer()
        {
            InitializeComponent();
        }

        private void BasicSynthesizer_KeyDown(object sender, KeyEventArgs e)
        {
            short[] wave = new short[SAMPLE_RATE];
            byte[] binaryWave = new byte[SAMPLE_RATE * sizeof(short)];
            float frequency;
            
            switch (e.KeyCode)
            {
                case Keys.A:
                    frequency = 130.81f; // C3
                    break;
                case Keys.W:
                    frequency = 138.59f; // C#3 / Db3
                    break;
                case Keys.S:
                    frequency = 146.83f; // D3
                    break;
                case Keys.E:
                    frequency = 155.56f; // D#3 / Eb3
                    break;
                case Keys.D:
                    frequency = 164.81f; // E3
                    break;
                case Keys.F:
                    frequency = 174.61f; // F3
                    break;
                case Keys.T:
                    frequency = 185.00f; // F#3 / Gb3
                    break;
                case Keys.G:
                    frequency = 196.00f; // G3
                    break;
                case Keys.Y:
                    frequency = 207.65f; // G#3 / Ab3
                    break;
                case Keys.H:
                    frequency = 220.00f; // A3
                    break;
                case Keys.U:
                    frequency = 233.08f; // A#3 / Bb3
                    break;
                case Keys.J:
                    frequency = 246.94f; // B3
                    break;
                case Keys.K:
                    frequency = 261.63f; // C4 (Middle C)
                    break;
                case Keys.L:
                    frequency = 277.18f; // C#4 / Db4
                    break;
                case Keys.OemSemicolon: // ';' key
                    frequency = 293.66f; // D4
                    break;
                case Keys.OemQuotes: // '\'' key (single quote)
                    frequency = 311.13f; // D#4 / Eb4
                    break;
                default:
                    return;
            }

            foreach (Oscillator oscillator in this.Controls.OfType<Oscillator>())
            {
                int samplesPerWaveLength = (int)(SAMPLE_RATE / frequency);
                short ampStep = (short)((short.MaxValue * 2) / samplesPerWaveLength);
                short tempSample;
                switch (oscillator.Waveform)
                {
                    case Waveform.Sine:
                        for (int i = 0; i < SAMPLE_RATE; i++)
                        {
                            wave[i] = Convert.ToInt16((short.MaxValue * 1) * Math.Sin((Math.PI * 2 * frequency / SAMPLE_RATE) * i));
                        }
                        break;
                    case Waveform.Square:
                        for (int i = 0; i < SAMPLE_RATE; i++)
                        {
                            wave[i] = Convert.ToInt16(short.MaxValue * Math.Sign(Math.Sin((Math.PI * 2 * frequency) / SAMPLE_RATE * i)));
                        }
                        break;
                    case Waveform.Saw:
                        for (int i = 0; i < SAMPLE_RATE; i++)
                        {
                            tempSample = -short.MaxValue;
                            for (int j = 0; j < samplesPerWaveLength && i < SAMPLE_RATE; j++)
                            {
                                tempSample += ampStep;
                                wave[i++] = Convert.ToInt16(tempSample);
                            }
                            i--;
                        }
                        break;
                    case Waveform.Triangle:
                        tempSample = -short.MaxValue;
                        for (int i = 0; i < SAMPLE_RATE; ++i)
                        {
                            if (Math.Abs(tempSample + ampStep) > short.MaxValue)
                            {
                                ampStep = (short)-ampStep;
                            }   
                            tempSample += ampStep;
                            wave[i] = Convert.ToInt16(tempSample);
                        }
                        break;
                    case Waveform.Noise:
                        Random random = new Random();
                        for (int i = 0; i < SAMPLE_RATE; i++)
                        {
                        wave[i] = (short)random.Next(-short.MaxValue, short.MaxValue);
                        }
                        break;

                }

            }
            Buffer.BlockCopy(wave, 0, binaryWave, 0, wave.Length * sizeof(short));
            using (MemoryStream memoryStream = new MemoryStream())
            using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
            {
                short blockAlign = BIT_PER_SAMPLE / 8;
                int subChunkTwoSize = SAMPLE_RATE * blockAlign;
                binaryWriter.Write(new[] { 'R', 'I', 'F', 'F' });
                binaryWriter.Write(36 + subChunkTwoSize);
                binaryWriter.Write(new[] { 'W', 'A', 'V', 'E', 'f', 'm', 't', ' ' });
                binaryWriter.Write(16);
                binaryWriter.Write((short)1);
                binaryWriter.Write((short)1);
                binaryWriter.Write(SAMPLE_RATE);
                binaryWriter.Write(SAMPLE_RATE * blockAlign);
                binaryWriter.Write(blockAlign);
                binaryWriter.Write(BIT_PER_SAMPLE);
                binaryWriter.Write(new[] { 'd', 'a', 't', 'a' });
                binaryWriter.Write(subChunkTwoSize);
                binaryWriter.Write(binaryWave);
                memoryStream.Position = 0;
                new SoundPlayer(memoryStream).Play();
            }
        }

        private void oscillator1_Enter(object sender, EventArgs e)
        {

        }
    }
    public enum Waveform
    {
        Sine, Square, Saw, Triangle, Noise
    }
}
