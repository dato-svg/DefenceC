using UnityEngine;
using Random = UnityEngine.Random;


namespace Component
{
    public class SpawnBonusComponent : MonoBehaviour
    {
        [SerializeField] private GameObject[] bonus;
        private int _randomBonus;

        private void Start()
        {
            bonus = new GameObject[6];
            bonus[0] = Resources.Load<GameObject>("gage_icon_coin");
            bonus[1] = Resources.Load<GameObject>("gage_icon_coin");
            bonus[2] = Resources.Load<GameObject>("gage_icon_coin"); 
            bonus[3] = Resources.Load<GameObject>("gage_icon_coin"); 
            bonus[4] = Resources.Load<GameObject>("BigMoney");
            bonus[5] = Resources.Load<GameObject>("gage_icon_coin"); 
        }

        public void GiveCoin()
        {
            _randomBonus = Random.Range(0, 2);
            if(_randomBonus ==1)
            {
                Instantiate(bonus[Random.Range(0,bonus.Length)], transform.position, Quaternion.identity);
            }
           
        }
    }
}
