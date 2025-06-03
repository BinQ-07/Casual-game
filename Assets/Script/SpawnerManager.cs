using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public static SpawnerManager Instance;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform startTarget;
    [SerializeField] private Transform endTarget;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SpawnObject()
    {
        GameObject spawnedObject = Instantiate(prefab, startTarget.position, Quaternion.identity);

        // Beri komponen MovingObject dan jalankan inisialisasi
        MovingObject mover = spawnedObject.GetComponent<MovingObject>();
        if (mover != null)
        {
            mover.Initialize(endTarget);
        }
    }

}
