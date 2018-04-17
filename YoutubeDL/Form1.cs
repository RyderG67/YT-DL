using System;
using System.Windows.Forms;
using System.IO;
using VideoLibrary;
using MediaToolkit.Model;
using MediaToolkit;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        private void btnDownload_Click(object sender, EventArgs e)
        {
            YouTube youtube = YouTube.Default;
            Video vid = youtube.GetVideo(txtUrl.Text);
            File.WriteAllBytes(Application.StartupPath + "\\" + vid.FullName, vid.GetBytes());

            var inputFile = new MediaFile { Filename = Application.StartupPath + "\\" + vid.FullName };
            var filename = Application.StartupPath + "\\" + vid.FullName;
            filename = filename.Replace(" - YouTube.mp4", "");
            var outputFile = new MediaFile { Filename = $"{filename}.mp3" };

            using (var engine = new Engine())
            {
                engine.GetMetadata(inputFile);

                engine.Convert(inputFile, outputFile);
            }
            File.Delete(Application.StartupPath + "\\" + vid.FullName);
            System.Windows.Forms.MessageBox.Show("Finish");
        }
    }
}
