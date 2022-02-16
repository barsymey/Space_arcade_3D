using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsSpawner : MonoBehaviour
{
    public static Transform playerTransform;
    public static HashSet<Spawnable> spawnedList = new HashSet<Spawnable>();
    public static float despawnDistance = 300;
    [SerializeField] int maxSpawnableAmount = 100;
    [SerializeField] GameObject[] spawnables;

    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        if(NeedMoreSpawnables()){
            Spawn(GetRandomPositionInFrontOfPlayer());
        }

    }

    void FixedUpdate()
    {
        if(NeedMoreSpawnables()){
            Spawn(GetRandomPositionInFrontOfPlayer());
        }
    }

    private void Spawn(Vector3 position){
        Instantiate(spawnables[Random.Range(0,spawnables.Length)], position, Quaternion.identity, transform.parent);
    }

    private bool NeedMoreSpawnables(){
        return(spawnedList.Count < maxSpawnableAmount);
    }

    private Vector3 GetRandomPositionInFrontOfPlayer(){
        float spawnDistance = Random.Range(20, despawnDistance);
        Vector3 spawnOffset = new Vector3(Random.Range(-360, 360), Random.Range(-360, 360), Random.Range(-360, 360)).normalized * spawnDistance;
        return playerTransform.position + spawnOffset;
    }
}
