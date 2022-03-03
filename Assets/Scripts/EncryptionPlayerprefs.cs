using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using UnityEngine;

public class EncryptionPlayerPrefs
{
    private static readonly string AES_KEY = "tucEdCdt8x967xWdCR7zgfaKNQUy2HFs";
    private static readonly string AES_IV = "Jfj8FWQSDK7uZPtN";

    private readonly Encryptor encryptor = null;
    
    /// <summary>
    /// コンストラクタ
    /// </summary>
    public EncryptionPlayerPrefs()
    {
        var key = System.Text.Encoding.UTF8.GetBytes(AES_KEY);
        var value = System.Text.Encoding.UTF8.GetBytes(AES_IV);
        encryptor = new Encryptor(key, value);
    }

    /// <summary>
    /// intセット
    /// </summary>
    public void SetInt(string key, int value)
    {
        PlayerPrefs.SetString(encryptor.Encrypt(key), encryptor.Encrypt(value.ToString()));
        PlayerPrefs.Save();
    }
    
    /// <summary>
    /// int取得
    /// </summary>
    public int GetInt(string key)
    {
        string encryptedData = PlayerPrefs.GetString(encryptor.Encrypt(key));
        int.TryParse(encryptor.Decrypt(encryptedData), out int data);
        return data;
    }
    
    /// <summary>
    /// floatセット
    /// </summary>
    public void SetFloat(string key, float value)
    {
        PlayerPrefs.SetString(encryptor.Encrypt(key), encryptor.Encrypt(value.ToString("F6")));
        PlayerPrefs.Save();
    }
    
    /// <summary>
    /// float取得
    /// </summary>
    public float GetFloat(string key)
    {
        string encryptedData = PlayerPrefs.GetString(encryptor.Encrypt(key));
        float.TryParse(encryptor.Decrypt(encryptedData), out float data);
        return data;
    }
    
    /// <summary>
    /// stringセット
    /// </summary>
    public void SetString(string key, string value)
    {
        PlayerPrefs.SetString(encryptor.Encrypt(key), encryptor.Encrypt(value));
        PlayerPrefs.Save();
    }
    
    /// <summary>
    /// string取得
    /// </summary>
    public string GetString(string key)
    {
        string encryptedData = PlayerPrefs.GetString(encryptor.Encrypt(key));
        return encryptor.Decrypt(encryptedData);
    }
    
    /// <summary>
    /// クラスの値をセット
    /// </summary>
    public void SetObject<T>(string key, T value)
    {
        var json = JsonUtility.ToJson(value);
        PlayerPrefs.SetString(encryptor.Encrypt(key), encryptor.Encrypt(json));
        PlayerPrefs.Save();
    }
    
    /// <summary>
    /// クラスの値を取得
    /// </summary>
    public T GetObject<T>(string key)
    {
        string encryptedData = PlayerPrefs.GetString(encryptor.Encrypt(key));
        return JsonUtility.FromJson<T>(encryptor.Decrypt(encryptedData));
    }
}
