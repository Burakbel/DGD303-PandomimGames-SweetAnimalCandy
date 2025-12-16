using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform spawnPointTest;
    public GameObject enemyA;
    public int enemyA_Cost;
    public GameObject enemyB;
    public int enemyB_Cost;
    public GameObject enemyC;
    public int enemyC_Cost;
    public GameObject enemyD;
    public int enemyD_Cost;

    public GameObject Tester;

    public void SpawnEnemyA()
    {
        if (MoneyManager.Instance.SpendMoney(enemyA_Cost))
        {
            Instantiate(enemyA, spawnPoint.position, Quaternion.identity);

        }
        else 
        {

            Debug.Log("not enoughMoeny");

        }
    }

    public void SpawnEnemyB()
    { 
        if (MoneyManager.Instance.SpendMoney(enemyB_Cost))
        {
            Instantiate(enemyB, spawnPoint.position, Quaternion.identity);
        }
        else 
        {

            Debug.Log("not enoughMoeny");
        
        }    
    }

    public void SpawnEnemyC()
    {
        if (MoneyManager.Instance.SpendMoney(enemyC_Cost))
        {
            Instantiate(enemyC, spawnPoint.position, Quaternion.identity);
        }
        else
        {

            Debug.Log("not enoughMoeny");

        }
    }

    public void SpawnEnemyD()
    {
        if (MoneyManager.Instance.SpendMoney(enemyD_Cost))
        {
            Instantiate(enemyD, spawnPoint.position, Quaternion.identity);
        }
        else
        {

            Debug.Log("not enoughMoeny");

        }
    }

    public void SpawnTest()
    {

        Instantiate(Tester, spawnPointTest.position, Quaternion.identity);

    }
}
