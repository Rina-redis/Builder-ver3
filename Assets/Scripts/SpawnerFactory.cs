
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets
{
    class SpawnerFactory : MonoBehaviour
    {
        [SerializeField] private GameObject spawnBasePrefab;
        [SerializeField] private Tilemap tilemap;
        public GameObject GetSpavnerByType(string Type)
        {
            if (spawnBasePrefab != null)
            {
                var spawnBaseScript = spawnBasePrefab.GetComponent<EnemySpawnBase>();
                spawnBaseScript.gameObject.transform.position = GetRandomPosition();
            }
            return spawnBasePrefab;
        }
        private void Start()
        {
           
        }
        private Vector3 GetRandomPosition()
        {
            
            return new Vector3(Random.RandomRange(0,10), Random.RandomRange(0, 10), 0);
        }
    }
}
