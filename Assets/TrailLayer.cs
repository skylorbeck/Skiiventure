using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailLayer : MonoBehaviour
{
    public bool isDone => transform.position.y > GameMaster.Instance.pathManager.maxDistance;
    public GameObject endPoint;
    public List<GameObject> spawnPoints = new List<GameObject>();
    public List<GameObject> objects => GameMaster.Instance.pathManager.objects;
    public List<TrailLayer> linkedLayers = new List<TrailLayer>();

    //TODO collider for off track
    public void Start()
    {
        
    }

    public void SpawnObstacles()
    {
        foreach (GameObject point in spawnPoints)
        {
            GameObject obstacle = Instantiate(objects[UnityEngine.Random.Range(0, objects.Count)], point.transform.position,
                Quaternion.identity);
            obstacle.transform.parent = transform;
            point.SetActive(false);
        }
    }
}
