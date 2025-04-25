using System;
using System.IO;
public sealed class Program
{
    public static void Main()
    {
        using (Stream from = new FileStream(@"/Users/lamfine/ml/file.txt", FileMode.Open))
        using (Stream to = new FileStream(@"/Users/lamfine/ml/newfile.txt", FileMode.OpenOrCreate))
        {
            int readCount;
            byte[] buffer = new byte[1024];
            while ((readCount = from.Read(buffer, 0, 1024)) != 0)
            {
                to.Write(buffer, 0, readCount);
            }
        }
    }
}
