using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] tilePrefabs;
    public Transform playerTransform;
    private float spawnZ = -50.0f;
    private float cylinderLength = 100.0f;
    private int tilesOnScreen = 4;
    private float safeZone = 105.0f;
    private int lastPrefabIndex = 0;
    private List<GameObject> activeTiles;
    void Start()
    {
        activeTiles = new List<GameObject>();
        for (int i = 0; i < tilesOnScreen; i++)
        {
            if (i < 1)
            {
                SpawnTile(0);
            }
            else
            {
                SpawnTile(-1);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {
            if (playerTransform.position.z - safeZone > (spawnZ - tilesOnScreen * cylinderLength))
            {
                SpawnTile();
                DeleteTile();
            }
        }
    }

    void SpawnTile(int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)
        {
            go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        }
        else
        {
            go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;

        }
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += cylinderLength;
        activeTiles.Add(go);
    }
    
    void DeleteTile(int prefabIndex = -1)
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    int RandomPrefabIndex()
    {
        if (tilePrefabs.Length <= 1)
        {
            return 0;
        }

        int randomIndex = Random.Range(0, tilePrefabs.Length);
        // int randomIndex = lastPrefabIndex;
        // while (randomIndex == lastPrefabIndex)
        // {
        //     randomIndex = Random.Range(0, tilePrefabs.Length);
        // }
        //
        // lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
