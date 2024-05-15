using UnityEngine;
using YG;

public class YandexRewardController : MonoBehaviour
{
    public void StartReward()
    {
        YandexGame.RewVideoShow(0);
    }
    
    public void GiveResources()
    {
        PlayerStats.AddCoin(500);
    }
}
