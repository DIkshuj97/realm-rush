using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] int towerLimit = 5;
    [SerializeField] Transform towerParentTransform;

    Queue<Tower> towerQueue = new Queue<Tower>();

    public void AddTower(WayPoint baseWayPoint)
    {
        int numTowers = towerQueue.Count;

        if (numTowers < towerLimit)
        {
            InstantiateNewTower(baseWayPoint);
        }
        else
        {
            MoveExistingTower(baseWayPoint);
        }
    }

    private void InstantiateNewTower(WayPoint baseWayPoint)
    {
        var newTower= Instantiate(towerPrefab, baseWayPoint.transform.position, Quaternion.identity);
        newTower.transform.parent = towerParentTransform;
        baseWayPoint.isPlaceable = false;

        newTower.baseWayPoint = baseWayPoint;
        towerQueue.Enqueue(newTower);
    }

    private void MoveExistingTower(WayPoint newbaseWayPoint)
    {
        var oldTower = towerQueue.Dequeue();
        oldTower.baseWayPoint.isPlaceable = true;

        newbaseWayPoint.isPlaceable = false;

        oldTower.baseWayPoint = newbaseWayPoint;
        oldTower.transform.position = newbaseWayPoint.transform.position;

        towerQueue.Enqueue(oldTower);
    }

}
