using UnityEngine;

public class SuperCandyManager : MonoBehaviour
{
    public static SuperCandyManager Instance;

    public GameObject candyPrefab;
    public Transform startPoint;

    void Awake()
    {
        Instance = this;
    }

    public void SpawnCandy()
    {
        Instantiate(candyPrefab, startPoint.position, Quaternion.identity);
    }
}
