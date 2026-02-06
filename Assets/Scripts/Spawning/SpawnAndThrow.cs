using UnityEngine;

public class SpawnAndThrow : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public Transform spawnPoint;
    public float throwForce = 10f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject obj = Instantiate(
                prefabToSpawn,
                spawnPoint.position,
                spawnPoint.rotation
            );

            Rigidbody rb = obj.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(spawnPoint.forward * throwForce, ForceMode.Impulse);
            }
        }
    }
}
