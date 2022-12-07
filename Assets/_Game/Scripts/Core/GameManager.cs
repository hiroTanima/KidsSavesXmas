using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private List<Transform> presentsSpawnPoints = new List<Transform>();
    [SerializeField] private List<GameObject> presentPrefabs = new List<GameObject>();
    [SerializeField] private int presentsToCollect = 10;

    private int presentCollected = 0;

    private void Start()
    {
        SpawnPresents();
    }

    private void SpawnPresents()
    {
        if (presentPrefabs == null || presentsSpawnPoints == null)
        {
            return;
        }
        for (int i = 0; i < presentsToCollect; i++)
        {
            int randPresent = Random.Range(0, presentPrefabs.Count);
            int randPosition = Random.Range(0, presentsSpawnPoints.Count);

            GameObject _present = Instantiate(presentPrefabs[randPresent], presentsSpawnPoints[randPosition].position, Quaternion.identity);
            presentsSpawnPoints.Remove(presentsSpawnPoints[randPosition]);
        }
    }

    public void CollectPresent()
    {
        presentCollected++;
        if(presentCollected == presentsToCollect)
        {
            Debug.Log("You Win!");
        }
    }
}
