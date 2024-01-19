using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject slimePrefab;
    [SerializeField]
    private GameObject skeletonPrefab;
    [SerializeField]
    private GameObject miniSkeletonPrefab;

    [SerializeField]
    private float slimeInterval = 4f;
    [SerializeField]
    private float skeletonInterval = 9f;
    [SerializeField]
    private float miniSkeletonInterval = 6f;

    [SerializeField]
    private float minRangeX;
    [SerializeField]
    private float minRangeY;
    [SerializeField]
    private float maxRangeX;
    [SerializeField]
    private float maxRangeY;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnSlime", 0, slimeInterval);
        InvokeRepeating("SpawnSkeleton", 0, skeletonInterval);
        InvokeRepeating("SpawnMiniSkeleton", 0, miniSkeletonInterval);
    }


    private void SpawnSlime()
    {
        SpawnEnemy(slimePrefab);
    }
    private void SpawnSkeleton()
    {
        SpawnEnemy(skeletonPrefab);
    }
    private void SpawnMiniSkeleton()
    {
        SpawnEnemy(miniSkeletonPrefab);
    }
    

    private void SpawnEnemy(GameObject enemy)
    {
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(2.75f, 4.6f), Random.Range(-2.15f, 1.5f), 0f), Quaternion.identity);
    }
}

