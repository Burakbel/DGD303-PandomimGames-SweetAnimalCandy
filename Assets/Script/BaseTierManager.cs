using UnityEngine;
using TMPro;
using System.Collections;

public class BaseTierManager : MonoBehaviour
{
    public static BaseTierManager Instance;

    [Header("Tier Settings")]
    public int currentTier = 1;
    public int maxTier = 3;

    [Header("Upgrade Costs")]
    public int tier2Cost = 100;
    public int tier3Cost = 250;

    [Header("UI")]
    public TextMeshProUGUI costText;
    public TextMeshProUGUI warningText;

    private Coroutine warningRoutine;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        UpdateCostText();

      
        SetTextAlpha(warningText, 0f);
    }

    public void UpgradeBase()
    {
        if (currentTier >= maxTier)
            return;

        int cost = GetUpgradeCost();

        if (!MoneyManager.Instance.SpendMoney(cost))
        {
            ShowWarning("Not enough money");
            return;
        }

        currentTier++;
        Debug.Log("Base upgraded to Tier " + currentTier);

        UpdateCostText();
    }

    void UpdateCostText()
    {
        if (currentTier >= maxTier)
        {
            costText.text = "MAX LEVEL";
        }
        else
        {
            costText.text = "" + GetUpgradeCost();
        }
    }

    int GetUpgradeCost()
    {
        if (currentTier == 1) return tier2Cost;
        if (currentTier == 2) return tier3Cost;
        return 0;
    }

    void ShowWarning(string message)
    {
        warningText.text = message;

        if (warningRoutine != null)
            StopCoroutine(warningRoutine);

        warningRoutine = StartCoroutine(FadeWarning());
    }

    IEnumerator FadeWarning()
    {
        float duration = 1f;
        float stayTime = 1.5f;

     
        yield return FadeText(warningText, 0f, 1f, duration);

       
        yield return new WaitForSeconds(stayTime);

     
        yield return FadeText(warningText, 1f, 0f, duration);
    }

    IEnumerator FadeText(TextMeshProUGUI text, float from, float to, float time)
    {
        float t = 0f;

        while (t < time)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(from, to, t / time);
            SetTextAlpha(text, alpha);
            yield return null;
        }

        SetTextAlpha(text, to);
    }

    void SetTextAlpha(TextMeshProUGUI text, float alpha)
    {
        Color c = text.color;
        c.a = alpha;
        text.color = c;
    }
}
