using UnityEngine;
using UnityEngine.Pool;

public abstract class Spawner<T> : MonoBehaviour where T : Objects
{
    [SerializeField] private T _prefab;
    [SerializeField] private int _poolCapacity = 3;
    [SerializeField] private int _poolMaxSize = 5;

    protected ObjectPool<T> Pool;

    private void Awake()
    {
        Pool = new ObjectPool<T>(
            createFunc: () => Instantiate(),
            actionOnGet: (obj) => InitializeObject(obj),
            actionOnRelease: (obj) => Disable(obj),
            actionOnDestroy: (obj) => Unsubscribe(obj),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    public virtual void SpawnObject(Vector2 position, Quaternion rotation)
    {
        T obj = Pool.Get();
        obj.Initialize(position,rotation);
    }

    protected virtual void InitializeObject(T obj)
    {
        obj.transform.rotation = Quaternion.identity;
        obj.gameObject.SetActive(true);
    }

    private void Subscribe(T obj)
    {
        obj.Disable += OnEnemyDisable;
    }

    private void Unsubscribe(T obj)
    {
        obj.Disable -= OnEnemyDisable;
        Destroy(obj.gameObject);
    }

    private T Instantiate()
    {
        T obj = Instantiate(_prefab);
        Subscribe(obj);
        return obj;
    }

    private void OnEnemyDisable(Objects obj)
    {
        if (obj != null)
        {
            Release(obj as T);
        }
    }

    private void Disable(T obj)
    {
        obj.gameObject.SetActive(false);
    }

    private void Release(T obj)
    {
        Pool.Release(obj);
    }
}
