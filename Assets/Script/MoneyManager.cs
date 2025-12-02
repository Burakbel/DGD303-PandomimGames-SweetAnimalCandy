using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance;

    [Header("UI")]
    public TMP_Text moneyText;  

    [Header("Economy Settings")]
    public int currentMoney = 0;
 
    public float income = 2f;
    public int passiveIncomeAmount = 3;

    private float timer;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        UpdateMoneyUI();
    }

    void Update()
    {
        
        
        timer += Time.deltaTime;

        if (timer >= income)
        {
            timer = 0;
            AddMoney(passiveIncomeAmount);
        }
    }

    public void AddMoney(int amount)
    {
        
        
        currentMoney += amount;
        UpdateMoneyUI();
    }

    public bool SpendMoney(int amount)
    {
        if (currentMoney >= amount)
        {
            currentMoney -= amount;
            UpdateMoneyUI();
            return true;
        }

        
        return false; 
    }

    private void UpdateMoneyUI()
    {
        moneyText.text = currentMoney.ToString() + "$";
    }
}
