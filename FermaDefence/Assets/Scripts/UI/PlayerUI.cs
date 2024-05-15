using TMPro;
using UnityEngine;

namespace UI
{
    public class PlayerUI : MonoBehaviour
    {
        public static PlayerUI instance;
        [SerializeField] private TextMeshProUGUI coinText;
        [SerializeField] private int CountMoney = 100;
        private void Start()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this);
            }
            PlayerStats.SetZeroMoney();
            PlayerStats.AddCoin(CountMoney);
            ShowCoin();
            
        }

       
        
        public void ShowCoin()
        {
            coinText.text = PlayerStats.Coin.ToString();
        }
    }
}
