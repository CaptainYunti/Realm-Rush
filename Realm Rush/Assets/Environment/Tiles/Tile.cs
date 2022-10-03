using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] GameObject towersParent;

    [SerializeField] bool isPlaceable;
    public bool IsPlaceable {get {return isPlaceable;}}

    GridManager gridManager;
    Pathfinder pathfinder;
    Vector2Int coordinates = new Vector2Int();

    Bank bank;

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinder>();
        bank = FindObjectOfType<Bank>();
        if (gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);

            if (!isPlaceable)
            {
                gridManager.BlockNode(coordinates);
            }
        }
    }

    private void Start()
    {

    }

    private void OnMouseDown()
    {
        bool canIBuyTower = bank.CurrentBalance >= Tower.Cost;

        if(gridManager.GetNode(coordinates).isWalkable && canIBuyTower)
        {
            if(!pathfinder.WillBlockPath(coordinates))
            {
                bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
                isPlaceable = !isPlaced;
                gridManager.BlockNode(coordinates);
            }

        }

    }

}
