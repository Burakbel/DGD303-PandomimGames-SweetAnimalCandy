using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System.Collections;

public class SuperPowerTextCooldownTMP : MonoBehaviour, IPointerClickHandler
{
    [Header("UI")]
    public TMP_Text cooldownText; 
    public float cooldownTime = 120f;

    private bool canUse = true;

    void Start()
    {
        cooldownText.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!canUse) return;

        // Süper gücü çalýþtýr
        SuperCandyManager.Instance.SpawnCandy();

        StartCoroutine(CooldownRoutine());
    }

    IEnumerator CooldownRoutine()
    {
        canUse = false;

        cooldownText.gameObject.SetActive(true);

        float timeLeft = cooldownTime;

        while (timeLeft > 0)
        {
            cooldownText.text = Mathf.CeilToInt(timeLeft).ToString();
            yield return new WaitForSeconds(1f);
            timeLeft--;
        }

        cooldownText.gameObject.SetActive(false);
        canUse = true;
    }
}
