using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exp1app
{
    class FileStreamTest
    {
        static void Main(string[] args)
        {
            try
            {
                //StreamReader infile = File.OpenText(@"InputTextFile.txt");
                StreamReader infile = File.OpenText(@"InputTextFile.txt");
                StreamWriter outfile = File.CreateText(@"OutputTextFile.txt");
                string tmpstr = null;
                Stopwatch timer = new Stopwatch();

                timer.Start();
                while ((tmpstr = infile.ReadLine()) != null)
                {
                    outfile.WriteLine(tmpstr);
                }
                timer.Stop();
                //Console.WriteLine("Elapsed time = {0} ms", timer.ElapsedMilliseconds);
                Console.WriteLine("Elapsed time = {0} Ticks", timer.ElapsedTicks);
                infile.Close();
                outfile.Close();

                Console.WriteLine();
                Console.WriteLine(File.ReadAllText(@"OutputTextFile.txt"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
