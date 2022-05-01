using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    private float[]position= new float[4];
    private int randCount;
    
    private float minSpawnX = -6;
    private float timeSinceLastSpawned;
    public float spawnRateMin = 1f;
    public float spawnRateMax = 2f;
    private float spawnRate;
    private float timeRand;
    public List<GameObject> obstacle = new List<GameObject>();

    void Start()
    {
        timeSinceLastSpawned = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        for (int i = 0; i < 4; i++)
        {
            position[i] = minSpawnX;
            minSpawnX += 4;
            //Debug.Log(position[i]);
        }
    }

    void Update()
    {
        if (GameControl.instance.gameStage == 2)
        {
            timeSinceLastSpawned += Time.deltaTime;
            if (timeSinceLastSpawned > spawnRate)
            {
                timeSinceLastSpawned = 0f;
                SpawnObstacle();
            }
        }
    }

    private void SpawnObstacle()
    {
        List<GameObject> obstacle4 = new List<GameObject>();

        List<int> num4 = new List<int>();
        num4.Add(0); num4.Add(1); num4.Add(2); num4.Add(3);

        randCount = Random.Range(1, 4);
        Debug.Log("\nrand count - " + randCount);
        int[] destroyObj = new int[randCount];

        for (int i = 0; i < destroyObj.Length; i++)
        {
            int temp = Random.Range(0, num4.Count);
            destroyObj[i] = num4[temp];
            num4.RemoveAt(temp);
            
            Debug.Log(i + " - " + destroyObj[i]);
        }

        int listCount = 0;
        for (int i = 0; i < 4; i++)
        {
            bool save = true;
            for (int j = 0; j < destroyObj.Length; j++)
            {
                if (i == destroyObj[j])
                    save = false;
            }
            Debug.Log(i + " - BOOL - " + save);
            if (save)
            {
                //randCount = Random.Range(0f, 1f);
                //Debug.Log(randCount);
                //if (obstacle4.Count < 3)
                //    if (randCount >= 0.5){}

                //Debug.Log(i);
                //Debug.Log(position[i]);
                obstacle4.Add(obstacle[Random.Range(0, obstacle.Count)]);
                Instantiate(obstacle4[listCount], new Vector3(position[i], 0f, Random.Range(35f, 45f)), Quaternion.identity);
                listCount++;
            }
        }
    }
}