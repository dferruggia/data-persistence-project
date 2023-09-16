using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

/* 
 * Start menu handler for the breakout game
 */
public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField NameInputField;
    public GameObject StartButton;

    public void ChangeName()
    {
        UnityEngine.UI.Button button = StartButton.GetComponent<UnityEngine.UI.Button>();
        if (NameInputField.text == null || NameInputField.text == "") {
            button.interactable = false;
        } else
        {
            GameManager.Instance.SetCurrentPlayerName(NameInputField.text);
            button.interactable = true;
        }
    }

    public void Exit()
    {
        GameManager.Instance.SaveScores();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
# else
        Application.Quit();
#endif
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
}
