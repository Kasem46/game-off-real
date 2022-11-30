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
    private static int level = 0;
    public static bool win = false;
    public static bool win1 = false;
    public static bool win2 = false;
    public static bool win3 = false;
    public static bool win4 = false;
    public static bool win5 = false;
    public static bool win6 = false;

    public void onClick()
    {
        start = true;
    }
    void Update() { 
        if (lose == true) {
            
        }
        if (win == true) {
            switch (level) {
                case 1:
                    win1 = true;
                    break;
                case 2:
                    win2 = true;
                    break;
                case 3:
                    win3 = true;
                    break;
                case 4:
                    win4 = true;
                    break;
                case 5:
                    win5 = true;
                    break;
                case 6:
                    win6 = true;
                    break;
            }
        }
        if (Input.GetKey(KeyCode.Escape) && level != 0) {
            level = 0;
            win = false;
            start = false;
            moveToLevelSelect();
        }
    }
    public void exitGame() {
        Application.Quit();
    }
    public void reset() {
        Scene currentScene = SceneManager.GetActiveScene();
        start = false;
        SceneManager.LoadScene(currentScene.buildIndex);
    }
    public void nextLevel() {
        if (win == true && start == true) {
            start = false;
            Scene currentScene = SceneManager.GetActiveScene();
            win = false;
            SceneManager.LoadScene(currentScene.buildIndex + 1);
        }
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
        level = 1;
    }
    public void moveToLevel2() {
        if (win1 == true) {
            SceneManager.LoadScene("Level2");
            level = 2;
        }
    }
    public void moveToLevel3() {
        if (win2 == true) {
            SceneManager.LoadScene("Level3");
            level = 3;
        }
    }
    public void moveToLevel4() {
        if (win3 == true) {
            SceneManager.LoadScene("Level4");
            level = 4;
        }
    }
    public void moveToLevel5() {
        if (win4 == true) {
            SceneManager.LoadScene("Level5");
            level = 5;
        }
    }
    public void moveToLevel6() {
        if (win5 == true) {
            SceneManager.LoadScene("Level6");
            level = 6;
        }
    }
}
