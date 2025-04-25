using System;
using System.IO;
using System.Text;

namespace FileOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName = "Hui";
            string lastName = "Lin";

            // file path
            string text1Path = "/Users/lamfine/ml/text1.txt";
            string text2Path = "/Users/lamfine/ml/text2.txt";

            // create text1 and write name by 10 times
            using (StreamWriter writer = new StreamWriter(text1Path))
            {
                for (int i = 0; i < 10; i++)
                {
                    writer.WriteLine(firstName);
                    writer.WriteLine(lastName);
                }
            }

            // copy text1 to text2
            byte[] buffer = new byte[1024];
            using (FileStream fs1 = new FileStream(text1Path, FileMode.Open, FileAccess.Read))
            using (FileStream fs2 = new FileStream(text2Path, FileMode.Create, FileAccess.Write))
            {
                int readCount;
                while ((readCount = fs1.Read(buffer, 0, 1024)) != 0)
                {
                    fs2.Write(buffer, 0, readCount);
                }
            }

            Console.WriteLine("\nText1 Block:   ");
            using (Stream s = new FileStream(@"/Users/lamfine/ml/text1.txt", FileMode.Open))
            {
                int read;
                while ((read = s.ReadByte()) != -1)
                {
                    Console.Write("{0} ", read);
                }
            }

            Console.WriteLine("\nText2 Block:   ");
            using (Stream s = new FileStream(@"/Users/lamfine/ml/text2.txt", FileMode.Open))
            {
                int read;
                while ((read = s.ReadByte()) != -1)
                {
                    Console.Write("{0} ", read);
                }
            }
        }
    }
}