using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
