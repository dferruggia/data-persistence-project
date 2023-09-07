using System.Collections;
using System.Collections.Generic;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

/* 
 * Start menu handler for the breakout game
 */
public class MenuUIHandler : MonoBehaviour
{
    public TextMeshPro NameInputField;
    public GameObject StartButton;

    public void ChangeName()
    {
        Button button = StartButton.GetComponent<Button>();
        if (NameInputField.text == null || NameInputField.text == "") {
            button.SetEnabled(false);
        } else
        {
            GameManager.Instance.SetCurrentPlayerName(NameInputField.text);
            button.SetEnabled(true);
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
