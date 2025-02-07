using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace GameNameSpace
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private AssetReference easyEnemyReference; 
        [SerializeField] private AssetReference middleEnemyReference; 
        [SerializeField] private AssetReference hardEnemyReference;  
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private float minSpawnInterval = 1f;
        [SerializeField] private float maxSpawnInterval = 5f;
        [SerializeField] private float xSpacing = 2f;

        private void Start()
        {
            StartCoroutine(SpawnWaves());
        }

        private IEnumerator SpawnWaves()
        {
            // Загружаем и спавним врагов для каждой волны
            yield return SpawnWave(easyEnemyReference, spawnPoint.position); // Передаем начальную позицию спауна
            yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));

            yield return SpawnWave(middleEnemyReference, spawnPoint.position); 
            yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));

            yield return SpawnWave(hardEnemyReference, spawnPoint.position); 
        }

        private IEnumerator SpawnWave(AssetReference enemyPrefabReference, Vector3 spawnPosition)
        {
            if (enemyPrefabReference == null)
            {
                Debug.LogWarning("[EnemySpawner] Префаб врага не назначен!");
                yield break;
            }

            // Загружаем врага асинхронно  addresables
            AsyncOperationHandle<GameObject> handle = Addressables.LoadAssetAsync<GameObject>(enemyPrefabReference);
            yield return handle;

            if (handle.Status == AsyncOperationStatus.Succeeded)   // Если загрузка прошла успешно, создаём врагов
            {
               
                GameObject enemyPrefab = handle.Result;

                for (int i = 0; i < 3; i++)
                {
                    // Изменяем позицию спауна
                    Vector3 spawnPos = new Vector3(
                        spawnPosition.x + i * xSpacing,
                        spawnPosition.y,
                        spawnPosition.z
                    );

                    Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
                }
            }
            else
            {
                Debug.LogError("[EnemySpawner] Не удалось загрузить врага!");
            }

            // Освобождаем ресурсы после использования
            Addressables.Release(handle);
        }
    }
}

