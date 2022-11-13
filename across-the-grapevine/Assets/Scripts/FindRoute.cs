using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FindRoute : MonoBehaviour
{
    bool[,] array2D = new bool[,] { { true, true, false, false }, { false, false, false, false}, { false, false, false, false}, { false, false, false, true} };
    public Tilemap tilemap;
    public Vector2 GrapePos;
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
