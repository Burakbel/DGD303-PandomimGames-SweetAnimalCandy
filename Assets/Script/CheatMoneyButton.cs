using UnityEngine;

public class CheatMoneyButton : MonoBehaviour
{
    public int cheatAmount = 1000;

    public void AddMoney()
    {
        MoneyManager.Instance.AddMoney(cheatAmount);
        Debug.Log("Cheat used: +" + cheatAmount + " gold");
    }
}
