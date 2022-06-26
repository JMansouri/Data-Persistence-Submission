using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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

    [System.Serializable]
    class DataToSave
    {
        public string PlayerName;
    }

    public void SaveData()
    {
        DataToSave data = new DataToSave();
        data.PlayerName = PlayerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json",json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            DataToSave data = JsonUtility.FromJson<DataToSave>(json);

            PlayerName = data.PlayerName;
        }
    }
}
