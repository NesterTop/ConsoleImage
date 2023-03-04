using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleImage
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string path = "";
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    path = ofd.FileName;
                }
            }
            

            Image img = Image.FromFile(path);
            Bitmap bmp = new Bitmap(img, new Size(800, 200));
            


            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    var pixel = bmp.GetPixel(x, y);
                    int avg = (pixel.R + pixel.G + pixel.B) / 3;

                    bmp.SetPixel(x, y, Color.FromArgb(avg, avg, avg));

                    int offset = (pixel.R + pixel.G + pixel.B);
                    Console.Write(Map(offset));
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        static bool Range(int value, int start, int end)
        {
            return value >= start && value <= end;
        }

        static char Map(int offset)
        {
            string strChars = ".,:+*?%S#@";
            //string strChars = "1234567890";

            if (Range(offset, 0, 50)) return strChars[0];
            else if (Range(offset, 51, 100)) return strChars[1];
            else if (Range(offset, 101, 150)) return strChars[2];
            else if (Range(offset, 151, 200)) return strChars[3];
            else if (Range(offset, 201, 250)) return strChars[4];
            else if (Range(offset, 251, 300)) return strChars[5];
            else if (Range(offset, 301, 350)) return strChars[6];
            else if (Range(offset, 351, 400)) return strChars[7];
            else if (Range(offset, 401, 451)) return strChars[8];
            else return strChars[9];
        }
    }
}
