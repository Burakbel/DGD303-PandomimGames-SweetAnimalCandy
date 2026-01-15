using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SuperPowerButton : MonoBehaviour
{
    public Button button;
    public TMP_Text cooldownText;
    public float cooldown = 60f;

    private bool canUse = true;

    void Start()
    {
        button.onClick.AddListener(UsePower);
    }

    void UsePower()
    {
        if (!canUse) return;

        canUse = false;
        button.interactable = false;

        SuperCandyManager.Instance.SpawnCandy();

        Invoke(nameof(ResetCooldown), cooldown);
    }

    void ResetCooldown()
    {
        canUse = true;
        button.interactable = true;
    }
}
