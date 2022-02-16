using UnityEngine;

public class Spawnable : MonoBehaviour
{
    private Transform playerTransform;

    void Start()
    {
        playerTransform = ObjectsSpawner.playerTransform;
        ObjectsSpawner.spawnedList.Add(this);
    }

    void FixedUpdate(){
        DestroyDistant();
    }

    void OnDestroy(){
        ObjectsSpawner.spawnedList.Remove(this);
    }

    private void DestroyDistant(){
        if(IsTooFarFromPlayer()){
            Destroy(this);
            Destroy(gameObject);
        }
    }

    private bool IsTooFarFromPlayer(){
        return(Vector3.Distance(playerTransform.position, transform.position) > ObjectsSpawner.despawnDistance);
    }
}
