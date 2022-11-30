using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAppaer : MonoBehaviour {
    public Image next;
    public Text next2;
    // Start is called before the first frame update
    void Start() {
        next.enabled = false;
        next2.enabled = false;
    }

    // Update is called once per frame
    void Update() {
        if (GameStart.win == true) {
            next.enabled = true;
            next2.enabled = true;
            Debug.Log(GameStart.win);
        } else {
            next.enabled = false;
            next2.enabled = false;
            Debug.Log(GameStart.win);
        }
    }
}
