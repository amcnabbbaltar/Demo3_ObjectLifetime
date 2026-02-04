using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(Rigidbody))]
public class PooledProjectile : MonoBehaviour
{
    public float lifetime = 2f;

    IObjectPool<PooledProjectile> _pool;

    public void Init(IObjectPool<PooledProjectile> pool) => _pool = pool;

    void OnEnable()
    {
        CancelInvoke();
        Invoke(nameof(Release), lifetime);
    }

    void OnCollisionEnter(Collision other) {
        Release();
    }   

    void Release()
    {
        CancelInvoke();
        _pool.Release(this);
    }

}
