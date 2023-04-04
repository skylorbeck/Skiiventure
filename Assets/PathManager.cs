using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    public List<GameObject> objects = new List<GameObject>();
    public float speed => GameMaster.Instance.player.moveSpeed;
    public List<TrailLayer> layers = new List<TrailLayer>();
    public float maxDistance = 200f;
    public int maxLayers = 10;
    void Start()
    {
        
    }

    public void SpawnLayer()
    {
        List<TrailLayer> availableLayers = new List<TrailLayer>(layers[^1].linkedLayers);
        if (availableLayers.Count <= 0) return;
        {
            TrailLayer layer = Instantiate(availableLayers[Random.Range(0, availableLayers.Count)], transform);
            layer.SpawnObstacles();
            Vector3 pos = layers[^1].endPoint.transform.position;
            pos.z = layer.transform.position.z;
            layer.transform.position = pos;
            layers.Add(layer);
        }
    }

    public void CleanUpLayers()
    {
        List<TrailLayer> layersToRemove = new List<TrailLayer>();
        layers.ForEach(layer =>
        {
            if (!layer.isDone) return;
            layersToRemove.Add(layer);
        });
        layersToRemove.ForEach(layer =>
        {
            layers.Remove(layer);
            Destroy(layer.gameObject);
        });
    }

    void Update()
    {
        layers.ForEach(layer => layer.transform.position += new Vector3(0,speed * Time.deltaTime,0));
        if (layers.Count < maxLayers)
        {
            SpawnLayer();
        }
        CleanUpLayers();
    }
}
