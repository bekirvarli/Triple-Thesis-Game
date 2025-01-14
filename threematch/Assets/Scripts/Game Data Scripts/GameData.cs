using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[Serializable]
public class SaveData
{
    public bool[] isActive = new bool[27];
    public int[] highScores;
    public int[] stars;

}


public class GameData : MonoBehaviour
{
    public static GameData Instance { get; private set; }
    public SaveData saveData;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Load();
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.persistentDataPath + "/player.json", json);
        Debug.Log("Saved");
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/player.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            saveData = JsonUtility.FromJson<SaveData>(json);
            Debug.Log("Loaded");
        }
    }

    private void OnDisable()
    {
        Save();
    }

    private void OnApplicationQuit()
    {
        Save();
    }


}