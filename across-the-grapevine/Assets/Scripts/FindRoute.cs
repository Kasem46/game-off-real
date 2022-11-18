using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FindRoute : MonoBehaviour
{
    //Array is structured such that y stacked bottom row to top row
    //change to int array with numbers repesenting tile type
    int[,] array2D = new int[,] { { 2, 1, 1, 1 }, {1, 1, 1, 1}, { 2, 1, 1, 1}, { 2, 1, 1, 1} };
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
                case 1: //Vertical Line
                    if (GrapePos.y + 1 < 4 && new List<int>{2}.Contains(array2D[(int)GrapePos.x, (int)GrapePos.y + 1]) && GrapePos.y + 1 != OldPos.y) {
                        Vec.y += 1f;
                        OldPos = GrapePos;
                        GrapePos.y = GrapePos.y + 1f;
                    } else if (GrapePos.y - 1 > -1 && new List<int>{2}.Contains(array2D[(int)GrapePos.x, (int)GrapePos.y - 1]) && GrapePos.y - 1 != OldPos.y) {
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
                case 2: //Horisontal Line
                    if (GrapePos.x + 1 < 4 && new List<int>{2}.Contains(array2D[(int)GrapePos.x + 1, (int)GrapePos.y]) && GrapePos.x + 1 != OldPos.x) {
                        Vec.x += 1f;
                        OldPos = GrapePos;
                        GrapePos.x = GrapePos.x + 1f;
                    }else if (GrapePos.x - 1 > -1 && new List<int>{2}.Contains(array2D[(int)GrapePos.x - 1, (int)GrapePos.y]) && GrapePos.x - 1 != OldPos.x){ //add numbers to .Contains to add possilbe tiles grape can move to
                        Vec.x -= 1f;
                        OldPos = GrapePos;
                        GrapePos.x = GrapePos.x - 1f;
                    } else {
                        Debug.Log("Cannot Move");
                    }
                    transform.localPosition = Vec;
                    yield return new WaitForSeconds(1.0f);
                    moving = false;
                    break;
                case 3:
                    break;
            }      
        }
    }
}
