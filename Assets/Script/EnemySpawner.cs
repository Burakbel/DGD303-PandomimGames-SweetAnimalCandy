using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    public Transform spawnPoint;

    [Header("Enemy A")]
    public GameObject enemyA_T1;
    public GameObject enemyA_T2;
    public GameObject enemyA_T3;
    public int costA_T1;
    public int costA_T2;
    public int costA_T3;

    [Header("Enemy B")]
    public GameObject enemyB_T1;
    public GameObject enemyB_T2;
    public GameObject enemyB_T3;
    public int costB_T1;
    public int costB_T2;
    public int costB_T3;

    [Header("Enemy C")]
    public GameObject enemyC_T1;
    public GameObject enemyC_T2;
    public GameObject enemyC_T3;
    public int costC_T1;
    public int costC_T2;
    public int costC_T3;

    [Header("UI Icons")]
    public Image buttonAIcon;
    public Image buttonBIcon;
    public Image buttonCIcon;
    public Sprite iconA_T1;
    public Sprite iconA_T2;
    public Sprite iconA_T3;
    public Sprite iconB_T1;
    public Sprite iconB_T2;
    public Sprite iconB_T3;
    public Sprite iconC_T1;
    public Sprite iconC_T2;
    public Sprite iconC_T3;

    [Header("UI Price Texts")]
    public TextMeshProUGUI priceTextA;
    public TextMeshProUGUI priceTextB;
    public TextMeshProUGUI priceTextC;

    public void Start()
    {
        RefreshIcons();
        RefreshPrices();


    }
    public void SpawnEnemyA()
    {
        int tier = BaseTierManager.Instance.currentTier;

        if (tier == 1)
            TrySpawn(enemyA_T1, costA_T1);
        else if (tier == 2)
            TrySpawn(enemyA_T2, costA_T2);
        else
            TrySpawn(enemyA_T3, costA_T3);
    }

    public void SpawnEnemyB()
    {
        int tier = BaseTierManager.Instance.currentTier;

        if (tier == 1)
            TrySpawn(enemyB_T1, costB_T1);
        else if (tier == 2)
            TrySpawn(enemyB_T2, costB_T2);
        else
            TrySpawn(enemyB_T3, costB_T3);
    }

    public void SpawnEnemyC()
    {
        int tier = BaseTierManager.Instance.currentTier;

        if (tier == 1)
            TrySpawn(enemyC_T1, costC_T1);
        else if (tier == 2)
            TrySpawn(enemyC_T2, costC_T2);
        else
            TrySpawn(enemyC_T3, costC_T3);
    }

    void TrySpawn(GameObject prefab, int cost)
    {
        if (MoneyManager.Instance.SpendMoney(cost))
            Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        else
            UIWarningManager.Instance.Show("Not enough money");
            Debug.Log("Not enough money");
    }


    public void RefreshIcons()
    {
        int tier = BaseTierManager.Instance.currentTier;

        if (tier == 1)
        {
            buttonAIcon.sprite = iconA_T1;
            buttonBIcon.sprite = iconB_T1;
            buttonCIcon.sprite = iconC_T1;
        }
        else if (tier == 2)
        {
            buttonAIcon.sprite = iconA_T2;
            buttonBIcon.sprite = iconB_T2;
            buttonCIcon.sprite = iconC_T2;
        }
        else
        {
            buttonAIcon.sprite = iconA_T3;
            buttonBIcon.sprite = iconB_T3;
            buttonCIcon.sprite = iconC_T3;
        }
    }
    public void RefreshPrices()
    {
        int tier = BaseTierManager.Instance.currentTier;

        if (tier == 1)
        {
            priceTextA.text = costA_T1.ToString();
            priceTextB.text = costB_T1.ToString();
            priceTextC.text = costC_T1.ToString();
        }
        else if (tier == 2)
        {
            priceTextA.text = costA_T2.ToString();
            priceTextB.text = costB_T2.ToString();
            priceTextC.text = costC_T2.ToString();
        }
        else
        {
            priceTextA.text = costA_T3.ToString();
            priceTextB.text = costB_T3.ToString();
            priceTextC.text = costC_T3.ToString();
        }


    }

}
