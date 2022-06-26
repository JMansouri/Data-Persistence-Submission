using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string PlayerName { get; set; }

    public string PlayerWithHighScore { get; set; }

    public int HighScore { get; set; } = 0;

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
            LoadData();
        }
    }

    [System.Serializable]
    class DataToSave
    {
        public string HighScorePlayer;
        public int HighScore;
    }

    public void SaveData()
    {
        DataToSave data = new DataToSave();
        data.HighScorePlayer = PlayerWithHighScore;
        data.HighScore = HighScore;

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

            PlayerWithHighScore = data.HighScorePlayer;
            HighScore = data.HighScore;
        }
    }
}
