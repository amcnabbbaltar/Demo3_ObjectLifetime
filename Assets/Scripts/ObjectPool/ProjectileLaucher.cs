using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class ProjectileLauncher : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform spawnPoint;

    public float force = 12f;
    public float lifetime = 2f;

    public int maxActive = 5;

    ObjectPool<GameObject> _pool;
    int _active;

    void Awake()
    {
        _pool = new ObjectPool<GameObject>(
            createFunc: CreateItem,
            actionOnGet: OnGet,
            actionOnRelease: OnRelease,
            actionOnDestroy: OnDestroyItem,
            collectionCheck: true,
            defaultCapacity: maxActive,
            maxSize: maxActive
        );
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_active >= maxActive) return;

            var go = _pool.Get();

            go.transform.SetPositionAndRotation(spawnPoint.position, spawnPoint.rotation);
            go.SetActive(true);

            var rb = go.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.AddForce(spawnPoint.up * force, ForceMode.Impulse);
            }

            StartCoroutine(ReturnAfter(go, lifetime));
        }
    }

    GameObject CreateItem()
    {
        var go = Instantiate(projectilePrefab);
        go.SetActive(false);
        return go;
    }

    void OnGet(GameObject go)
    {
        _active++;
    }

    void OnRelease(GameObject go)
    {
        _active--;
        go.SetActive(false);
        // DO NOT StopAllCoroutines() here
    }

    void OnDestroyItem(GameObject go)
    {
        Destroy(go);
    }

    IEnumerator ReturnAfter(GameObject go, float seconds)
    {
        yield return new WaitForSeconds(seconds);

        // Defensive: only release if still active (not already released some other way)
        if (go != null && go.activeInHierarchy)
            _pool.Release(go);
    }
}
