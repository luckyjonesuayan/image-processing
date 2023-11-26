using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ImageProcessing
{
    public partial class Form1 : Form
    {
        private enum Process {
            BasicCopy,
            GreyScale,
            ColorInversion,
            Sepia,
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

        private Process currentProcess = Process.None; // tracks the current process
        private Bitmap sourceBitmap = null; // tracks the original source image
        private Bitmap destinationBitmap = null; // bitmap that facilitates thes processes

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
            label2.Text = "Hint: Double click the box below to directly export an image.";

            // init histogram   
            setResetHistogram();

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
            cbProcesses.SelectedIndex = (int) Process.BasicCopy;
            cbProcesses.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void InitializeCBHistogram()
        {
            // initializes the histogram dropdown
            cbHistogram.SelectedIndex = (int) HistogramData.Brightness;
            cbHistogram.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void initializeBitmaps()
        {
            sourceBitmap = new Bitmap(pBoxOriginal.Image);
            destinationBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);
        }

        private void BasicCopy()
        {
            initializeBitmaps();
            for (int i = 0; i < sourceBitmap.Width; i++)
            {
                for (int j = 0; j < sourceBitmap.Height; j++)
                {
                    Color pixelColor = sourceBitmap.GetPixel(i, j);
                    destinationBitmap.SetPixel(i, j, pixelColor);
                }
            }

            pBoxProcessed.Image = destinationBitmap;
        }


        private void GreyScale()
        {
            initializeBitmaps();
            for (int i = 0; i < sourceBitmap.Width; i++)
            {
                for (int j = 0; j < sourceBitmap.Height; j++)
                {
                    Color pixelColor = sourceBitmap.GetPixel(i, j);
                    int luminance = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);
                    Color grayscaleColor = Color.FromArgb(luminance, luminance, luminance);
                    destinationBitmap.SetPixel(i, j, grayscaleColor);
                }
            }

            pBoxProcessed.Image = destinationBitmap;
        }

        private void ColorInversion()
        {
            initializeBitmaps();

            for (int i = 0; i < sourceBitmap.Width; i++)
            {
                for (int j = 0; j < sourceBitmap.Height; j++)
                {
                    Color pixelColor = sourceBitmap.GetPixel(i, j);

                    int invertedR = 255 - pixelColor.R;
                    int invertedG = 255 - pixelColor.G;
                    int invertedB = 255 - pixelColor.B;

                    Color invertedColor = Color.FromArgb(invertedR, invertedG, invertedB);

                    destinationBitmap.SetPixel(i, j, invertedColor);
                }
            }

            pBoxProcessed.Image = destinationBitmap;
        }


        private void Sepia()
        {
            initializeBitmaps();

            for (int i = 0; i < sourceBitmap.Width; i++)
            {
                for (int j = 0; j < sourceBitmap.Height; j++)
                {
                    Color pixelColor = sourceBitmap.GetPixel(i, j);

                    int sepiaR = (int)(0.393 * pixelColor.R + 0.769 * pixelColor.G + 0.189 * pixelColor.B);
                    int sepiaG = (int)(0.349 * pixelColor.R + 0.686 * pixelColor.G + 0.168 * pixelColor.B);
                    int sepiaB = (int)(0.272 * pixelColor.R + 0.534 * pixelColor.G + 0.131 * pixelColor.B);

                    sepiaR = Math.Min(255, Math.Max(0, sepiaR));
                    sepiaG = Math.Min(255, Math.Max(0, sepiaG));
                    sepiaB = Math.Min(255, Math.Max(0, sepiaB));

                    Color sepiaColor = Color.FromArgb(sepiaR, sepiaG, sepiaB);

                    destinationBitmap.SetPixel(i, j, sepiaColor);
                }
            }

            pBoxProcessed.Image = destinationBitmap;
        }

        private void HistogramBrightness()
        {
            for (int i = 0; i < destinationBitmap.Width; i++)
            {
                for (int j = 0; j < destinationBitmap.Height; j++)
                {
                    Color pixelColor = destinationBitmap.GetPixel(i, j);

                    int brightness = (int)(0.299 * pixelColor.R + 0.587 * pixelColor.G + 0.114 * pixelColor.B);

                    histogram[brightness]++;
                }
            }

            chart1.Series.Clear();
        }

        private void HistogramContrast()
        {
            for (int i = 0; i < destinationBitmap.Width; i++)
            {
                for (int j = 0; j < destinationBitmap.Height; j++)
                {
                    Color pixelColor = destinationBitmap.GetPixel(i, j);

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
            for (int i = 0; i < destinationBitmap.Width; i++)
            {
                for (int j = 0; j < destinationBitmap.Height; j++)
                {
                    Color pixelColor = destinationBitmap.GetPixel(i, j);
                    int redValue = pixelColor.R;
                    histogram[redValue]++;
                }
            }

            chart1.Series.Clear();
        }
        private void HistogramGreen()
        {
            for (int i = 0; i < destinationBitmap.Width; i++)
            {
                for (int j = 0; j < destinationBitmap.Height; j++)
                {
                    Color pixelColor = destinationBitmap.GetPixel(i, j);
                    int greenValue = pixelColor.G;
                    histogram[greenValue]++;
                }
            }

            chart1.Series.Clear();
        }

        private void HistogramBlue()
        {
            for (int i = 0; i < destinationBitmap.Width; i++)
            {
                for (int j = 0; j < destinationBitmap.Height; j++)
                {
                    Color pixelColor = destinationBitmap.GetPixel(i, j);
                    int blueValue = pixelColor.B;
                    histogram[blueValue]++;
                }
            }

            chart1.Series.Clear();
        }


        private void GenerateHistogram()
        {
            switch(currentHistogramSelection)
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
            // Create a SaveFileDialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JPEG Image|*.jpg|PNG Image|*.png|Bitmap Image|*.bmp|All Files|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the file path chosen by the user
                string filePath = saveFileDialog.FileName;

                // Save the processed image (destinationBitmap) to the chosen file path
                destinationBitmap.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);

                MessageBox.Show("Image saved successfully!");
            }
        }


        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // exporting processed image
            SaveImage();

        }

        private void cbOperations_SelectedIndexChanged(object sender, EventArgs e)
        {
            // combobox processes (copy, greyscale, sepia, etc.) selector
            currentProcess = (Process) cbProcesses.SelectedIndex;
        }

        private void cbHistogram_SelectedIndexChanged(object sender, EventArgs e)
        {
            // combobox histogram selector
            currentHistogramSelection = (HistogramData) cbHistogram.SelectedIndex;
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
        }


        private void btnRun_Click(object sender, EventArgs e)
        {
            // running

            if (pBoxOriginal.Image != null)
            {
                labelCurrProcess.Text = cbProcesses.Text;
                PerformProcess();
                GenerateHistogram();
            }
            else
            {
                MessageBox.Show("No image found. Please import and image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenImportImageDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pBoxOriginal.Image = System.Drawing.Image.FromFile(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading the image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenImportImageDialog();
        }

        private void pBoxOriginal_DoubleClick(object sender, EventArgs e)
        {
            OpenImportImageDialog();
        }

        private void pBoxProcessed_DoubleClick(object sender, EventArgs e)
        {
            SaveImage();
        }
    }
}
