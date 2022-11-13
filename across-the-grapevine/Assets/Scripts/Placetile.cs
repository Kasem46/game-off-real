using System.Collections;
using System;
using UnityEngine;
using UnityEngine.Tilemaps;
public class Placetile : MonoBehaviour
{
    public Tile VerticalLine;
    public Tilemap tilemap;
    public Vector3 screenPosition;
    public Vector3 worldPosition;

    void Paint(Vector3Int Position) {
        tilemap.SetTile(Position, VerticalLine);
    }
    void Update() {
        screenPosition = Input.mousePosition;
        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        int y = (int) Math.Floor(worldPosition.y);
        int x = (int)Math.Floor(worldPosition.x);
        Vector3Int mousePos = (new Vector3Int (x, y, 0));
        //good luck
        if (Input.GetMouseButtonDown(0) && ((mousePos.y <= 1 && mousePos.x <= 0 && mousePos.x >= -2 && mousePos.y >= -1) || (mousePos.y <= 0 && mousePos.x <= 1 && mousePos.x >= -1 && mousePos.y >= -2))) {
            Paint(mousePos);
        }

    }
}