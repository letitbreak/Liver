using System;
using System.Runtime.InteropServices;
using OpenCvSharp;
using System.Windows.Forms;

namespace Project_Liver
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            /*
            IplImage src = Cv.LoadImage(Application.StartupPath + @"/images/liver.png", LoadMode.GrayScale);
            IplImage dst = Cv.CreateImage(new CvSize(src.Width, src.Height), BitDepth.U8, 1);
            IplImage test = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            //
            
            //Cv.Threshold(src, dst, 50, 300, ThresholdType.Binary);
            Cv.Canny(src, dst, 80, 110);
            //Cv.Laplace(dst, test, (OpenCvSharp.ApertureSize) 3);
            //
            Cv.NamedWindow("src image"); 
            Cv.ShowImage("src image", src);
            //
            Cv.NamedWindow("dst image");  
            Cv.ShowImage("dst image", dst);
            //
            //Cv.NamedWindow("test image");
            //Cv.ShowImage("test image", test);
            //
            Cv.WaitKey();
            Cv.DestroyAllWindows();
            //
            Cv.ReleaseImage(src);
            Cv.ReleaseImage(dst);
            //Cv.ReleaseImage(test);
            */
        }

    }
}
