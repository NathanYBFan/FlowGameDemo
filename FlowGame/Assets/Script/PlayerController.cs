using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Tilemap tileMapForeGround;

    [SerializeField]
    private Tilemap bgTilemap;

    [SerializeField]
    private Tile[] directionalTiles;

    [SerializeField]
    private Vector3 offset;


    [SerializeField]
    private Vector3Int previousPosition;

    private bool holdingLMB;

    private void Update()
    {
        // If left mouse button is up
        if (Input.GetMouseButtonUp(0))
        {
            holdingLMB = false;
            previousPosition = Vector3Int.zero;
        }

        // If left mouse button is down
        if (Input.GetMouseButtonDown(0))
        {
            holdingLMB = true;
            previousPosition = GetMousePos();
        }

        if (holdingLMB)
        {
            Vector3Int mousePos = GetMousePos();
            TileBase tileCheck = bgTilemap.GetTile(mousePos);
            if (tileCheck != null && tileCheck.name.CompareTo("Grid") == 0) // && tileMapForeGround.GetTile(mousePos) == null
            {
                Tile tileToPlace = null;
                // mouse moved only left or right
                if (previousPosition.x != mousePos.x && previousPosition.y == mousePos.y)
                    tileToPlace = directionalTiles[5];
                // mouse moved only up or down
                else if (previousPosition.y != mousePos.y && previousPosition.x == mousePos.x)
                    tileToPlace = directionalTiles[4];
                // Up and to the right
                else if (previousPosition.x < mousePos.x && previousPosition.y < mousePos.y)
                    tileToPlace = directionalTiles[0];

                if (tileToPlace != null)
                    tileMapForeGround.SetTile(Vector3Int.RoundToInt(mousePos), tileToPlace);
            }
            if (previousPosition != GetMousePos())
                previousPosition = GetMousePos();
        }    
    }

    private Vector3Int GetMousePos()
    {
        // Get mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z += 11;
        mousePos += offset;
        return Vector3Int.RoundToInt(mousePos);
    }
}
