using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public InputField nameInput;
    public Text bestScoreText;
    private string playerName;


    void Start()
    {
        DataManager.dataManager.LoadRecord();
        string bestPlayer = DataManager.dataManager.topPlayer;
        int bestScore = DataManager.dataManager.bestScore;

        if (bestScore != 0)
        {
            bestScoreText.text = "Best Score -> " + bestPlayer + "'s " + bestScore;
        }
        else
        {
            bestScoreText.text = "";
        }
    }

    public void SaveName()
    {
        playerName = nameInput.text;
    }

    public void StartGame()
    {
        DataManager.dataManager.playerName = playerName;
        SceneManager.LoadScene("main");
    }
    public void Quit()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }
}
