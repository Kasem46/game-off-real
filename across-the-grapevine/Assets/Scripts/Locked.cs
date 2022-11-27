using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Locked : MonoBehaviour
{
    public RawImage lock1;
    public RawImage lock2;
    public RawImage lock3;
    public RawImage lock4;
    public RawImage lock5;
    public RawImage check1;
    public RawImage check2;
    public RawImage check3;
    public RawImage check4;
    public RawImage check5;
    public RawImage check6;

    void Start()
    {
        lock1.enabled = true;
        lock2.enabled = true;
        lock3.enabled = true;
        lock4.enabled = true;
        lock5.enabled = true;
        check1.enabled = false;
        check2.enabled = false;
        check3.enabled = false;
        check4.enabled = false;
        check5.enabled = false;
        check6.enabled = false;
    }

    void Update()
    {
        if (GameStart.win1 == true) {
            lock1.enabled = false;
            check1.enabled = true;
        }
        if (GameStart.win2 == true) {
            lock2.enabled = false;
            check2.enabled = true;
        }
        if (GameStart.win3 == true) {
            lock3.enabled = false;
            check3.enabled = true;
        }
        if (GameStart.win4 == true) {
            lock4.enabled = false;
            check4.enabled = true;
        }
        if (GameStart.win5 == true) {
            lock5.enabled = false;
            check5.enabled = true;
        }
        if (GameStart.win6 == true) {
            check6.enabled = true;
        }
        //if trophie
    }
}
