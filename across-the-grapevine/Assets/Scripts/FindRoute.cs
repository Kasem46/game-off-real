using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FindRoute : MonoBehaviour
{
    //Array is structured such that x values are inside brackets while y values are the brackets themselves
    //change to int array with numbers repesenting tile type
    int[,] array2D = new int[,] { { 1, 0, 1, 1 }, {0, 1, 1, 1}, { 1, 1, 1, 1}, { 1, 1, 1, 1} };
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
        StartCoroutine(Move());
    }
    IEnumerator Move()
    {
        //Change IEnumerator to detect number from array (swictch case), use number to detect tile type and therefore tell which direction grape can go in
        if (moving == false) {
            moving = true;
            switch (array2D[0, 0]) {
                case 1:
                    if (GrapePos.y + 1 < 4 && array2D[(int)GrapePos.x, (int)GrapePos.y + 1] > 0 && GrapePos.y + 1 != OldPos.y) {
                        Vec.y += 1f;
                        OldPos = GrapePos;
                        GrapePos.y = GrapePos.y + 1f;
                    } else if (GrapePos.y - 1 > -1 && array2D[(int)GrapePos.x, (int)GrapePos.y - 1] >= 0 && GrapePos.y - 1 != OldPos.y) {
                        Vec.y -= 1f;
                        OldPos = GrapePos;
                        GrapePos.y = GrapePos.y - 1f;
                    } else {
                        Debug.Log("Cannot Move");
                    }
                    transform.localPosition = Vec;
                    yield return new WaitForSeconds(1.0f);
                    moving = false;
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }      
        }
    }
}
