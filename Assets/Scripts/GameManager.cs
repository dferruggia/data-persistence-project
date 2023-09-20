using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Policy;
using UnityEngine;

/**
 * Persistent class to maintain data between scenes.
 */

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private string CurrentPlayerName;
    private int CurrentPlayerScore;
    private string HighPlayerName;
    private int HighPlayerScore;

    [System.Serializable]
    class GameData
    {
        public string CurrentPlayerName;
        public int CurrentPlayerScore;
        public string HighPlayerName;
        public int HighPlayerScore;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        CurrentPlayerName = "";
        CurrentPlayerScore = 0;
        HighPlayerName = "";
        HighPlayerScore = 0;
        LoadData();
    }

    public string GetBestScore()
    {
        if (HighPlayerName == "")
        {
            return "";
        } else
        {
            return "Best Score : " + HighPlayerName + " : " + HighPlayerScore;
        }
    }

    public string GetCurrentPlayerName() { return CurrentPlayerName; }
    public int GetCurrentPlayerScore() { return CurrentPlayerScore; }
    public string GetHighPlayerName() { return HighPlayerName; }
    public int GetHighPlayerScore() { return HighPlayerScore; }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            GameData data = JsonUtility.FromJson<GameData>(json);

            CurrentPlayerName = data.CurrentPlayerName;
            CurrentPlayerScore = data.CurrentPlayerScore;
            HighPlayerName = data.HighPlayerName;
            HighPlayerScore = data.HighPlayerScore;
        }
    }

    public void SaveData()
    {
        GameData data = new GameData();
        data.CurrentPlayerName = CurrentPlayerName;
        data.CurrentPlayerScore = CurrentPlayerScore;
        data.HighPlayerName = HighPlayerName;
        data.HighPlayerScore = HighPlayerScore;

        string json = JsonUtility.ToJson(data);

        UnityEngine.Debug.Log("Save file name: " + Application.persistentDataPath + "/savefile.json");
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void SaveScore(int score)
    {
        if (score > HighPlayerScore)
        {
            HighPlayerScore = score;
            HighPlayerName = CurrentPlayerName;
            SaveData();
        }

    }

    public void SetCurrentPlayerName(string playerName)
    {
        CurrentPlayerName = playerName;
    }

    public void SetCurrentPlayerScore(int playerScore)
    {
        CurrentPlayerScore = playerScore;
    }
}
