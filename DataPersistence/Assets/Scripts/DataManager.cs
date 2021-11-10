using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    // Start is called before the first frame update
    //Static reference
    public static DataManager dataManager;

    //Data to persist
    public string playerName;
    public int bestScore;
    public string topPlayer;

    // Start is called before the first frame update
    void Awake()
    {
        LoadRecord();
        if (dataManager != null)
        {
            Destroy(gameObject);
        }
        else
        {
            dataManager = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    [Serializable]
    class SaveData
    {
        public string playerName;
        public int bestScore;
    }

    public void SaveRecord(int score)
    {

        SaveData saveData = new SaveData();

        int temp = dataManager.bestScore;
        string tempName = dataManager.topPlayer;

        if (score > temp)
        {

            dataManager.bestScore = score;
            saveData.playerName = playerName;

        }
        else
        {

            dataManager.bestScore = temp;
            saveData.playerName = tempName;

        }




        saveData.bestScore = bestScore;

        string json = JsonUtility.ToJson(saveData);

        File.WriteAllText(Application.persistentDataPath + "/saveData.json", json);
    }

    public void LoadRecord()
    {
        string path = Application.persistentDataPath + "/saveData.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            bestScore = data.bestScore;
            topPlayer = data.playerName;
        }
    }
}
