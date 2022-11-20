using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Tilemaps;
public class Placetile : MonoBehaviour
{
    public Tile VerticalLine; public Tile HorisontalLine; public Tile LeftDownTurn; public Tile RightDownTurn; public Tile LeftUpTurn; public Tile RightUpTurn; public Tile ForkUp; public Tile ForkDown; public Tile ForkLeft; public Tile ForkRight; public Tile Crossroads; public Tile SelectedTile; //Declare Tiles in tilemap (good idea)
    public Tilemap tilemap;
    public Vector3 screenPosition;
    public Vector3 worldPosition;

    public TileCounter tileCounter;

    void Paint(Vector3Int Position, Tile tile) { //Function to set tiles
        tilemap.SetTile(Position, tile);
        SelectedTile = null;
    }
    void Update() { //Function to kill whoever reads this
        screenPosition = Input.mousePosition;
        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        int y = (int) Math.Floor(worldPosition.y);
        int x = (int)Math.Floor(worldPosition.x);
        Vector3Int mousePos = (new Vector3Int (x, y, 0));
        //good luck, I don't know what this is
        if (SelectedTile != null && GameStart.start == false) {
            if (Input.GetMouseButtonDown(0) && ((mousePos.y <= 1 && mousePos.x <= 0 && mousePos.x >= -2 && mousePos.y >= -1) || (mousePos.y <= 0 && mousePos.x <= 1 && mousePos.x >= -1 && mousePos.y >= -2))) {
                Paint(mousePos, SelectedTile);
            }
        }
        if (SelectedTile == null && GameStart.start == false) {
            if (mousePos.y == 1 && mousePos.x == -5 && Input.GetMouseButtonDown(0) && tileCounter.numbers[1] > 0) {
                SelectedTile = ForkRight;
                tileCounter.RemoveTile(1);
            } else if (mousePos.y == -1 && mousePos.x == -5 && Input.GetMouseButtonDown(0) && tileCounter.numbers[2] > 0) {
                SelectedTile = ForkLeft;
                tileCounter.RemoveTile(2);
            } else if (mousePos.y == -3 && mousePos.x == -5 && Input.GetMouseButtonDown(0) && tileCounter.numbers[3] > 0) {
                SelectedTile = ForkUp;
                tileCounter.RemoveTile(3);
            } else if (mousePos.y == 3 && mousePos.x == -5 && Input.GetMouseButtonDown(0) && tileCounter.numbers[0] > 0) {
                SelectedTile = ForkDown;
                tileCounter.RemoveTile(0);
            } else if (mousePos.y == 1 && mousePos.x == -7 && Input.GetMouseButtonDown(0) && tileCounter.numbers[5] > 0) {
                SelectedTile = LeftDownTurn;
                tileCounter.RemoveTile(5);
            } else if (mousePos.y == -1 && mousePos.x == -7 && Input.GetMouseButtonDown(0) && tileCounter.numbers[6] > 0) {
                SelectedTile = LeftUpTurn;
                tileCounter.RemoveTile(6);
            } else if (mousePos.y == -3 && mousePos.x == -7 && Input.GetMouseButtonDown(0) && tileCounter.numbers[7] > 0) {
                SelectedTile = RightUpTurn;
                tileCounter.RemoveTile(7);
            } else if (mousePos.y == 3 && mousePos.x == -7 && Input.GetMouseButtonDown(0) && tileCounter.numbers[4] > 0) {
                SelectedTile = RightDownTurn;
                tileCounter.RemoveTile(4);
            } else if (mousePos.y == 1 && mousePos.x == 3 && Input.GetMouseButtonDown(0) && tileCounter.numbers[10] > 0) {
                SelectedTile = HorisontalLine;
                tileCounter.RemoveTile(10);
            } else if (mousePos.y == 3 && mousePos.x == 3 && Input.GetMouseButtonDown(0) && tileCounter.numbers[8] > 0) {
                SelectedTile = Crossroads;
                tileCounter.RemoveTile(8);
            } else if (mousePos.y == 3 && mousePos.x == 5 && Input.GetMouseButtonDown(0) && tileCounter.numbers[9] > 0) {
                SelectedTile = VerticalLine;
                tileCounter.RemoveTile(9);
            }
        }
    }
}
