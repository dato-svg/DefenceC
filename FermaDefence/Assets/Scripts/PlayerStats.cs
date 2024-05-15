using UI;
using UnityEngine;

public static class PlayerStats
{
    public static int Coin { get; private set; }


    public static void AddCoin(int count)
    {
        Coin += count;
        Debug.Log(Coin + "Coin");
        PlayerUI.instance.ShowCoin();
    }

    public static void SetZeroMoney()
    {
        Coin = 0;
        PlayerUI.instance.ShowCoin();
    }
    
    
}
