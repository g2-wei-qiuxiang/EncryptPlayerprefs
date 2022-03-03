using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using UnityEngine;

/// <summary>
/// 圧縮
/// </summary>
public static class Compression
{
    /// <summary>
    /// 圧縮
    /// </summary>
    public static byte[] Compress(string data)
    {
        byte[] compressData = null;
        using (MemoryStream memoryStream = new MemoryStream())
        {
            using (GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Compress))
            {
                using (StreamWriter writer = new StreamWriter(gZipStream))
                {
                    writer.Write(data);
                }
            }
            compressData = memoryStream.ToArray();
        }

        return compressData;
    }
    
    /// <summary>
    /// 解凍
    /// </summary>
    public static byte[] Decompress(byte[] compressedData)
    {
        byte[] data = null;
        using (MemoryStream memoryStream = new MemoryStream(compressedData))
        {
            using (GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Decompress, false))
            {
                using (StreamReader reader = new StreamReader(gZipStream))
                {
                    string dataString = reader.ReadToEnd();
                    data = Encoding.UTF8.GetBytes(dataString);
                }
            }
        }

        return data;
    }
}
