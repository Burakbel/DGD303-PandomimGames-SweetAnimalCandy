using UnityEngine;


[CreateAssetMenu(menuName = "Troop Data")]
public class TroopData : ScriptableObject
{
    public GameObject prefab;
    public int cost;
    public float weight; 
}

