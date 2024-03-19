using NAudio.CoreAudioApi;
using NAudio.Dsp;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FreqLED.Desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SerialPort port;
        LEDEffect effect;

        List<LEDEffect> effects = new() {
            new LEDEffect { Id = "fx01", Name = "Simple Red Vumeter" },
            new LEDEffect { Id = "fx02", Name = "Simple Green Vumeter" },
            new LEDEffect { Id = "fx03", Name = "Simple Blue Vumeter" },
            new LEDEffect { Id = "fx04", Name = "Simple RGB Vumeter" },
            new LEDEffect { Id = "fx05", Name = "Simple Classic Vumeter" },
            new LEDEffect { Id = "fx06", Name = "Faded Classic Vumeter" },
            new LEDEffect { Id = "fx07", Name = "Centered Classic Vumeter" },
            new LEDEffect { Id = "fx08", Name = "Centered Color Vumeter" },
            new LEDEffect { Id = "fx09", Name = "Flat Color Vumeter" },
            new LEDEffect { Id = "fx10", Name = "Bouncing Ball" },
        };


        int effect_delay = 5;
        int ledStripCount = 1;
        int ledStripLength = 30;
        public int[][] leds;
        public int framesPeerSecond = 0;
        public int frames = 0;
        public int seconds = 0;
        public float masterPeakValue = 0;
        public Stopwatch fps_sw = new Stopwatch();
        public Stopwatch fps_effect = new Stopwatch();
        public int[] user_color = new int[3];
        public int[] user_aux = new int[2];
        public string effect_command = "";

        MMDeviceEnumerator deviceEnumerator;
        MMDevice device;
        List<PictureBox> pictureBoxes = new List<PictureBox>();
        List<Button> FxSelectorButtons = new List<Button>();


        private Stopwatch txStopwatch = new Stopwatch();

        private void Form1_Load(object sender, EventArgs e)
        {

            RedTrackBar.Value = RedTrackBar.Maximum;
            GreenTrackBar.Value = GreenTrackBar.Maximum;
            BlueTrackBar.Value = BlueTrackBar.Maximum;
            Aux1TrackBar.Value = Aux1TrackBar.Maximum;
            Aux2Trackbar.Value = Aux2Trackbar.Maximum;

            deviceEnumerator = new MMDeviceEnumerator();

            DevicesComboBox.DataSource = deviceEnumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active).ToList();
            DevicesComboBox.ValueMember = nameof(MMDevice.ID);
            DevicesComboBox.DisplayMember = nameof(MMDevice.FriendlyName);

            device = deviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            DevicesComboBox.SelectedValue = device.ID;

            comboBox1.DataSource = effects;
            comboBox1.ValueMember = nameof(LEDEffect.Id);
            comboBox1.DisplayMember = nameof(LEDEffect.Name);

            leds = new int[ledStripLength][];

            for (int i = 0; i < ledStripLength; i++)
            {
                leds[i] = new int[3] { 0, 0, 0 };
            }


            foreach (var effect in effects)
            {
                Button button = new Button();
                button.Name = $"FxSelectorButton_{effect.Id}";
                button.FlatStyle = FlatStyle.Flat;
                button.Height = 100;
                button.Width = 200;
                button.Tag = effect.Id;
                button.Text = $"{effect.Id}\n{effect.Name}";
                button.Click += SetEffect_Click;
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.Margin = new Padding(10);
                button.BackColor = Color.FromArgb(255, 30, 30, 30);
                FxSelectorButtons.Add(button);
            }

            flowLayoutPanel1.Controls.AddRange(FxSelectorButtons.ToArray());

            for (int i = 0; i < ledStripLength; i++)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.Name = "pbLED" + i;
                pictureBox.Width = 20;
                pictureBox.Height = 20;
                pictureBox.BackColor = Color.White;
                pictureBox.Margin = new Padding(10);
                pictureBoxes.Add(pictureBox);
            }

            flowLayoutPanel2.Controls.AddRange(pictureBoxes.ToArray());

            LoadAvailablePorts();

            //txStopwatch.Start();

            backgroundWorker1.RunWorkerAsync();
        }

        private void LoadAvailablePorts()
        {
            COMDevicesComboBox.Items.Clear();
            foreach (string port in SerialPort.GetPortNames())
            {
                COMDevicesComboBox.Items.Add(port);
            }
        }

        private void SetEffect_Click(object? sender, EventArgs e)
        {
            if (sender == null)
            {
                return;
            }

            var button = (Button)sender;

            if (button != null)
            {
                user_color[0] = RedTrackBar.Value;
                user_color[1] = GreenTrackBar.Value;
                user_color[2] = BlueTrackBar.Value;
                comboBox1.SelectedValue = button.Tag;
            }
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            fps_sw.Start();
            fps_effect.Start();

            while (true)
            {
                if (fps_effect.ElapsedMilliseconds > effect_delay)
                {


                    fps_effect.Restart();
                    if (effect.Id == "fx01")
                    {
                        SimpleColorVumeter((int)masterPeakValue, 255, 0, 0);
                    }
                    else if (effect.Id == "fx02")
                    {
                        SimpleColorVumeter((int)masterPeakValue, 0, 255, 0);
                    }
                    else if (effect.Id == "fx03")
                    {
                        SimpleColorVumeter((int)masterPeakValue, 0, 0, 255);
                    }
                    else if (effect.Id == "fx04")
                    {
                        SimpleColorVumeter((int)masterPeakValue, user_color[0], user_color[1], user_color[2]);
                    }
                    else if (effect.Id == "fx05")
                    {
                        SimpleClassicVumeter((int)masterPeakValue);
                    }
                    else if (effect.Id == "fx06")
                    {
                        SimpleClassicFadeVumeter((int)masterPeakValue);
                    }
                    else if (effect.Id == "fx07")
                    {
                        CenteredClassicVumeter((int)masterPeakValue);
                    }
                    else if (effect.Id == "fx08")
                    {
                        CenteredColorVumeter((int)masterPeakValue, user_color[0], user_color[1], user_color[2]);
                    }
                    else if (effect.Id == "fx09")
                    {
                        FlatColorVumeter((int)masterPeakValue * 255 / 100, user_color[0], user_color[1], user_color[2]);
                    }
                    else if (effect.Id == "fx10")
                    {
                        BouncingBall(user_aux[0], user_aux[1], user_color[0], user_color[1], user_color[2]);
                    }
                    //SimpleColorGhostVumeter((int)masterPeakValue, user_color);


                    for (int led = 0; led < leds.Length; led++)
                    {
                        pictureBoxes[led].BackColor = Color.FromArgb(255, leds[led][0], leds[led][1], leds[led][2]);
                    }
                    //Thread.Sleep(10);
                    frames++;
                }

                if (fps_sw.ElapsedMilliseconds > 1000)
                {
                    framesPeerSecond = frames;
                    frames = 0;
                    seconds++;
                    fps_sw.Restart();
                    backgroundWorker1.ReportProgress(framesPeerSecond);
                }

                if (backgroundWorker1.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {

            masterPeakValue = device.AudioMeterInformation.MasterPeakValue * 100;
            progressBar1.Value = (int)masterPeakValue;
            label3.Text = ((int)masterPeakValue).ToString();

            if (txStopwatch.ElapsedMilliseconds > 0)
            {
                effect_command = GetEffectCommand();
                if (effect_command != "")
                {
                    port.WriteLine(effect_command);
                    txStopwatch.Stop();
                }
            }
        }

        private string GetEffectCommand()
        {
            if (effect.Id == "fx01")
            {
                return $"@{effect.Id}&{(int)masterPeakValue * 255 / 100}#";
            }
            else if (effect.Id == "fx02")
            {
                return $"@{effect.Id}&{(int)masterPeakValue * 255 / 100}#";
            }
            else if (effect.Id == "fx03")
            {
                return $"@{effect.Id}&{(int)masterPeakValue * 255 / 100}#";
            }
            else if (effect.Id == "fx04")
            {
                return $"@{effect.Id}&{(int)masterPeakValue * 255 / 100}&{user_color[0]}&{user_color[1]}&{user_color[2]}#";
            }
            else if (effect.Id == "fx05")
            {
                return $"@{effect.Id}&{(int)masterPeakValue * 255 / 100}#";
            }
            else if (effect.Id == "fx06")
            {
                return $"@{effect.Id}&{(int)masterPeakValue * 255 / 100}#";
            }
            else if (effect.Id == "fx07")
            {
                return $"@{effect.Id}&{(int)masterPeakValue * 255 / 100}#";
            }
            else if (effect.Id == "fx08")
            {
                return $"@{effect.Id}&{(int)masterPeakValue * 255 / 100}&{user_color[0]}&{user_color[1]}&{user_color[2]}#";
            }
            else if (effect.Id == "fx09")
            {
                return $"@{effect.Id}&{(int)masterPeakValue * 255 / 100}&{user_color[0]}&{user_color[1]}&{user_color[2]}#";
            }
            else if (effect.Id == "fx10")
            {
                return $"@{effect.Id}&{user_aux[0]}&{user_aux[1]}&{user_color[0]}&{user_color[1]}&{user_color[2]}#";
            }
            else
            {

            }
            return "";
        }

        private delegate void SetTextDeleg(string text);

        void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (port.IsOpen)
            {
                string data = port.ReadLine();
                txStopwatch.Start();

                if (data.Contains("error"))
                {
                    this.BeginInvoke(new SetTextDeleg(si_DataReceived), new object[] { data });
                }
            }
        }

        private void si_DataReceived(string data)
        {
            richTextBox1.AppendText(data.Trim() + Environment.NewLine);
            richTextBox1.ScrollToCaret();
        }

        private void SimpleColorVumeter(int volume, int r, int g, int b)
        {
            for (int i = 0; i < ledStripLength; i++)
            {
                if (i < volume * ledStripLength / 100)
                {
                    leds[i] = [r, g, b];
                }
                else
                {
                    leds[i] = [0, 0, 0];
                }
            }
        }

        private void SimpleColorGhostVumeter(int volume, int[] color)
        {
            for (int i = 0; i < ledStripLength; i++)
            {
                if (i < volume * ledStripLength / 100)
                {
                    leds[i][0] = color[0];
                    leds[i][1] = color[1];
                    leds[i][2] = color[2];
                }
                else
                {
                    //leds[i][0] = 0;
                    //leds[i][1] = 0;
                    //leds[i][2] = 0;
                    leds[i][0] = leds[i][0] > 20 ? leds[i][0] - 20 : 0;
                    leds[i][1] = leds[i][1] > 20 ? leds[i][1] - 20 : 0;
                    leds[i][2] = leds[i][2] > 20 ? leds[i][2] - 20 : 0;
                }
            }
        }

        private void SimpleClassicVumeter(int volume)
        {
            for (int i = 0; i < ledStripLength; i++)
            {
                if (i < volume * ledStripLength / 100)
                {
                    if (i > ledStripLength * 0.8)
                    {
                        leds[i][0] = 255;
                        leds[i][1] = 0;
                        leds[i][2] = 0;
                    }
                    else if (i > ledStripLength * 0.6)
                    {
                        leds[i][0] = 255;
                        leds[i][1] = 255;
                        leds[i][2] = 0;
                    }
                    else
                    {
                        leds[i][0] = 0;
                        leds[i][1] = 255;
                        leds[i][2] = 0;
                    }
                }
                else
                {
                    leds[i][0] = 0;
                    leds[i][1] = 0;
                    leds[i][2] = 0;
                }
            }
        }

        private void CenteredClassicVumeter(int volume)
        {
            for (int i = 0; i < ledStripLength / 2; i++)
            {
                if (i < volume * ledStripLength / 200)
                {
                    if (i > ledStripLength / 2 * 0.8)
                    {
                        leds[(ledStripLength / 2) + i] = [255, 0, 0];
                        leds[(ledStripLength / 2) - 1 - i] = [255, 0, 0];
                    }
                    else if (i > ledStripLength / 2 * 0.6)
                    {
                        leds[(ledStripLength / 2) + i] = [255, 255, 0];
                        leds[(ledStripLength / 2) - 1 - i] = [255, 255, 0];
                    }
                    else
                    {
                        leds[(ledStripLength / 2) + i] = [0, 255, 0];
                        leds[(ledStripLength / 2) - 1 - i] = [0, 255, 0];
                    }
                }
                else
                {
                    leds[(ledStripLength / 2) + i] = [0, 0, 0];
                    leds[(ledStripLength / 2) - 1 - i] = [0, 0, 0];
                }
            }
        }

        private void CenteredColorVumeter(int volume, int r, int g, int b)
        {
            for (int i = 0; i < ledStripLength / 2; i++)
            {
                if (i < volume * ledStripLength / 200)
                {
                    leds[(ledStripLength / 2) + i] = [r, g, b];
                    leds[(ledStripLength / 2) - 1 - i] = [r, g, b];
                }
                else
                {
                    leds[(ledStripLength / 2) + i] = [0, 0, 0];
                    leds[(ledStripLength / 2) - 1 - i] = [0, 0, 0];
                }
            }
        }

        private void FlatColorVumeter(int volume, int r, int g, int b) //max vol == 255
        {
            for (int i = 0; i < ledStripLength; i++)
            {
                if (volume < 255 * 0.3)
                {
                    leds[i] = [0, 0, 0];
                }
                else if (volume < 255 * 0.7)
                {
                    leds[i] = [(int)(volume - 255 * 0.3) * r / (int)(255 * 0.4), (int)(volume - 255 * 0.3) * g / (int)(255 * 0.4), (int)(volume - 255 * 0.3) * b / (int)(255 * 0.4)];
                }
                else
                {
                    leds[i] = [r, g, b];
                }
            }
        }

        int ballPosition = 0;
        int ballFrames = 0;
        bool ballUp = true;

        private void BouncingBall(int speed, int glow, int r, int g, int b, int _counter = 0)
        {
            speed = speed * 5 / 255;
            glow = glow * 10 / 255;

            if (ballFrames < 5 - speed)
            {
                ballFrames++;
                return;
            }

            ballFrames = 0;

            for (int i = 0; i < ledStripLength; i++)
            {
                leds[i] = i == ballPosition ? [r, g, b] : [0, 0, 0];
            }

            if (ballUp)
            {
                for (int i = 0; i < glow; i++)
                {
                    if (ballPosition > i)
                    {
                        leds[ballPosition - i - 1] = [r - (r / glow * i), g - (g / glow * i), b - (b / glow * i)];
                    }
                }

                for (int i = ((ballPosition + 1) * 2) - 2; i < glow; i++)
                {
                    leds[ballPosition + ++_counter] = [r - (r / glow * i), g - (g / glow * i), b - (b / glow * i)];
                }
            }

            if (!ballUp)
            {
                for (int i = 0; i < glow; i++)
                {
                    if (ballPosition < ledStripLength - i - 1)
                    {
                        leds[ballPosition + i + 1] = [r - (r / glow * i), g - (g / glow * i), b - (b / glow * i)];
                    }
                }

                for (int i = ((ledStripLength - ballPosition) * 2) - 2; i < glow; i++)
                {
                    leds[ballPosition - ++_counter] = [r - (r / glow * i), g - (g / glow * i), b - (b / glow * i)];
                }
            }


            if (ballPosition == ledStripLength - 1)
            {
                ballUp = false;
            }

            if (ballPosition == 0)
            {
                ballUp = true;
            }

            ballPosition = ballUp ? ballPosition + 1 : ballPosition - 1;
        }

        private void SimpleClassicFadeVumeter(int volume)
        {
            for (int i = 0; i < ledStripLength; i++)
            {
                if (i < volume * ledStripLength / 100)
                {
                    if (i <= (ledStripLength * 0.7))
                    {
                        if (i > (ledStripLength * 0.3))
                        {
                            leds[i][0] = Convert.ToInt32((Math.Pow(i, 3) * 255) / Math.Pow(ledStripLength * 0.7, 3));
                        }
                        else
                        {
                            leds[i][0] = 0;
                        }
                        leds[i][1] = 255;
                    }
                    else
                    {
                        leds[i][0] = 255;
                        if (i <= (ledStripLength * 0.7))
                        {
                            leds[i][1] = 255;
                        }
                        else
                        {
                            if (i <= (ledStripLength * 0.95))
                            {
                                leds[i][1] = 255 - Convert.ToInt32((Math.Pow(i, 7) * 255) / Math.Pow(ledStripLength * 0.95, 7));
                            }
                            else
                            {
                                leds[i][1] = 0;
                            }
                        }
                    }
                }
                else
                {
                    leds[i][0] = 0;
                    leds[i][1] = 0;
                }
                leds[i][2] = 0;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            effect = (LEDEffect)comboBox1.SelectedItem!;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            if (port != null && port.IsOpen)
            {
                port.Close();
            }

            if (backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            PreviewFPSLabel.Text = $"{e.ProgressPercentage} FPS";
        }

        private void RedTrackBar_ValueChanged(object sender, EventArgs e)
        {
            user_color[0] = RedTrackBar.Value;
            RedTrackbarLabel.Text = RedTrackBar.Value.ToString();
            RedTrackBarColor.BackColor = Color.FromArgb(RedTrackBar.Value, 0, 0);
            TrackBarsColor.BackColor = Color.FromArgb(RedTrackBar.Value, GreenTrackBar.Value, BlueTrackBar.Value);
        }

        private void GreenTrackBar_ValueChanged(object sender, EventArgs e)
        {
            user_color[1] = GreenTrackBar.Value;
            GreenTrackbarLabel.Text = GreenTrackBar.Value.ToString();
            GreenTrackBarColor.BackColor = Color.FromArgb(0, GreenTrackBar.Value, 0);
            TrackBarsColor.BackColor = Color.FromArgb(RedTrackBar.Value, GreenTrackBar.Value, BlueTrackBar.Value);
        }

        private void BlueTrackBar_ValueChanged(object sender, EventArgs e)
        {
            user_color[2] = BlueTrackBar.Value;
            BlueTrackbarLabel.Text = BlueTrackBar.Value.ToString();
            BlueTrackBarColor.BackColor = Color.FromArgb(0, 0, BlueTrackBar.Value);
            TrackBarsColor.BackColor = Color.FromArgb(RedTrackBar.Value, GreenTrackBar.Value, BlueTrackBar.Value);
        }

        private void Aux1TrackBar_ValueChanged(object sender, EventArgs e)
        {
            user_aux[0] = Aux1TrackBar.Value;
            Aux1TrackbarLabel.Text = Aux1TrackBar.Value.ToString();
        }

        private void Aux2Trackbar_ValueChanged(object sender, EventArgs e)
        {
            user_aux[1] = Aux2Trackbar.Value;
            Aux2TrackbarLabel.Text = Aux2Trackbar.Value.ToString();
        }

        private void DevicesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = (ComboBox)sender;
            device = (MMDevice)comboBox.SelectedItem!;
            AudioDeviceName.Text = device.DeviceFriendlyName;
            AudioDeviceType.Text = device.State.ToString();
        }

        private void ConnectCOMDeviceButton_Click(object sender, EventArgs e)
        {
            if (port != null && port.IsOpen)
            {
                port.Close();
                ConnectCOMDeviceButton.Text = "Connect";
                return;
            }

            if (string.IsNullOrEmpty(COMDevicesComboBox.Text))
            {
                MessageBox.Show("Please select a port...");
                return;
            }

            try
            {
                port = new SerialPort();
                port.BaudRate = 19200;
                port.PortName = COMDevicesComboBox.Text;
                //port.Handshake = Handshake.None;
                port.Parity = Parity.None;
                port.DataBits = 8;
                port.StopBits = StopBits.One;
                //port.WriteBufferSize = 8192;
                //port.ReadBufferSize = 8192;
                port.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
                port.DtrEnable = true;
                port.Open();
                port.DiscardInBuffer();
                ConnectCOMDeviceButton.Text = "Disconnect";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection failed...");
            }
        }

        private void RefreshCOMDevicesButton_Click(object sender, EventArgs e)
        {
            LoadAvailablePorts();
        }
    }

    public class LEDEffect
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
