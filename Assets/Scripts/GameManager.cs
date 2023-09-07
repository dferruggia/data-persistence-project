using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Persistent class to maintain data between scenes.
 */

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private string CurrentPlayerName;

    [System.Serializable]
    class SaveData
    {
        public Color TeamColor;
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
    }

    public void SetCurrentPlayerName(string playerName)
    {
        CurrentPlayerName = playerName;
    }

    public void SaveScores()
    {

    }
}
