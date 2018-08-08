using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp1


{ 
struct  LensData
{


        public int width;
        public int height;

        public double distance;
        public double curvature;

        public Bitmap lensBuffer;
};


    struct Pixel
    {
        public byte a, r, g, b;
    }

    public partial class Form1 : Form
    {
        LensData  Lens3()
        {

             int width; // ecx@15

            

            LensData lensData = new LensData();

            lensData.distance = 10;
            lensData.width = 800;
            lensData.height = 800;
            lensData.lensBuffer = new Bitmap(lensData.width, lensData.height);
   

      
            lensData.curvature = 4.2;
            double radius = lensData.width / 2.0f;
            double curvatureradius = lensData.curvature * lensData.width / 2.0f;
            double xVal = 0.0;
            double yVal = 0.0;
            for (int i = 0; i < lensData.width; i++)
            {
                for (int j = 0; j < lensData.width; j++)
                {
                    double sqrdistance = Math.Math.Pow(i - radius, 2) + Math.Math.Pow(j - radius, 2);
                    if (sqrdistance < Math.Math.Pow(radius, 2))
                    {
                        double diff = Math.Sqrt(Math.Math.Pow(curvatureradius, 2) - sqrdistance) - Math.Sqrt(Math.Math.Pow(curvatureradius, 2) - Math.Math.Pow(radius, 2));
                        diff = diff / (diff + (lensData.distance * radius));
                        yVal = std::max(yVal, fabs(diff * (i - radius)));
                        xVal = std::max(xVal, fabs(diff * (j - radius)));
                    }
                }
            }


            double xVal2 = 256.0 / (xVal + 1.0);
            double yVal2 = 256.0 / (yVal + 1.0);
            for (int i = 0; i < width; i++)
            {
                Pixel currentPixel;
                for (int j = 0; j < width; j++)
                {
                    double sqrdistance = Math.Pow(i - radius, 2) + Math.Pow(j - radius, 2);
                    if (sqrdistance < Math.Pow(radius, 2))
                    {
                        double diff = Math.Sqrt(Math.Pow(curvatureradius, 2) - sqrdistance) - Math.Sqrt(Math.Pow(curvatureradius, 2) - Math.Pow(radius, 2));
                        diff = diff / (diff + (lensData.distance * radius));
                        double val = xVal2 * diff * (j - radius);
                        double intpart;
                        double fracpart = (modf(val, &intpart));
                        double val2 = fsel(fracpart, intpart, intpart - 1.0);
                        double val3 = fsel(1.0e18 - fabs(val), val2, val);
                        double finalValue = -fsel(-fabs(val), val, val3);
                        if (finalValue == 0.0) finalValue = -1.5;

                        int r11 = 0;
                        int r10 = (int)finalValue;
                        if (j >= radius)
                        {
                            
                            currentPixel.a = 0xFF;
                        }
                        else currentPixel.a = 0;

                        int r9 = r10 >> 31;
                        r10 = r10 ^ r9;
                        r11 = r9 - r10;
                        r11 = r11 & 0xFF;
                        r11 = 255 - r11;
                        currentPixel.g = (byte)
                            
                            
                            
                            
                           
                            r11;



                        val = yVal2 * diff * (i - radius);
                        fracpart = (modf(val, &intpart));
                        val2 = fsel(fracpart, intpart, intpart - 1.0);
                        val3 = fsel(1.0e18 - fabs(val), val2, val);
                        finalValue = -fsel(-fabs(val), val, val3);


                        if (finalValue == 0.0)
                        {
                            finalValue = -1.5;
                        }

                        r10 = (int)finalValue;
                        if (i >= radius)
                        {
                            r11 = 0xFF;
                        }
                        else r11 = 0;
                        currentPixel.b = r11;

                        r9 = r10 >> 31;
                        r10 = r10 ^ r9;
                        r11 = r9 - r10;
                        r11 = r11 & 0xFF;
                        r11 = 255 - r11;
                        currentPixel.r = r11;


                    }
                    currentPixel++;
                }
            }


            return 0;
        }


        public Form1()
        {
            InitializeComponent();
        }
    }
}
