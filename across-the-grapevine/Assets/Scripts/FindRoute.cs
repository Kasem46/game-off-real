using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FindRoute : MonoBehaviour
{
    //Array is structured such that y stacked bottom row to top row
    //For example {0, 1, 2, 3}, {4, 5, 6, 7} would be:
    //  3   7
    //  2   6
    //  1   5
    //  0   4
    //change to int array with numbers repesenting tile type
    int[,] array2D = new int[,] { {5, 3, 0, 0}, {6, 4, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0} };
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
            switch (array2D[(int)GrapePos.x, (int)GrapePos.y]) {
                case 1: //Vertical Line
                    if (GrapePos.y + 1 < 4 && new List<int>{1, 3, 4}.Contains(array2D[(int)GrapePos.x, (int)GrapePos.y + 1]) && GrapePos.y + 1 != OldPos.y) {
                        Vec.y += 1f;
                        OldPos = GrapePos;
                        GrapePos.y = GrapePos.y + 1f;
                    } else if (GrapePos.y - 1 > -1 && new List<int>{1, 5, 6}.Contains(array2D[(int)GrapePos.x, (int)GrapePos.y - 1]) && GrapePos.y - 1 != OldPos.y) {
                        Vec.y -= 1f;
                        OldPos = GrapePos;
                        GrapePos.y = GrapePos.y - 1f;
                    }
                    break;
                case 2: //Horisontal Line
                    if (GrapePos.x + 1 < 4 && new List<int>{2, 4, 6}.Contains(array2D[(int)GrapePos.x + 1, (int)GrapePos.y]) && GrapePos.x + 1 != OldPos.x) {
                        Vec.x += 1f;
                        OldPos = GrapePos;
                        GrapePos.x = GrapePos.x + 1f;
                    } else if (GrapePos.x - 1 > -1 && new List<int>{2, 3, 5}.Contains(array2D[(int)GrapePos.x - 1, (int)GrapePos.y]) && GrapePos.x - 1 != OldPos.x){ //add numbers to .Contains to add possilbe tiles grape can move to
                        Vec.x -= 1f;
                        OldPos = GrapePos;
                        GrapePos.x = GrapePos.x - 1f;
                    }
                    break;
                case 3: //Down-Right turn
                    if (GrapePos.x + 1 < 4 && new List<int>{2, 4, 6}.Contains(array2D[(int)GrapePos.x + 1, (int)GrapePos.y]) && GrapePos.x + 1 != OldPos.x){
                        Vec.x += 1f;
                        OldPos = GrapePos;
                        GrapePos.x = GrapePos.x + 1f;
                    } else if (GrapePos.y - 1 > -1 && new List<int>{1, 5, 6}.Contains(array2D[(int)GrapePos.x, (int)GrapePos.y - 1]) && GrapePos.y - 1 != OldPos.y){
                        Vec.y -= 1f;
                        OldPos = GrapePos;
                        GrapePos.y = GrapePos.y - 1f;
                    }
                    break;
                case 4: //Down-Left turn
                    if (GrapePos.x - 1 > -1 && new List<int>{2, 3, 5}.Contains(array2D[(int)GrapePos.x - 1, (int)GrapePos.y]) && GrapePos.x - 1 != OldPos.x){
                        Vec.x -= 1f;
                        OldPos = GrapePos;
                        GrapePos.x = GrapePos.x - 1f;
                    } else if (GrapePos.y - 1 > -1 && new List<int>{1, 5, 6}.Contains(array2D[(int)GrapePos.x, (int)GrapePos.y - 1]) && GrapePos.y - 1 != OldPos.y){
                        Vec.y -= 1f;
                        OldPos = GrapePos;
                        GrapePos.y = GrapePos.y - 1f;
                    }
                    break;
                case 5: //Up-Right turn
                    if (GrapePos.x + 1 < 4 && new List<int>{2, 4, 6}.Contains(array2D[(int)GrapePos.x + 1, (int)GrapePos.y]) && GrapePos.x + 1 != OldPos.x) {
                        Vec.x += 1f;
                        OldPos = GrapePos;
                        GrapePos.x = GrapePos.x + 1f;
                    } else if (GrapePos.y + 1 < 4 && new List<int>{1, 3, 4}.Contains(array2D[(int)GrapePos.x, (int)GrapePos.y + 1]) && GrapePos.y + 1 != OldPos.y) {
                        Vec.y += 1f;
                        OldPos = GrapePos;
                        GrapePos.y = GrapePos.y + 1f;
                    }
                    break;
                case 6: //Up-Left turn
                    if (GrapePos.x - 1 > -1 && new List<int>{2, 3, 5}.Contains(array2D[(int)GrapePos.x - 1, (int)GrapePos.y]) && GrapePos.x - 1 != OldPos.x){
                        Vec.x -= 1f;
                        OldPos = GrapePos;
                        GrapePos.x = GrapePos.x - 1f;
                    } else if (GrapePos.y + 1 < 4 && new List<int>{1, 3, 4}.Contains(array2D[(int)GrapePos.x, (int)GrapePos.y + 1]) && GrapePos.y + 1 != OldPos.y) {
                        Vec.y += 1f;
                        OldPos = GrapePos;
                        GrapePos.y = GrapePos.y + 1f;
                    }
                    break;
            }
            transform.localPosition = Vec;
            yield return new WaitForSeconds(1.0f);
            moving = false;
        }
    }
}
