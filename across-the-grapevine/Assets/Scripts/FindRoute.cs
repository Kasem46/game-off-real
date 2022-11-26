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
    int[,] array2D = new int[,] { {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0} };
    public Tilemap tilemap;
    public Vector3 GrapePos;
    public Vector3Int RealPos;
    public Vector3 OldPos;
    public Vector3 Vec;
    public Vector3Int Pos;
    public bool moving;
    public bool constructs;
    public TileBase Line_Vertical;
    public TileBase Line_Horisontal;
    public TileBase Down_Right_Turn;
    public TileBase Down_Left_Turn;
    public TileBase Up_Right_Turn;
    public TileBase Up_Left_Turn;
    public TileBase Fork_Right;
    public TileBase Fork_Left;
    public TileBase Fork_Down;
    public TileBase Fork_Up;
    public TileBase Crossroads;
    public TileBase START;
    public TileBase END;
    public TileBase BIRD;
    void Start() {
        Vec.y = -1.5f;
        Vec.x = -1.5f;
        Vec.z = -1;
        moving = false;
        constructs = false;
    }
    // Update is called once per frame
    void Update()
    {
        RealPos.y = (int)GrapePos.y - 2;
        RealPos.x = (int)GrapePos.x - 2;
        TileBase grape = tilemap.GetTile(RealPos);
        if (grape == END) {
            GameStart.win = true;
        }
        if (GameStart.start == false && constructs == false) {
            StartCoroutine(Arraycreation());
        }
        if (GameStart.start == true && GameStart.win == false) {
            StartCoroutine(Move());
        } 
    }
    IEnumerator Arraycreation() {
        constructs = false;
        for (int i = 0; i < 4; i++){
            for (int j = 0; j < 4; j++){
                Pos.x = i - 2;
                Pos.y = j - 2;
                TileBase currentTile = tilemap.GetTile(Pos);
                if (currentTile == Line_Vertical) {
                    array2D[i, j] = 1;
                } else if (currentTile == Line_Horisontal) {
                    array2D[i, j] = 2;
                } else if (currentTile == Down_Right_Turn) {
                    array2D[i, j] = 3;
                } else if (currentTile == Down_Left_Turn) {
                    array2D[i, j] = 4;
                } else if (currentTile == Up_Right_Turn) {
                    array2D[i, j] = 5;
                } else if (currentTile == Up_Left_Turn) {
                    array2D[i, j] = 6;
                } else if (currentTile == Fork_Right) {
                    array2D[i, j] = 7;
                } else if (currentTile == Fork_Left) {
                    array2D[i, j] = 8;
                } else if (currentTile == Fork_Down) {
                    array2D[i, j] = 9;
                } else if (currentTile == Fork_Up) {
                    array2D[i, j] = 10;
                } else if (currentTile == Crossroads) {
                    array2D[i, j] = 11;
                } else if (currentTile == BIRD) {
                    array2D[i, j] = 12;
                } else if (currentTile == START){
                    array2D[i, j] = 5;
                } else if (currentTile == END){
                    array2D[i, j] = 4;
                } else {
                    array2D[i, j] = 0;
                }
            }
        }
        yield return new WaitForSeconds(0.01f);
        constructs = false;
    }
    IEnumerator Move(){
        //Change IEnumerator to detect number from array (swictch case), use number to detect tile type and therefore tell which direction grape can go in
        if (moving == false) {
            moving = true;
            switch (array2D[(int)GrapePos.x, (int)GrapePos.y]) {
                case 1: //Vertical Line
                    if (GrapePos.y + 1 < 4 && new List<int>{1, 3, 4, 7, 8, 9, 11, 12}.Contains(array2D[(int)GrapePos.x, (int)GrapePos.y + 1]) && GrapePos.y + 1 != OldPos.y) {
                        Vec.y += 1f;
                        OldPos = GrapePos;
                        GrapePos.y = GrapePos.y + 1f;
                    } else if (GrapePos.y - 1 > -1 && new List<int>{1, 5, 6, 7, 8, 10, 11, 12}.Contains(array2D[(int)GrapePos.x, (int)GrapePos.y - 1]) && GrapePos.y - 1 != OldPos.y) {
                        Vec.y -= 1f;
                        OldPos = GrapePos;
                        GrapePos.y = GrapePos.y - 1f;
                    } else {
                        OldPos = RealPos;
                    }
                    break;
                case 2: //Horisontal Line
                    if (GrapePos.x + 1 < 4 && new List<int>{2, 4, 6, 8, 9, 10, 11, 12}.Contains(array2D[(int)GrapePos.x + 1, (int)GrapePos.y]) && GrapePos.x + 1 != OldPos.x) {
                        Vec.x += 1f;
                        OldPos = GrapePos;
                        GrapePos.x = GrapePos.x + 1f;
                    } else if (GrapePos.x - 1 > -1 && new List<int>{2, 3, 5, 7, 9, 10, 11, 12}.Contains(array2D[(int)GrapePos.x - 1, (int)GrapePos.y]) && GrapePos.x - 1 != OldPos.x){ //add numbers to .Contains to add possilbe tiles grape can move to
                        Vec.x -= 1f;
                        OldPos = GrapePos;
                        GrapePos.x = GrapePos.x - 1f;
                    } else {
                        OldPos = RealPos;
                    }
                    break;
                case 3: //Down-Right turn
                    if (GrapePos.x + 1 < 4 && new List<int>{2, 4, 6, 8, 9, 10, 11, 12}.Contains(array2D[(int)GrapePos.x + 1, (int)GrapePos.y]) && GrapePos.x + 1 != OldPos.x){
                        Vec.x += 1f;
                        OldPos = GrapePos;
                        GrapePos.x = GrapePos.x + 1f;
                    } else if (GrapePos.y - 1 > -1 && new List<int>{1, 5, 6, 7, 8, 10, 11, 12}.Contains(array2D[(int)GrapePos.x, (int)GrapePos.y - 1]) && GrapePos.y - 1 != OldPos.y){
                        Vec.y -= 1f;
                        OldPos = GrapePos;
                        GrapePos.y = GrapePos.y - 1f;
                    } else {
                        OldPos = RealPos;
                    }
                    break;
                case 4: //Down-Left turn
                    if (GrapePos.x - 1 > -1 && new List<int>{2, 3, 5, 7, 9, 10, 11, 12}.Contains(array2D[(int)GrapePos.x - 1, (int)GrapePos.y]) && GrapePos.x - 1 != OldPos.x){
                        Vec.x -= 1f;
                        OldPos = GrapePos;
                        GrapePos.x = GrapePos.x - 1f;
                    } else if (GrapePos.y - 1 > -1 && new List<int>{1, 5, 6, 7, 8, 10, 11, 12}.Contains(array2D[(int)GrapePos.x, (int)GrapePos.y - 1]) && GrapePos.y - 1 != OldPos.y){
                        Vec.y -= 1f;
                        OldPos = GrapePos;
                        GrapePos.y = GrapePos.y - 1f;
                    } else {
                        OldPos = RealPos;
                    }
                    break;
                case 5: //Up-Right turn
                    if (GrapePos.x + 1 < 4 && new List<int>{2, 4, 6, 8, 9, 10, 11, 12}.Contains(array2D[(int)GrapePos.x + 1, (int)GrapePos.y]) && GrapePos.x + 1 != OldPos.x) {
                        Vec.x += 1f;
                        OldPos = GrapePos;
                        GrapePos.x = GrapePos.x + 1f;
                    } else if (GrapePos.y + 1 < 4 && new List<int>{1, 3, 4, 7, 8, 9, 11, 12}.Contains(array2D[(int)GrapePos.x, (int)GrapePos.y + 1]) && GrapePos.y + 1 != OldPos.y) {
                        Vec.y += 1f;
                        OldPos = GrapePos;
                        GrapePos.y = GrapePos.y + 1f;
                    } else {
                        OldPos = RealPos;
                    }
                    break;
                case 6: //Up-Left turn
                    if (GrapePos.y + 1 < 4 && new List<int>{1, 3, 4, 7, 8, 9, 11, 12}.Contains(array2D[(int)GrapePos.x, (int)GrapePos.y + 1]) && GrapePos.y + 1 != OldPos.y) {
                        Vec.y += 1f;
                        OldPos = GrapePos;
                        GrapePos.y = GrapePos.y + 1f;
                    } else if (GrapePos.x - 1 > -1 && new List<int>{2, 3, 5, 7, 9, 10, 11, 12}.Contains(array2D[(int)GrapePos.x - 1, (int)GrapePos.y]) && GrapePos.x - 1 != OldPos.x){
                        Vec.x -= 1f;
                        OldPos = GrapePos;
                        GrapePos.x = GrapePos.x - 1f;
                    } else {
                        OldPos = RealPos;
                    }
                    break;
                case 7: //Right Fork
                    if (GrapePos.x + 1 < 4 && new List<int>{2, 4, 6, 8, 9, 10, 11, 12}.Contains(array2D[(int)GrapePos.x + 1, (int)GrapePos.y]) && GrapePos.x + 1 != OldPos.x) {
                        Vec.x += 1f;
                        OldPos = GrapePos;
                        GrapePos.x = GrapePos.x + 1f;
                    } else if (GrapePos.y + 1 < 4 && new List<int>{1, 3, 4, 7, 8, 9, 11, 12}.Contains(array2D[(int)GrapePos.x, (int)GrapePos.y + 1]) && GrapePos.y + 1 != OldPos.y) {
                        Vec.y += 1f;
                        OldPos = GrapePos;
                        GrapePos.y = GrapePos.y + 1f;
                    } else if (GrapePos.y - 1 > -1 && new List<int>{1, 5, 6, 7, 8, 10, 11, 12}.Contains(array2D[(int)GrapePos.x, (int)GrapePos.y - 1]) && GrapePos.y - 1 != OldPos.y) {
                        Vec.y -= 1f;
                        OldPos = GrapePos;
                        GrapePos.y = GrapePos.y - 1f;
                    } else {
                        OldPos = RealPos;
                    }
                    break;
                case 8: //Left Fork
                    if (GrapePos.y + 1 < 4 && new List<int>{1, 3, 4, 7, 8, 9, 11, 12}.Contains(array2D[(int)GrapePos.x, (int)GrapePos.y + 1]) && GrapePos.y + 1 != OldPos.y) {
                        Vec.y += 1f;
                        OldPos = GrapePos;
                        GrapePos.y = GrapePos.y + 1f;
                    } else if (GrapePos.x - 1 > -1 && new List<int>{2, 3, 5, 7, 9, 10, 11, 12}.Contains(array2D[(int)GrapePos.x - 1, (int)GrapePos.y]) && GrapePos.x - 1 != OldPos.x){
                        Vec.x -= 1f;
                        OldPos = GrapePos;
                        GrapePos.x = GrapePos.x - 1f;
                    } else if (GrapePos.y - 1 > -1 && new List<int>{1, 5, 6, 7, 8, 10, 11, 12}.Contains(array2D[(int)GrapePos.x, (int)GrapePos.y - 1]) && GrapePos.y - 1 != OldPos.y) {
                        Vec.y -= 1f;
                        OldPos = GrapePos;
                        GrapePos.y = GrapePos.y - 1f;
                    } else {
                        OldPos = RealPos;
                    }
                    break;
                case 9: //Down Fork
                    if (GrapePos.x + 1 < 4 && new List<int>{2, 4, 6, 8, 9, 10, 11, 12}.Contains(array2D[(int)GrapePos.x + 1, (int)GrapePos.y]) && GrapePos.x + 1 != OldPos.x) {
                        Vec.x += 1f;
                        OldPos = GrapePos;
                        GrapePos.x = GrapePos.x + 1f;
                    } else if (GrapePos.x - 1 > -1 && new List<int>{2, 3, 5, 7, 9, 10, 11, 12}.Contains(array2D[(int)GrapePos.x - 1, (int)GrapePos.y]) && GrapePos.x - 1 != OldPos.x){
                        Vec.x -= 1f;
                        OldPos = GrapePos;
                        GrapePos.x = GrapePos.x - 1f;
                    } else if (GrapePos.y - 1 > -1 && new List<int>{1, 5, 6, 7, 8, 10, 11, 12}.Contains(array2D[(int)GrapePos.x, (int)GrapePos.y - 1]) && GrapePos.y - 1 != OldPos.y) {
                        Vec.y -= 1f;
                        OldPos = GrapePos;
                        GrapePos.y = GrapePos.y - 1f;
                    } else {
                        OldPos = RealPos;
                    }
                    break;
                case 10: //Up Fork
                    if (GrapePos.x + 1 < 4 && new List<int>{2, 4, 6, 8, 9, 10, 11, 12}.Contains(array2D[(int)GrapePos.x + 1, (int)GrapePos.y]) && GrapePos.x + 1 != OldPos.x) {
                        Vec.x += 1f;
                        OldPos = GrapePos;
                        GrapePos.x = GrapePos.x + 1f;
                    } else  if (GrapePos.x - 1 > -1 && new List<int>{2, 3, 5, 7, 9, 10, 11, 12}.Contains(array2D[(int)GrapePos.x - 1, (int)GrapePos.y]) && GrapePos.x - 1 != OldPos.x){
                        Vec.x -= 1f;
                        OldPos = GrapePos;
                        GrapePos.x = GrapePos.x - 1f;
                    } else if (GrapePos.y + 1 < 4 && new List<int>{1, 3, 4, 7, 8, 9, 11, 12}.Contains(array2D[(int)GrapePos.x, (int)GrapePos.y + 1]) && GrapePos.y + 1 != OldPos.y) {
                        Vec.y += 1f;
                        OldPos = GrapePos;
                        GrapePos.y = GrapePos.y + 1f;
                    } else {
                        OldPos = RealPos;
                    }
                    break;
                case 11: //Crossroads
                    if (GrapePos.x + 1 < 4 && new List<int>{2, 4, 6, 8, 9, 10, 11, 12}.Contains(array2D[(int)GrapePos.x + 1, (int)GrapePos.y]) && GrapePos.x + 1 != OldPos.x) {
                        Vec.x += 1f;
                        OldPos = GrapePos;
                        GrapePos.x = GrapePos.x + 1f;
                    
                    } else if (GrapePos.x - 1 > -1 && new List<int>{2, 3, 5, 7, 9, 10, 11, 12}.Contains(array2D[(int)GrapePos.x - 1, (int)GrapePos.y]) && GrapePos.x - 1 != OldPos.x){
                        Vec.x -= 1f;
                        OldPos = GrapePos;
                        GrapePos.x = GrapePos.x - 1f;
                    } else if (GrapePos.y + 1 < 4 && new List<int>{1, 3, 4, 7, 8, 9, 11, 12}.Contains(array2D[(int)GrapePos.x, (int)GrapePos.y + 1]) && GrapePos.y + 1 != OldPos.y) {
                        Vec.y += 1f;
                        OldPos = GrapePos;
                        GrapePos.y = GrapePos.y + 1f;
                    } else if (GrapePos.y - 1 > -1 && new List<int>{1, 5, 6, 7, 8, 10, 11, 12}.Contains(array2D[(int)GrapePos.x, (int)GrapePos.y - 1]) && GrapePos.y - 1 != OldPos.y) {
                        Vec.y -= 1f;
                        OldPos = GrapePos;
                        GrapePos.y = GrapePos.y - 1f;
                    } else {
                        OldPos = RealPos;
                    }
                    break;
                case 12: //Obsticles
                    GameStart.lose = true;
                    break;
            }
            transform.localPosition = Vec;
            yield return new WaitForSeconds(1.0f);
            moving = false;
        }
    }
}
