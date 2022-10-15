using UnityEngine;
public class ShapeSpawner : PoolerBase<Shape> {
    [SerializeField] private Shape _shapePrefab;
    [SerializeField] private int _spawnAmount = 20, totalActive, totalInactive;
    


    private void Start() {
        InitPool(_shapePrefab); // Initialize the pool

        // var shape = Get(); // Pull from the pool
        // Release(shape); // Release back to the pool
        InvokeRepeating(nameof(Spawn), 0.2f, 0.2f);
    }

    private void Spawn()
    {
        for (int i = 0; i < _spawnAmount; i++)
        {
            Shape shape = Get();
            shape.Init(Killshape);
        }
    }

    private void Killshape(Shape shape)
    {
        Release(shape);
    }

    // Optionally override the setup components
    protected override void GetSetup(Shape shape) {
        base.GetSetup(shape);
        shape.transform.position = Vector3.zero;
        totalActive++;
        totalInactive--;
    }

    protected override void ReleaseSetup(Shape shape)
    {
        base.ReleaseSetup(shape);
        totalActive--;
        totalInactive++;
    }
}