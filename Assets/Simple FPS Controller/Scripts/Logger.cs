using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logger : MonoBehaviour
{
    // Singleton instance
    private static Logger _instance;
    public static Logger Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Logger>();
                if (_instance == null)
                {
                    Debug.LogError("No Logger instance found in the scene.");
                }
            }
            return _instance;
        }
    }

    // Other members and methods of the Logger class...

    public void LogInfo(string message)
    {
        Debug.Log(message);
    }
}
