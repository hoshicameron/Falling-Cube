using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlatformSpawner : MonoBehaviour
{
   [SerializeField] private GameObject platformPrefab = null;
   [SerializeField] private GameObject spikePlatformPrefab = null;
   [SerializeField] private GameObject[] movingPlatformPrefab = null;
   [SerializeField] private GameObject breakablePlatformPrefab = null;

   [SerializeField] private float spawnTimer = 2.0f;
   [SerializeField] private float minX = -2f, maxX = 2f;

   private float currentSpawnTimer;
   private int platformSpawnCount;

   private void Start()
   {
      currentSpawnTimer = spawnTimer;

      GameObject platform = PoolManager.Instance.ReuseGameObject(platformPrefab, new Vector3(0, -3f, 0), Quaternion.identity);
      platform.SetActive(true);
   }

   private void Update()
   {
      if(GameManager.Instance.IsGameRunning)
         SpawnPlatforms();
   }

   private void SpawnPlatforms()
   {
      currentSpawnTimer += Time.deltaTime;

      if (currentSpawnTimer >= spawnTimer)
      {
         currentSpawnTimer = 0f;
         platformSpawnCount++;

         var temp = transform.position;
         temp.x = Random.Range(minX, maxX);

         GameObject newPlatform = null;

         if (platformSpawnCount < 2)
         {
            newPlatform = PoolManager.Instance.ReuseGameObject(platformPrefab, temp, Quaternion.identity);
            newPlatform.SetActive(true);
         }
         else if (platformSpawnCount == 2)
         {
            if (Random.Range(0, 2) > 0)
            {
               newPlatform = PoolManager.Instance.ReuseGameObject(breakablePlatformPrefab, temp, Quaternion.identity);
               newPlatform.SetActive(true);
            } else
            {
               newPlatform = PoolManager.Instance.ReuseGameObject(movingPlatformPrefab[Random.Range(0, movingPlatformPrefab.Length)], temp,
                  quaternion.identity);
               newPlatform.SetActive(true);
            }
         } else
         {
            int rnd = Random.Range(0, 10);
            if ( rnd<= 4)
            {
               newPlatform = PoolManager.Instance.ReuseGameObject(platformPrefab, temp, Quaternion.identity);
               newPlatform.SetActive(true);
            } else if(rnd==5)
            {
               newPlatform = PoolManager.Instance.ReuseGameObject(spikePlatformPrefab, temp, Quaternion.identity);
               newPlatform.SetActive(true);
            } else
            {
               if (Random.Range(0, 2) > 0)
               {
                  newPlatform = PoolManager.Instance.ReuseGameObject(breakablePlatformPrefab, temp, Quaternion.identity);
                  newPlatform.SetActive(true);
               } else
               {
                  newPlatform = PoolManager.Instance.ReuseGameObject(movingPlatformPrefab[Random.Range(0, movingPlatformPrefab.Length)], temp,
                     quaternion.identity);
                  newPlatform.SetActive(true);
               }
            }

         }
      }
   }
}//Class
