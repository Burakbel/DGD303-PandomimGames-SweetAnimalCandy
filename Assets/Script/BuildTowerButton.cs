using UnityEngine;
using TMPro;

public class BuildTowerButton : MonoBehaviour
{
    public GameObject towerPrefab;
    public Transform spawnPoint;
    public int cost = 50;

    [Header("UI")]
    public TextMeshProUGUI priceText;

    private bool isBought = false;

    private void Start()
    {
        UpdatePriceText();
    }

    public void BuyTower()
    {
        if (isBought)
            return;

        if (!MoneyManager.Instance.SpendMoney(cost))
        {
            UIWarningManager.Instance.Show("Not Enough Money!");
            return;
        }

        Instantiate(towerPrefab, spawnPoint.position, Quaternion.identity);

        isBought = true;
        UpdatePriceText();
    }

    void UpdatePriceText()
    {
        if (isBought)
            priceText.text = "MAX LEVEL";
        else
            priceText.text = cost.ToString();
    }
}
