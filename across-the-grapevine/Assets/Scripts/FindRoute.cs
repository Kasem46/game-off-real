using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FindRoute : MonoBehaviour
{
    //array is y then x
    bool[,] array2D = new bool[,] { { true, true, true, true }, { false, false, false, true}, { true, false, false, true}, { false, false, false, true} };
    public ITilemap tilemap;
    public Vector3 GrapePos;
    public Vector3 OldPos;
    public Vector3 Vec;
    public bool moving;


    void Start() {
        Vec.y = -1.5f;
        Vec.x = -1.5f;
        moving = false;
    }
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(MoveVertical());
    }
    IEnumerator MoveVertical()
    {
        if (moving == false) {
            moving = true;
            if (GrapePos.y + 1 < 4 && array2D[(int)GrapePos.x, (int)GrapePos.y + 1] == true && GrapePos.y + 1 != OldPos.y)
            {
                Vec.y += 1f;
                OldPos = GrapePos;
                GrapePos.y = GrapePos.y + 1f;
            }
            else if (GrapePos.y - 1 > -1 && array2D[(int)GrapePos.x, (int)GrapePos.y - 1] == true && GrapePos.y - 1 != OldPos.y)
            {
                Vec.y -= 1f;
                OldPos = GrapePos;
                GrapePos.y = GrapePos.y - 1f;
            }
            yield return new WaitForSeconds(2.0f);
            transform.localPosition = Vec;
            moving = false;
        }
    }

}