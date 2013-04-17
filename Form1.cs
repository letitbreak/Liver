using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenCvSharp;

namespace Project_Liver
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            IplImage src = Cv.LoadImage(Application.StartupPath + @"/images/liver.png", LoadMode.GrayScale);
            IplImage dst = Cv.CreateImage(src.Size, BitDepth.U8, 1);

            /*
            using (IplImage img = new IplImage(Application.StartupPath + @"/images/liver.png", LoadMode.GrayScale))
            {
                IplImage dst = Cv.CreateImage(img.Size, BitDepth.U8, 1);
                Cv.Canny(img, dst, 80, 110);

                CvSeq<CvPoint> contours;
                CvMemStorage storage = new CvMemStorage();

                Cv.FindContours(dst, storage, out contours, CvContour.SizeOf, ContourRetrieval.Tree, ContourChain.ApproxSimple);
                contours = Cv.ApproxPoly(contours, CvContour.SizeOf, storage, ApproxPolyMethod.DP, 3, true);


                //img.FindContours(storage, out contours, ContourRetrieval.Tree, ContourChain.ApproxSimple);
                //contours = contours.ApproxPoly(storage, ApproxPolyMethod.DP, 3, true);

                using (CvWindow window_image = new CvWindow("image", dst))
                using (CvWindow window_contours = new CvWindow("contours"))
                {
                    CvTrackbarCallback onTrackbar = delegate(int pos)
                    {
                        IplImage cnt_img = new IplImage(img.Size, BitDepth.U8, 3);
                        CvSeq<CvPoint> _contours = contours;
                        int levels = pos - 3;
                        if (levels <= 0) // get to the nearest face to make it look more funny
                        {
                            //_contours = _contours.HNext.HNext.HNext;
                        }
                        cnt_img.Zero();
                        Cv.DrawContours(cnt_img, _contours, CvColor.Red, CvColor.Green, levels, 3, LineType.AntiAlias);
                        window_contours.ShowImage(cnt_img);
                        cnt_img.Dispose();
                    };
                    window_contours.CreateTrackbar("levels+3", 3, 7, onTrackbar);
                    onTrackbar(3);

                    Cv.WaitKey();
                }
            }
            */
            //Cv.NamedWindow("Исходное изображение");
            //Cv.ShowImage("Исходное изображение", src);

        }

        private void открытьИзображениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            od.Title = "Открыть изображение";
            if (od.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Load(od.FileName);
                }
                catch
                {
                    MessageBox.Show("Проверьте правильность пути расположения файла изображения!", "Ошибка загрузки изображения ...");
                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                IplImage img = Cv.LoadImage(pictureBox1.ImageLocation, LoadMode.GrayScale);
                IplImage dst = Cv.CreateImage(img.Size, BitDepth.U8, 1);
                Cv.Canny(img, dst, Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text));
                
                Cv.NamedWindow("Canny");
                Cv.ShowImage("Canny", dst);
            }
            catch
            {
                MessageBox.Show("Возможно вы забыли загрузить изображение или неправильно введены данные постоения!","Ошибка построения");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                IplImage img = Cv.LoadImage(pictureBox1.ImageLocation, LoadMode.GrayScale);
                IplImage dst = Cv.CreateImage(img.Size, BitDepth.U8, 1);
                Cv.Laplace(img,dst);

                Cv.NamedWindow("Laplace");
                Cv.ShowImage("Laplace", dst);
            }
            catch 
            {
                MessageBox.Show("Возможно вы забыли загрузить изображение или неправильно введены данные постоения!", "Ошибка построения");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try 
            {
                IplImage img = Cv.LoadImage(pictureBox1.ImageLocation, LoadMode.Color);
                
            }
            catch
            {
                MessageBox.Show("Возможно вы забыли загрузить изображение или неправильно введены данные постоения!", "Ошибка построения");
            }
        }
    }
}
