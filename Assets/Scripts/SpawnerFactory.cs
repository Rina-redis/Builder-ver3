
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets
{
    class SpawnerFactory : MonoBehaviour
    {
        [SerializeField] private GameObject spawnBasePrefab;
        [SerializeField] private Tilemap tilemap;
        public GameObject GetSpavnerByType(string enemyType)
        {
            if (spawnBasePrefab != null)
            {
                var spawnBaseScript = spawnBasePrefab.GetComponent<EnemySpawnBase>();
                spawnBaseScript.Init(enemyType);
                spawnBaseScript.gameObject.transform.position = GetRandomPosition();
            }
            return spawnBasePrefab;
        }
        private Vector3 GetRandomPosition()
        {            
            return new Vector3(Random.Range(0,10), Random.Range(0, 10), 0);
        }
    }
}
