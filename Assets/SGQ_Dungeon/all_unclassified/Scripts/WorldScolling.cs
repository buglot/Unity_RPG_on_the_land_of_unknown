using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WorldScolling : MonoBehaviour
{
    [SerializeField]Transform playerTransform;
    Vector2Int currentTilePosition = new Vector2Int(0,0);
    [SerializeField] Vector2Int playerTilePosition;   
    Vector2Int onTileGridPlayerPosition;
    [SerializeField] float tileSize = 20f;
    GameObject[,] terrainTiles;

    [SerializeField] int terrainTilesHorizontalCount;
    [SerializeField] int terrainTilesVerticalCount;

    [SerializeField] int fieldofVisionHeight = 3;
    [SerializeField] int fieldofVisionWidth = 3;

    private void Awake()
    {
        terrainTiles = new GameObject[terrainTilesHorizontalCount, terrainTilesVerticalCount];
    }

    private void Start()
    {
        UpdateTileOnScreen();
    }
    
    private void Update()
    {
        playerTilePosition.x = (int)(playerTransform.position.x /tileSize);
        playerTilePosition.y = (int)(playerTransform.position.y /tileSize);

        playerTilePosition.x -= playerTransform.position.x < 0 ? 1 : 0;
        playerTilePosition.y -= playerTransform.position.y < 0 ? 1 : 0;


        if(currentTilePosition != playerTilePosition)
        {
            currentTilePosition = playerTilePosition;

            onTileGridPlayerPosition.x = CalculatePositionOnAxis(onTileGridPlayerPosition.x, true);
            onTileGridPlayerPosition.y = CalculatePositionOnAxis(onTileGridPlayerPosition.y, false);

            UpdateTileOnScreen();
        }
    }
    private void  UpdateTileOnScreen()
    {
        for(int pov_x = -(fieldofVisionWidth/2); pov_x <= fieldofVisionWidth/2; pov_x++)
        {
            for(int pov_y = -(fieldofVisionHeight/2); pov_y <= fieldofVisionHeight/2; pov_y++)
            {
                int tileToUpdate_x = CalculatePositionOnAxis(playerTilePosition.x + pov_x, true);
                int tileToUpdate_y = CalculatePositionOnAxis(playerTilePosition.y + pov_y, false);

                GameObject tile = terrainTiles[tileToUpdate_x, tileToUpdate_y];
                tile.transform.position = CalculateTilePosition(
                    playerTilePosition.x + pov_x,
                    playerTilePosition.y + pov_y);
            }   
        }
    }

    private Vector3 CalculateTilePosition(int x, int y)
    {
        return new Vector3(x * tileSize, y * tileSize,0f);
    }

    private int CalculatePositionOnAxis(float currentValue , bool horizontal)
    {
        if(horizontal)
        {
            if(currentValue >= 0)
            {
                currentValue = currentValue % terrainTilesHorizontalCount;
            }
            else
            {
                currentValue += 1;
                currentValue = terrainTilesHorizontalCount - 1 + currentValue % terrainTilesHorizontalCount;
            }
        }
        else
        {
            if(currentValue >= 0)
            {
                currentValue = currentValue % terrainTilesVerticalCount;
            }
            else
            {
                currentValue += 1;
                currentValue = terrainTilesVerticalCount - 1 + currentValue % terrainTilesVerticalCount;
            }
        }
        return (int)currentValue;
    }
    public void Add(GameObject tilegameObject, Vector2Int tilePosition)
    {
         terrainTiles[tilePosition.x,tilePosition.y] = tilegameObject;
    }
}
