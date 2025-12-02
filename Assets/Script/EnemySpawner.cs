using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject enemyA;
    public GameObject enemyB;
    public GameObject enemyC;
    public GameObject enemyD;

    public void SpawnEnemyA()
    {
        Instantiate(enemyA, spawnPoint.position, Quaternion.identity);
    }

    public void SpawnEnemyB()
    {
        Instantiate(enemyB, spawnPoint.position, Quaternion.identity);
    }

    public void SpawnEnemyC()
    {
        Instantiate(enemyC, spawnPoint.position, Quaternion.identity);
    }

    public void SpawnEnemyD()
    {
        Instantiate(enemyD, spawnPoint.position, Quaternion.identity);
    }
}
