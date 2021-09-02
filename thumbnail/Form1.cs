using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thumbnail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                var fileDlg = new OpenFileDialog();
                fileDlg.ShowDialog();
                textBox1.Text = fileDlg.FileName;
            pictureBox1.Image = Image.FromFile(fileDlg.FileName);
          
        }

        private void CreateThumbnail( string imgeFile)
        {
            if (File.Exists(imgeFile))
            {



                string dir = new FileInfo(imgeFile).DirectoryName;

                string imagename = imgeFile.Split(Path.DirectorySeparatorChar).Last();


                var name = imagename.Split('.');
                String fullimagename = name[0];



                string Location = dir;
                string pathfolder = System.IO.Path.Combine(Location, fullimagename);


                System.IO.Directory.CreateDirectory(pathfolder);


                string thumFilePath = Path.Combine(pathfolder, "thumbnail.jpeg");//mm

                System.Drawing.Image image = System.Drawing.Image.FromFile(imgeFile);
                var thumImage = image.GetThumbnailImage(64, 64, new Image.GetThumbnailImageAbort(() => false), IntPtr.Zero);
                thumImage.Save(thumFilePath, System.Drawing.Imaging.ImageFormat.Jpeg);

                MessageBox.Show("ThumNail Save Your Image Path");
            }
            else
            {
                MessageBox.Show("Please add Image.");
            }   
      
                       
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            CreateThumbnail(textBox1.Text);
           
          
        }
    }
}
