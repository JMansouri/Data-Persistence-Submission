using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string PlayerName { get; set; }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy (gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad (gameObject);
        }
    }

    public void SaveData() 
    {

    }
    
    public void LoadData() 
    {

    }
    
}
