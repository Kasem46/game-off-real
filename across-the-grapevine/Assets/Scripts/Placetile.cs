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

    void Paint(Vector3Int Position, Tile tile) { //Function to set tiles
        tilemap.SetTile(Position, tile);
    }
    void Update() { //Function to kill whoever reads this
        screenPosition = Input.mousePosition;
        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        int y = (int) Math.Floor(worldPosition.y);
        int x = (int)Math.Floor(worldPosition.x);
        Vector3Int mousePos = (new Vector3Int (x, y, 0));
        //good luck, I don't know what this is
        if (Input.GetMouseButtonDown(0) && ((mousePos.y <= 1 && mousePos.x <= 0 && mousePos.x >= -2 && mousePos.y >= -1) || (mousePos.y <= 0 && mousePos.x <= 1 && mousePos.x >= -1 && mousePos.y >= -2))) {
            Paint(mousePos, SelectedTile);
        } else if (mousePos.y == 1  && mousePos.x == -5 && Input.GetMouseButtonDown(0)) {
            SelectedTile = ForkRight;
        } else if (mousePos.y == -1  && mousePos.x == -5 && Input.GetMouseButtonDown(0)) {
            SelectedTile = ForkLeft;
        } else if (mousePos.y == -3  && mousePos.x == -5 && Input.GetMouseButtonDown(0)) {
            SelectedTile = ForkUp;
        } else if (mousePos.y == 3  && mousePos.x == -5 && Input.GetMouseButtonDown(0)) {
            SelectedTile = ForkDown;
        } else if (mousePos.y == 1  && mousePos.x == -7 && Input.GetMouseButtonDown(0)) {
            SelectedTile = LeftDownTurn;
        } else if (mousePos.y == -1  && mousePos.x == -7 && Input.GetMouseButtonDown(0)) {
            SelectedTile = LeftUpTurn;
        } else if (mousePos.y == -3  && mousePos.x == -7 && Input.GetMouseButtonDown(0)) {
            SelectedTile = RightUpTurn;
        } else if (mousePos.y == 3  && mousePos.x == -7 && Input.GetMouseButtonDown(0)) {
            SelectedTile = RightDownTurn;
        } else if (mousePos.y == 1  && mousePos.x == 3 && Input.GetMouseButtonDown(0)) {
            SelectedTile = HorisontalLine;
        } else if (mousePos.y == 3  && mousePos.x == 3 && Input.GetMouseButtonDown(0)) {
            SelectedTile = Crossroads;
        } else if (mousePos.y == 3  && mousePos.x == 5 && Input.GetMouseButtonDown(0)) {
            SelectedTile = VerticalLine;
        } 
    }
}