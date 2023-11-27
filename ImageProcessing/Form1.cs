using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using AForge.Video;
using AForge.Video.DirectShow;

namespace ImageProcessing
{
    public partial class Form1 : Form
    {
        private enum Process
        {
            BasicCopy,
            GreyScale,
            ColorInversion,
            Sepia,
            Subtract,
            None
        }

        private enum HistogramData
        {
            Brightness,
            Contrast,
            Red,
            Green,
            Blue,

        }

        private VideoCaptureDevice videoDevice;

        private Process currentProcess = Process.None; // tracks the current process
        private Bitmap image1 = null; // tracks the original source image
        private Bitmap image2 = null; // bitmap that facilitates thes processes
        private Bitmap image3 = null; // result of subtraction

        private HistogramData currentHistogramSelection = HistogramData.Brightness;
        private int[] histogram = new int[256];

        bool[] processClicked = { false, false, false, false };

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;

            // comboxes
            InitializeCBProcesses();
            InitializeCBHistogram();

            labelDescription1.Text = "Hint: Double click the box below to directly import an image.";

            // init histogram   
            setResetHistogram();

            InitializeWebcam();
        }

        private void InitializeWebcam()
        {
            FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count > 0)
            {
                videoDevice = new VideoCaptureDevice(videoDevices[0].MonikerString);
                videoDevice.NewFrame += VideoDevice_NewFrame;
            }
            else
            {
                MessageBox.Show("No video devices found.");
                this.Close();
            }
        }

        private void VideoDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // Update the PictureBox with the new frame
            image2 = (Bitmap)eventArgs.Frame.Clone();
            pBox2.Image = image2;
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Stop the webcam when the form is closing
            if (videoDevice != null && videoDevice.IsRunning)
            {
                videoDevice.SignalToStop();
                videoDevice.WaitForStop();
            }
        }

        private void setResetHistogram()
        {
            chart1.Legends.Clear();
            for (int i = 0; i < 256; i++)
            {
                histogram[i] = 0;
            }
        }

        private void InitializeCBProcesses()
        {
            // initializes the processes (copy, greyscale, sepia, etc.) dropdown 
            cbProcesses.SelectedIndex = (int)Process.BasicCopy;
            cbProcesses.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void InitializeCBHistogram()
        {
            // initializes the histogram dropdown
            cbHistogram.SelectedIndex = (int)HistogramData.Brightness;
            cbHistogram.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void initializeBitmaps()
        {
            image1 = new Bitmap(pBox1.Image);
            image2 = new Bitmap(image1.Width, image1.Height);
            image3 = new Bitmap(image1.Width, image1.Height);
        }

        private void BasicCopy()
        {
            initializeBitmaps();
            for (int i = 0; i < image1.Width; i++)
            {
                for (int j = 0; j < image1.Height; j++)
                {
                    Color pixelColor = image1.GetPixel(i, j);
                    image2.SetPixel(i, j, pixelColor);
                }
            }

            pBox2.Image = image2;
        }


        private void GreyScale()
        {
            initializeBitmaps();
            for (int i = 0; i < image1.Width; i++)
            {
                for (int j = 0; j < image1.Height; j++)
                {
                    Color pixelColor = image1.GetPixel(i, j);
                    int luminance = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                    Color grayscaleColor = Color.FromArgb(luminance, luminance, luminance);
                    image2.SetPixel(i, j, grayscaleColor);
                }
            }

            pBox2.Image = image2;
        }

        private void ColorInversion()
        {
            initializeBitmaps();

            for (int i = 0; i < image1.Width; i++)
            {
                for (int j = 0; j < image1.Height; j++)
                {
                    Color pixelColor = image1.GetPixel(i, j);

                    int invertedR = 255 - pixelColor.R;
                    int invertedG = 255 - pixelColor.G;
                    int invertedB = 255 - pixelColor.B;

                    Color invertedColor = Color.FromArgb(invertedR, invertedG, invertedB);

                    image2.SetPixel(i, j, invertedColor);
                }
            }

            pBox2.Image = image2;
        }


        private void Sepia()
        {
            initializeBitmaps();

            for (int i = 0; i < image1.Width; i++)
            {
                for (int j = 0; j < image1.Height; j++)
                {
                    Color pixelColor = image1.GetPixel(i, j);

                    int sepiaR = (int)(0.393 * pixelColor.R + 0.769 * pixelColor.G + 0.189 * pixelColor.B);
                    int sepiaG = (int)(0.349 * pixelColor.R + 0.686 * pixelColor.G + 0.168 * pixelColor.B);
                    int sepiaB = (int)(0.272 * pixelColor.R + 0.534 * pixelColor.G + 0.131 * pixelColor.B);

                    sepiaR = Math.Min(255, Math.Max(0, sepiaR));
                    sepiaG = Math.Min(255, Math.Max(0, sepiaG));
                    sepiaB = Math.Min(255, Math.Max(0, sepiaB));

                    Color sepiaColor = Color.FromArgb(sepiaR, sepiaG, sepiaB);

                    image2.SetPixel(i, j, sepiaColor);
                }
            }

            pBox2.Image = image2;
        }

        private void HistogramBrightness()
        {
            for (int i = 0; i < image2.Width; i++)
            {
                for (int j = 0; j < image2.Height; j++)
                {
                    Color pixelColor = image2.GetPixel(i, j);

                    int brightness = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);

                    histogram[brightness]++;
                }
            }

            chart1.Series.Clear();
        }

        private void HistogramContrast()
        {
            for (int i = 0; i < image2.Width; i++)
            {
                for (int j = 0; j < image2.Height; j++)
                {
                    Color pixelColor = image2.GetPixel(i, j);

                    int maxChannel = Math.Max(Math.Max(pixelColor.R, pixelColor.G), pixelColor.B);
                    int minChannel = Math.Min(Math.Min(pixelColor.R, pixelColor.G), pixelColor.B);
                    int contrast = (maxChannel - minChannel) * 255 / (maxChannel + minChannel + 1);

                    histogram[contrast]++;
                }
            }

            chart1.Series.Clear();
        }

        private void HistogramRed()
        {
            for (int i = 0; i < image2.Width; i++)
            {
                for (int j = 0; j < image2.Height; j++)
                {
                    Color pixelColor = image2.GetPixel(i, j);
                    int redValue = pixelColor.R;
                    histogram[redValue]++;
                }
            }

            chart1.Series.Clear();
        }
        private void HistogramGreen()
        {
            for (int i = 0; i < image2.Width; i++)
            {
                for (int j = 0; j < image2.Height; j++)
                {
                    Color pixelColor = image2.GetPixel(i, j);
                    int greenValue = pixelColor.G;
                    histogram[greenValue]++;
                }
            }

            chart1.Series.Clear();
        }

        private void HistogramBlue()
        {
            for (int i = 0; i < image2.Width; i++)
            {
                for (int j = 0; j < image2.Height; j++)
                {
                    Color pixelColor = image2.GetPixel(i, j);
                    int blueValue = pixelColor.B;
                    histogram[blueValue]++;
                }
            }

            chart1.Series.Clear();
        }


        private void GenerateHistogram()
        {
            switch (currentHistogramSelection)
            {
                case HistogramData.Brightness:
                    HistogramBrightness();
                    break;
                case HistogramData.Contrast:
                    HistogramContrast();
                    break;
                case HistogramData.Red:
                    HistogramRed();
                    break;
                case HistogramData.Green:
                    HistogramGreen();
                    break;
                case HistogramData.Blue:
                    HistogramBlue();
                    break;
            }

            // chart population
            Series series = new Series();
            series.ChartType = SeriesChartType.Column;

            series["PointWidth"] = "1.0";
            series.BorderWidth = 0;

            for (int i = 0; i < 256; i++)
            {
                series.Points.AddXY(i, histogram[i]);
            }

            chart1.Series.Add(series);
            chart1.Legends.Clear();

            chart1.ChartAreas[0].AxisX.Title = "";
            chart1.ChartAreas[0].AxisY.Title = "";

            chart1.Update();
            setResetHistogram();
        }

        private void SaveImage()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JPEG Image|*.jpg|PNG Image|*.png|Bitmap Image|*.bmp|All Files|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                image2.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                MessageBox.Show("Image saved successfully!");
            }
        }


        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // exporting processed image
            SaveImage();

        }

        private void cbProcess_SelectedIndexChanged(object sender, EventArgs e)
        {
            // combobox processes (copy, greyscale, sepia, etc.) selector
            currentProcess = (Process)cbProcesses.SelectedIndex;
            if (currentProcess == Process.Subtract)
            {
                labelDescription1.Text = "Hint: Double click to load image.";
                labelDescription2.Text = "Hint: Double click to load background.";
            }
        }

        private void cbHistogram_SelectedIndexChanged(object sender, EventArgs e)
        {
            // combobox histogram selector
            currentHistogramSelection = (HistogramData)cbHistogram.SelectedIndex;
        }

        private void PerformProcess()
        {
            switch (currentProcess)
            {
                case Process.BasicCopy:
                    BasicCopy();
                    break;
                case Process.GreyScale:
                    GreyScale();
                    break;
                case Process.ColorInversion:
                    ColorInversion();
                    break;
                case Process.Sepia:
                    Sepia();
                    break;

            }
            labelDescription2.Text = "Hint: Double click the box below to directly export an image.";
        }

        private void SubtractWithNoOpenCam()
        {
            // Resize images to have the same dimensions
            ResizeImagesToSameDimensions();
            Bitmap image3 = new Bitmap(image1.Width, image1.Height);
            Color green = Color.FromArgb(0, 255, 0);
            int threshold = 95;

            for (int x = 0; x < image1.Width; x++)
            {
                for (int y = 0; y < image1.Height; y++)
                {
                    Color pixel = image1.GetPixel(x, y);
                    Color backPixel = image2.GetPixel(x, y);
                    int subtractValue = CalculateColorDifference(pixel, green);
                    if (subtractValue <= threshold)
                    {
                        image3.SetPixel(x, y, backPixel);
                    }
                    else
                    {
                        image3.SetPixel(x, y, pixel);
                    }
                }
            }
            pBox3.Image = image3;
        }

        private void SubtractWithOpenCam()
        {
            if (image2 != null && image1.Width == image2.Width && image1.Height == image2.Height)
            {
                image3 = new Bitmap(image1.Width, image1.Height);
                Color backgroundColor = Color.FromArgb(0, 255, 0);
                int threshold = 95;
                for (int x = 0; x < image1.Width; x++)
                {
                    for (int y = 0; y < image1.Height; y++)
                    {
                        Color livePixel = image2.GetPixel(x, y);
                        Color originalPixel = image1.GetPixel(x, y);
                        int subtractValue = CalculateColorDifference(livePixel, backgroundColor);
                        if (subtractValue <= threshold)
                        {
                            image3.SetPixel(x, y, livePixel);
                        }
                        else
                        {
                            image3.SetPixel(x, y, originalPixel);
                        }
                    }
                }
                pBox3.Image = image3;
            }
            else
            {
                ShowErrorMessage("Please load a background image and ensure both images have the same dimensions.");
            }
        }


        private void Subtract()
        {
            if (videoDevice != null && videoDevice.IsRunning)
            {
                labelCurrProcess.Text = "Subtraction - Live Footage";
                SubtractWithOpenCam();
                pBoxIcon.Visible = true;
            }
            else
                SubtractWithNoOpenCam();
        }

        private int CalculateColorDifference(Color c1, Color c2)
        {
            int diffR = Math.Abs(c1.R - c2.R);
            int diffG = Math.Abs(c1.G - c2.G);
            int diffB = Math.Abs(c1.B - c2.B);
            return (diffR + diffG + diffB) / 3;
        }

        private void ResizeImagesToSameDimensions()
        {
            if (image1.Width != image2.Width || image1.Height != image2.Height)
            {
                int targetWidth = Math.Max(image1.Width, image2.Width);
                int targetHeight = Math.Max(image1.Height, image2.Height);
                image1 = ResizeImage(image1, targetWidth, targetHeight);
                image2 = ResizeImage(image2, targetWidth, targetHeight);
            }
        }

        private Bitmap ResizeImage(Bitmap image, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.DrawImage(image, 0, 0, width, height);
            }
            return resizedImage;
        }



        private void btnRun_Click(object sender, EventArgs e)
        {
            // running
            if (pBox1.Image != null && currentProcess != Process.Subtract)
            {
                labelCurrProcess.Text = cbProcesses.Text;
                PerformProcess();
                GenerateHistogram();
            }
            else if (pBox1.Image == null && currentProcess != Process.Subtract)
                ShowErrorMessage("No image found. Please import an image.");

            if (currentProcess == Process.Subtract && pBox2.Image != null)
            {
                labelCurrProcess.Text = "Subtraction";
                Subtract();
            }
            else if (currentProcess == Process.Subtract && pBox2.Image == null)
                ShowErrorMessage("Please load a background image.");
        }

        private void OpenImportImageDialog(PictureBox pbox, int pboxNum)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pbox.Image = System.Drawing.Image.FromFile(openFileDialog.FileName);
                    if (pboxNum == 1)
                        image1 = new Bitmap(openFileDialog.FileName);
                    if (pboxNum == 2)
                        image2 = new Bitmap(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading the image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenImportImageDialog(pBox1, 1);
        }

        private void pBox1_DoubleClick(object sender, EventArgs e)
        {
            OpenImportImageDialog(pBox1, 1);
        }

        private void ShowErrorMessage(String message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void pBox2_DoubleClick(object sender, EventArgs e)
        {
            if (currentProcess == Process.Subtract)
            {
                OpenImportImageDialog(pBox2, 2);
                cbProcesses.SelectedIndex = (int)Process.Subtract;
            }
            else if (
                pBox1.Image != null &&
                pBox2.Image != null &&
                currentProcess != Process.Subtract
            )
            {
                SaveImage();
            }
        }

        private void StartCam()
        {
            cbProcesses.SelectedIndex = (int)Process.Subtract;
            videoDevice.Start();
            btnOpenCam.Enabled = false;
            btnCloseCam.Enabled = true;
        }

        private void btnOpenCam_Click(object sender, EventArgs e)
        {
            // pBoxIcon.Visible = false;
            pBoxIcon.Enabled = false;
            StartCam();
        }

        private void pBoxIcon_DoubleClick(object sender, EventArgs e)
        {
            StartCam();
        }

        private void loadImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenImportImageDialog(pBox1, 1);
        }

        private void loadBackgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenImportImageDialog(pBox2, 2);
            cbProcesses.SelectedIndex = (int)Process.Subtract;
        }

        private void btnCloseCam_Click(object sender, EventArgs e)
        {

            if (videoDevice != null && videoDevice.IsRunning)
            {
                videoDevice.SignalToStop();
                videoDevice.WaitForStop();
                btnCloseCam.Enabled = false;
                btnOpenCam.Enabled = true;
            }
        }
    }
}
