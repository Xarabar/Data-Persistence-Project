using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataPersistenceManager : MonoBehaviour
{
    public static DataPersistenceManager instance;

    private string playerName;
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetPlayerName(string playerName)
    {
        this.playerName = playerName;
    }

    public string GetPlayerName()
    {
        return playerName;
    }

    [System.Serializable]
    public class SaveData
    {
        public string playerName;
        public int highscore;
    }

    public void SaveHighscore(int score)
    {   
        SaveData data = LoadHighscore();
        if(data != null)
        {
            if(score > data.highscore)
            {
                data.playerName = playerName;
                data.highscore = score;

                SaveToFile(data);
            }
        }
        else
        {
            data = new SaveData();
            data.playerName = playerName;
            data.highscore = score;

            SaveToFile(data);
        }
    }

    void SaveToFile(SaveData data)
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/highscore.json", json);
    }

    public SaveData LoadHighscore()
    {
        string path = Application.persistentDataPath + "/highscore.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            return data;
        }
        return null;
    }
}