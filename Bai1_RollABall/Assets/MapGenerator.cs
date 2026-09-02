using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject pathPrefab;
    public int numbOfRoad = 2;
    // Start is called before the first frame update
    void Start()
    {
        GenerateMap();
    }

    public void GenerateMap()
    {
        List<int> spawned = new List<int>();
        for (int i = 0; i < 10; i ++)
        {
            Vector3 position = Vector3.one;
            position.z = 10 * i;
            List<int> currentSpawn = new List<int>();

            if(i > 0 && currentSpawn.Count == 0)
            {
                int rand = Random.Range(0, spawned.Count);
                currentSpawn.Add(spawned[rand]);
                SpawnPath(position, spawned[rand]);
            }

            for (int j = 0; j < numbOfRoad; j ++)
            {
                float rand = Random.Range(0, 1f);
                if ((rand < 0.5f && i > 0) || spawned.Contains(j)) continue;
                //
                currentSpawn.Add(j);
                SpawnPath(position, j);
            }

            spawned = currentSpawn;
        }
        

    }

    void SpawnPath(Vector3 position, int index)
    {
        int width = numbOfRoad * 2;
        position.x = -((float)width / 2) + 1 + 2 * index;
        Instantiate(pathPrefab, position, Quaternion.identity, transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
