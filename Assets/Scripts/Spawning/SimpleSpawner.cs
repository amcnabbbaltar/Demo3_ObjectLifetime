using UnityEngine;

public class SimpleSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public Transform spawnPoint;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
