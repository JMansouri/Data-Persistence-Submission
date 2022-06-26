using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif


// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class UIManager : MonoBehaviour
{
    public InputField PlayerNameInput;

    void PlayerNameEntered()
    {
        DataManager.Instance.PlayerName = PlayerNameInput.text;
        //Debug.Log(" Name :  "+DataManager.Instance.PlayerName);
    }

    private void Start()
    {
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        PlayerNameInput.onEndEdit.AddListener(delegate {PlayerNameEntered(); });
    }
    
    public void StartNew()
    {
        //DataManager.Instance.PlayerName = PlayerNameInput.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        DataManager.Instance.SaveData();


#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif

    }
}
