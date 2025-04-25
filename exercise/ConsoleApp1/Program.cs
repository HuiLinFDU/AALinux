using System;
using System.IO;
using System.IO.Compression;
public sealed class Program
{
    public static void Main()
    {
        FileStream sfile = File.OpenRead(@"comp.txt");
        FileStream dfile = File.Create(@"comp.txt.gz");
        GZipStream cStream = new GZipStream(dfile, CompressionMode.Compress);
        int theByte = sfile.ReadByte();
        while (theByte != -1)
        {
            cStream.WriteByte((byte)theByte);
            theByte = sfile.ReadByte();
        }
    }
}
