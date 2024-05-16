using CrazyGames;
using UnityEngine;

public class RewardCrazyController : MonoBehaviour
{
   private void Awake()
   {
      CrazySDK.Init(()=>Debug.Log("Init"));
   }

   public void ShowRewMid()
   {
      CrazySDK.Ad.RequestAd(CrazyAdType.Midgame, null, null, null);
   }
   
   public void ShowRewRew()
   {
      CrazySDK.Ad.RequestAd(CrazyAdType.Rewarded, null, null, GiveCoin);
   }


   private void GiveCoin()
   {
      PlayerStats.AddCoin(500);
   }
   
}
