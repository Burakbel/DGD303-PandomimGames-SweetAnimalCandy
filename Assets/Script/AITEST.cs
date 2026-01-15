using UnityEngine;
using System.Collections.Generic;

public class EnemyAIController : MonoBehaviour
{
    [Header("Economy")]
    public float currentGold = 10f;
    public float goldPerSecond = 5f;
    public float maxGold = 100f;

    [Header("Spawn")]
    public List<TroopData> troopPool;
    public Transform spawnPoint;
    public float decisionInterval = 2f;

    private float decisionTimer;

    void Update()
    {
        currentGold += goldPerSecond * Time.deltaTime;
        currentGold = Mathf.Clamp(currentGold, 0, maxGold);

        decisionTimer -= Time.deltaTime;

        if (decisionTimer <= 0f)
        {
            decisionTimer = decisionInterval;
            TrySpawnTroop();
        }
    }

    void TrySpawnTroop()
    {
        TroopData troop = GetRandomAffordableTroop();
        if (troop == null) return;

        currentGold -= troop.cost;
        Instantiate(troop.prefab, spawnPoint.position, Quaternion.identity);
    }

    TroopData GetRandomAffordableTroop()
    {
        List<TroopData> affordable = new List<TroopData>();

        foreach (TroopData troop in troopPool)
        {
            if (troop.cost <= currentGold)
                affordable.Add(troop);
        }

        if (affordable.Count == 0)
            return null;

        float totalWeight = 0f;
        foreach (TroopData troop in affordable)
            totalWeight += troop.weight;

        float rand = Random.Range(0f, totalWeight);

        foreach (TroopData troop in affordable)
        {
            rand -= troop.weight;
            if (rand <= 0f)
                return troop;
        }

        return affordable[0];
    }
}
