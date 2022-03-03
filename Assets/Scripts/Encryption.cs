using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

/// <summary>
/// 暗号化
/// </summary>
public class Encryptor
{
    private readonly byte[] key = null;
    private readonly byte[] iv = null;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public Encryptor(byte[] key, byte[] iv)
    {
        this.key = key;
        this.iv = iv;
    }
    
    /// <summary>
    /// 暗号化
    /// </summary>
    public string Encrypt(string rawData, bool isCompress = false)
    {
        string encryptData = null;
        try
        {
            byte[] byteData = null;
            if (isCompress)
            {
                byteData = Compression.Compress(rawData);
            }
            else
            {
                byteData = Encoding.UTF8.GetBytes(rawData);
            }
            var encryptBytes = Encrypt(byteData);
            encryptData = Convert.ToBase64String(encryptBytes);
        }
        catch (Exception e)
        {
            Debug.LogError($"暗号化失敗、Exception：{e}");
            return null;
        }

        return encryptData;
    }
    
    /// <summary>
    /// 複合化
    /// </summary>
    /// <param name="json"></param>
    /// <param name="isCompress"></param>
    /// <returns></returns>
    public string Decrypt(string data, bool isCompress = false)
    {
        string decryptData = null;
        try
        {
            byte[] byteData = Convert.FromBase64String(data);
            var decryptBytes = Decrypt(byteData);
            if (isCompress)
            {
                decryptBytes = Compression.Decompress(decryptBytes);
            }
            decryptData = Encoding.UTF8.GetString(decryptBytes);
        }
        catch (Exception e)
        {
            Console.WriteLine($"複合化失敗、Exception：{e}");
        }

        return decryptData;
    }

    /// <summary>
    /// aes暗号化
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    private byte[] Encrypt(byte[] data)
    {
        byte[] encryptData = null;
        var aes = Aes.Create();
        using (ICryptoTransform encryptor = aes.CreateEncryptor(key, iv))
        {
            encryptData = encryptor.TransformFinalBlock(data, 0, data.Length);
        }

        return encryptData;
    }
    
    /// <summary>
    /// aes複合化
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    private byte[] Decrypt(byte[] data)
    {
        byte[] decryptData = null;
        var aes = Aes.Create();
        using (ICryptoTransform decryptor = aes.CreateDecryptor(key, iv))
        {
            decryptData = decryptor.TransformFinalBlock(data, 0, data.Length);
        }

        return decryptData;
    }
}
