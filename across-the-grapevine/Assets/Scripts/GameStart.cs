using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// This Script controls all ui now
/// </summary>
public class GameStart : MonoBehaviour
{
    public static bool start = false;
    public static bool lose = false;
    public static bool win = false;

    public void onClick()
    {
        start = true;
    }
    void Update() { 
        if (lose == true) {
            Debug.Log("YOU LOSE\nL+NOGRAPE");
        }
        if (win == true) {
            Debug.Log("YOU WIN\nL+GRAPE");
        }
    }
    public void exitGame() {
        Application.Quit();
    }
    public void moveToLevelSelect() {
        SceneManager.LoadScene("LevelSelect");
    }
    public void moveToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
    public void moveToOptions() {
        SceneManager.LoadScene("Options");
    }
    public void moveToLevel1() {
        SceneManager.LoadScene("Level1");
    }
    public void moveToLevel2() {
        SceneManager.LoadScene("Level2");
    }
    public void moveToLevel3() {
        SceneManager.LoadScene("Level3");
    }
    public void moveToLevel4() {
        SceneManager.LoadScene("Level4");
    }
    public void moveToLevel5() {
        SceneManager.LoadScene("Level5");
    }
    public void moveToLevel6() {
        SceneManager.LoadScene("Level6");
    }
}
