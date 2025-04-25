using System;
using System.IO;
using System.IO.Compression;


public sealed class Program
{
    public static void Main()
    {
        //  FileStream fs1 = File.Create(@"/Users/lamfine/Documents/[FDU]/CSCI7645 SP/cmpz/myfile1.txt");
        FileStream fs1 = File.Create(@"myfile1.txt");
        BinaryWriter writer = new BinaryWriter(fs1);
        long number = 97;
        byte[] bytes = new byte[] { 1, 2, 3};
        string s = "This is file1 of Hui Lin.";
        writer.Write(number);
        writer.Write(bytes);
        writer.Write(s);
        writer.Close();

        FileStream fs2 = File.Create(@"myfile2.txt");
        writer = new BinaryWriter(fs2);
        number = 98;
        bytes = new byte[] { 1, 3, 5};
        s = "This is file2 of Hui Lin.";
        writer.Write(number);
        writer.Write(bytes);
        writer.Write(s);
        writer.Close();

        FileStream fs3 = File.Create(@"myfile3.txt");
        writer = new BinaryWriter(fs3);
        number = 99;
        bytes = new byte[] { 2, 4, 6 };
        s = "This is file3 of Hui Lin.";
        writer.Write(number);
        writer.Write(bytes);
        writer.Write(s);
        writer.Close();

        //merge all the files into 1 text
        string[] fileNames = new string[] { @"myfile1.txt", @"myfile2.txt", @"myfile3.txt" };
        string combinedFile = "sys_pro_class_activity.txt";
        string zipFile = "sys_pro_class_activity.zip";
        using (FileStream combinedFileStream = new FileStream(combinedFile, FileMode.Create))
        {
            foreach (string binaryFileName in fileNames)
            {
                using (FileStream binaryFileStream = new FileStream(binaryFileName, FileMode.Open, FileAccess.Read))
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead;
                    while ((bytesRead = binaryFileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        combinedFileStream.Write(buffer, 0, bytesRead);
                    }
                }
            }
        }

        // compress the merged file
        using (FileStream zipToOpen = new FileStream(zipFile, FileMode.Create))
        {
            using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
            {
                archive.CreateEntryFromFile(combinedFile, Path.GetFileName(combinedFile));
            }
        }

        // delete the temp merged file
        File.Delete(combinedFile);
    }
}