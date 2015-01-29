/*
+-------------------------------- DISCLAIMER ---------------------------------+
|                                                                             |
| This application program is provided to you free of charge as an example.   |
| Despite the considerable efforts of Euresys personnel to create a usable    |
| example, you should not assume that this program is error-free or suitable  |
| for any purpose whatsoever.                                                 |
|                                                                             |
| EURESYS does not give any representation, warranty or undertaking that this |
| program is free of any defect or error or suitable for any purpose. EURESYS |
| shall not be liable, in contract, in torts or otherwise, for any damages,   |
| loss, costs, expenses or other claims for compensation, including those     |
| asserted by third parties, arising out of or in connection with the use of  |
| this program.                                                               |
|                                                                             |
+-----------------------------------------------------------------------------+
*/

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Threading;
using Euresys.MultiCam;
 

namespace PicoloVideo
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    /// 

    public class MainForm : System.Windows.Forms.Form
    {
        // Creation of an event for asynchronous call to paint function
        public delegate void PaintDelegate(Graphics g);
        public delegate void UpdateStatusBarDelegate(String text);

        // The object that will contain the acquired image
        private Bitmap image = null;

        // The Mutex object that will protect image objects during processing
        private static Mutex imageMutex = new Mutex();

        // The MultiCam object that controls the acquisition
        UInt32 channel;

        // The MultiCam object that contains the acquired buffer
        private UInt32 currentSurface;
        
        // Track if aquisition are ongoing
        private volatile bool channelactive;

        MC.CALLBACK multiCamCallback;

        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.StatusBar statusBar;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private System.Windows.Forms.MenuItem Go;
        private System.Windows.Forms.MenuItem Stop;
        private System.ComponentModel.IContainer components;

        public MainForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            // Show scope of the sample program
            MessageBox.Show(@"
                This program demonstrates the Video Acquisition Mode on a Picolo Board.
                
                The Go! menu starts an acquisition sequence by activating the channel.
                By default, this program requires an PAL camera connected on VID1.", "Sample program description", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.Go = new System.Windows.Forms.MenuItem();
            this.Stop = new System.Windows.Forms.MenuItem();
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.Go,
            this.Stop});
            // 
            // Go
            // 
            this.Go.Index = 0;
            this.Go.Text = "Go!";
            this.Go.Click += new System.EventHandler(this.Go_Click);
            // 
            // Stop
            // 
            this.Stop.Index = 1;
            this.Stop.Text = "Stop!";
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 534);
            this.statusBar.Name = "statusBar";
            this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1});
            this.statusBar.ShowPanels = true;
            this.statusBar.Size = new System.Drawing.Size(768, 56);
            this.statusBar.TabIndex = 0;
            this.statusBar.Text = "Ready. Click on the \'GO!\' button to start.";
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 300;
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 18);
            this.ClientSize = new System.Drawing.Size(768, 590);
            this.Controls.Add(this.statusBar);
            this.Menu = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "PicoloVideo";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.Closed += new System.EventHandler(this.MainForm_Closed);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new MainForm());
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {

            // + PicoloVideo Sample Program

            try
            {
                // Open MultiCam driver
                MC.OpenDriver();

                // Enable error logging
                MC.SetParam(MC.CONFIGURATION, "ErrorLog", "error.log");

                // Create a channel and associate it with the first connector on the first board
                MC.Create("CHANNEL", out channel);
                MC.SetParam(channel, "DriverIndex", 0);
                MC.SetParam(channel, "Connector", "VID1");

                //// Choose the video standard
                //MC.SetParam(channel, "CamFile", "PAL");
                //// Choose the pixel color format
                //MC.SetParam(channel, "ColorFormat", "RGB24");

                // Choose the video standard
                MC.SetParam(channel, "CamFile", "NTSC");
                // Choose the pixel color format
                MC.SetParam(channel, "ColorFormat", "Y8");
                //MC.SetParam(channel, "ColorFormat", "RGB24");

                // Choose the acquisition mode
                MC.SetParam(channel, "AcquisitionMode", "VIDEO");
                // Choose the way the first acquisition is triggered
                MC.SetParam(channel, "TrigMode", "IMMEDIATE");
                // Choose the triggering mode for subsequent acquisitions
                MC.SetParam(channel, "NextTrigMode", "REPEAT");
                // Choose the number of images to acquire
                MC.SetParam(channel, "SeqLength_Fr", MC.INDETERMINATE);

                // Register the callback function
                multiCamCallback = new MC.CALLBACK(MultiCamCallback);
                MC.RegisterCallback(channel, multiCamCallback, channel);

                // Enable the signals corresponding to the callback functions
                MC.SetParam(channel, MC.SignalEnable + MC.SIG_SURFACE_PROCESSING, "ON");
                MC.SetParam(channel, MC.SignalEnable + MC.SIG_ACQUISITION_FAILURE, "ON");
                MC.SetParam(channel, MC.SignalEnable + MC.SIG_END_CHANNEL_ACTIVITY, "ON");
                channelactive = false;

                // Prepare the channel in order to minimize the acquisition sequence startup latency
                MC.SetParam(channel, "ChannelState", "READY");
            }
            catch (Euresys.MultiCamException exc)
            {
                // An exception has occurred in the try {...} block. 
                // Retrieve its description and display it in a message box.
                MessageBox.Show(exc.Message, "MultiCam Exception");
                Close();
            }

            // - PicoloVideo Sample Program
        }


        private void MultiCamCallback(ref MC.SIGNALINFO signalInfo)
        {
            switch(signalInfo.Signal)
            {
                case MC.SIG_SURFACE_PROCESSING:
                    ProcessingCallback(signalInfo);
                    break;
                case MC.SIG_ACQUISITION_FAILURE:
                    AcqFailureCallback(signalInfo);
                    break;
                case MC.SIG_END_CHANNEL_ACTIVITY:
                    channelactive = false;
                    break;
                default:
                    throw new Euresys.MultiCamException("Unknown signal");
            }
        }

        private void ProcessingCallback(MC.SIGNALINFO signalInfo)
        {
            UInt32 currentChannel = (UInt32)signalInfo.Context;

            statusBar.Text = "Processing";
            currentSurface = signalInfo.SignalInfo;

            // + PicoloVideo Sample Program

            try
            {
                // Update the image with the acquired image buffer data 
                Int32 width, height, bufferPitch;
                IntPtr bufferAddress;
                MC.GetParam(currentChannel, "ImageSizeX", out width);
                MC.GetParam(currentChannel, "ImageSizeY", out height);
                MC.GetParam(currentChannel, "BufferPitch", out bufferPitch);
                //MessageBox.Show(width.ToString() + "  " + height.ToString() + "  " + bufferPitch.ToString());

                MC.GetParam(currentSurface, "SurfaceAddr", out bufferAddress);

                try
                {
                    imageMutex.WaitOne();
                    
                    // for rgb24

                   // image = new Bitmap(width, height, bufferPitch, PixelFormat.Format24bppRgb, bufferAddress);

                    image = new Bitmap(width, height, bufferPitch, PixelFormat.Format8bppIndexed, bufferAddress);

                    image.RotateFlip(RotateFlipType.Rotate180FlipY);

                    ColorPalette cp = image.Palette;
                    for (int i = 0; i < 256; i++)
                    {
                        cp.Entries[i] = Color.FromArgb(i, i, i);
                    }
                    image.Palette = cp;
                 

                    /* Insert image analysis and processing code here */
                }
                finally
                {
                    imageMutex.ReleaseMutex();
                }

                // Retrieve the frame rate
                Double frameRate_Hz;
                MC.GetParam(channel, "PerSecond_Fr", out frameRate_Hz);

                // Retrieve the channel state
                String channelState;
                MC.GetParam(channel, "ChannelState", out channelState);

                // Display frame rate and channel state
                statusBar.Text = String.Format("Frame Rate: {0:f2}, Channel State: {1}", frameRate_Hz, channelState);

                // Display the new image
                this.BeginInvoke(new PaintDelegate(Redraw), new object[1] { CreateGraphics() });
            }
            catch (Euresys.MultiCamException exc)
            {
                MessageBox.Show(exc.Message, "MultiCam Exception");
            }
            catch (System.Exception exc)
            {
                MessageBox.Show(exc.Message, "System Exception");
            }
        }

        private void AcqFailureCallback(MC.SIGNALINFO signalInfo)
        {
            UInt32 currentChannel = (UInt32)signalInfo.Context;

            // + PicoloVideo Sample Program

            try
            {
                // Display frame rate and channel state
                statusBar.Text = String.Format("Acquisition Failure, Channel State: IDLE");
                this.BeginInvoke(new PaintDelegate(Redraw), new object[1] { CreateGraphics() });
            }
            catch (System.Exception exc)
            {
                MessageBox.Show(exc.Message, "System Exception");
            }

            // - PicoloVideo Sample Program
        }

        private void UpdateStatusBar(String text)
        {
            statusBarPanel1.Text = text;
        }

        void Redraw(Graphics g)
        {
            // + PicoloVideo Sample Program

            try
            {
                imageMutex.WaitOne();

                if (image != null)
                    g.DrawImage(image, 0, 0);
                UpdateStatusBar(statusBar.Text);
            }
            catch (System.Exception exc)
            {
                MessageBox.Show(exc.Message, "System Exception");
            }
            finally
            {
                imageMutex.ReleaseMutex();
            }

            // - PicoloVideo Sample Program
        }

        private void MainForm_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Redraw(e.Graphics);
        }





        private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                Stop_Click(sender, e);
                // Whait that the channel has finished the last acquisition
                while (channelactive == true)
                {
                    Thread.Sleep(10);
                }

                // Delete the channel
                if (channel != 0)
                {
                    MC.Delete(channel);
                    channel = 0;
                }
            }
            catch (Euresys.MultiCamException exc)
            {
                MessageBox.Show(exc.Message, "MultiCam Exception");
            }
        }

        private void Go_Click(object sender, System.EventArgs e)
        {
            // + PicoloVideo Sample Program


            // Start an acquisition sequence by activating the channel
            String channelState;
            MC.GetParam(channel, "ChannelState", out channelState);
            if (channelState != "ACTIVE")
                MC.SetParam(channel, "ChannelState", "ACTIVE");
            Refresh();
            channelactive = true;

            // - PicoloVideo Sample Program
        }

        private void Stop_Click(object sender, System.EventArgs e)
        {
            // + PicoloVideo Sample Program
            // Stop an acquisition sequence by deactivating the channel
            if (channel != 0)
                MC.SetParam(channel, "ChannelState", "IDLE");
            UpdateStatusBar(String.Format("Frame Rate: {0:f2}, Channel State: IDLE", 0));

            if (image != null)
            {
                // Update the image with the acquired image buffer data 
                Int32 width, height, bufferPitch;
                IntPtr bufferAddress;
                UInt32 currentChannel = channel;
                MC.GetParam(currentChannel, "ImageSizeX", out width);
                MC.GetParam(currentChannel, "ImageSizeY", out height);
                MC.GetParam(currentChannel, "BufferPitch", out bufferPitch);
                //MessageBox.Show(width.ToString() + "  " + height.ToString() + "  " + bufferPitch.ToString());

                MC.GetParam(currentSurface, "SurfaceAddr", out bufferAddress); 

                Bitmap tempImage = new Bitmap(width, height, bufferPitch, PixelFormat.Format8bppIndexed, bufferAddress);


                tempImage.Save("temp.bmp");

                throw new Exception(CameraGrabResource.String1);
            }
        

            // - PicoloVideo Sample Program
        }

        private void MainForm_Closed(object sender, System.EventArgs e)
        {
            try
            {
                // Close MultiCam driver
                MC.CloseDriver();
            }
            catch (Euresys.MultiCamException exc)
            {
                MessageBox.Show(exc.Message, "MultiCam Exception");
            }
        }
    }
}
