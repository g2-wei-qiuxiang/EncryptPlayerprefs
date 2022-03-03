using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 通信シミュレーター
/// </summary>
public class ApiRequestResponseSimulator : MonoBehaviour
{
    [SerializeField] private Button sendButton = null;
    [SerializeField] private Button receiveButton = null;

    private static readonly string dataPath = "";    // TODO
    
    /// <summary>
    ///  Start
    /// </summary>
    void Start()
    {
        sendButton.onClick.AddListener(Request);
        receiveButton.onClick.AddListener(Response);
    }

    /// <summary>
    /// リクエスト
    /// </summary>
    private void Request()
    {
        
    }
    
    /// <summary>
    /// レスポンス
    /// </summary>
    public void Response()
    {
        
    }
}
