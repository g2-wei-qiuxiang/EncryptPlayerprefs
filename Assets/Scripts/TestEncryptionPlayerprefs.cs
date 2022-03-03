using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestEncryptionPlayerprefs : MonoBehaviour
{
    [SerializeField] 
    private Text rawValue = null;
    
    [SerializeField] 
    private Text resultValue = null;

    [SerializeField]
    private Button encryptButton = null;
    
    [SerializeField]
    private Button decryptButton = null;
    
    [Serializable]
    public class SaveTestClass
    {
        public int param1 = default;
        public float param2 = default;
        public string param3 = default;
    }

    private readonly string keyInt = "int_value_key";
    private readonly int intValue = 101;
    private readonly string keyFloat = "float_value_key";
    private readonly float floatValue = 6.14f;
    private readonly string keyString = "string_value_key";
    private readonly string stringValue = "文字テスト、12345";
    private readonly string keySaveClass = "save_class_key";
    private readonly SaveTestClass classValue = new SaveTestClass()
    {
        param1 = 300, param2 = 3.14f, param3 = "クラス変数値"
    };
    
    private EncryptionPlayerPrefs encryptor = null;

    private void Start()
    {
        string text = "PlayerPrefsに保存したいkey、value";
        text += $"\nint型：key={keyInt}、value={intValue}";
        text += $"\nfloat型：key={keyFloat}、value={floatValue}";
        text += $"\nstring型：key={keyString}、value={stringValue}";
        text += $"\nクラス型：key={keySaveClass}、param1={classValue.param1}、param2={classValue.param2}、param3={classValue.param3}";
        rawValue.text = text;

        encryptor = new EncryptionPlayerPrefs();
        encryptButton.onClick.AddListener(Encrypt);
        decryptButton.onClick.AddListener(Decrypt);
    }
    
    private void Encrypt()
    {
        encryptor.SetInt(keyInt, intValue);
        encryptor.SetFloat(keyFloat, floatValue);
        encryptor.SetString(keyString, stringValue);
        encryptor.SetObject<SaveTestClass>(keySaveClass, classValue);
    }

    private void Decrypt()
    {
        string text = "複合化後の値";
        text += $"\nint型：key={keyInt}、value={encryptor.GetInt(keyInt)}";
        text += $"\nfloat型：key={keyFloat}、value={encryptor.GetFloat(keyFloat)}";
        text += $"\nstring型：key={keyString}、value={encryptor.GetString(keyString)}";
        SaveTestClass saveTestClass = encryptor.GetObject<SaveTestClass>(keySaveClass);
        text += $"\nstring型：key={keyString}、param1={saveTestClass.param1}、param3={saveTestClass.param2}、param3={saveTestClass.param3}";
        resultValue.text = text;
    }
}
