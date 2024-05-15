using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class Drop : MonoBehaviour , IDropHandler
    {
       
        public GameObject[] _turrels;

        private void Start()
        {
            _turrels = new GameObject[5];
            for (int i = 0; i < _turrels.Length; i++)
            {
                _turrels[i] = Resources.Load<GameObject>($"Tureel {i}");
            }
        }
        
        public void OnDrop(PointerEventData eventData)
        {
            var anotherSlot = eventData.pointerDrag.transform;
            

            if (gameObject.GetComponentInChildren<Drag>()!= null)
            {
                if (anotherSlot.GetComponent<Drag>().turels == gameObject.GetComponentInChildren<Drag>().turels 
                    && anotherSlot.GetComponent<Drag>().turels != Turels.level5 )
                {
                    Destroy(anotherSlot.gameObject);
                    Destroy(transform.GetChild(0).gameObject);
                    TurrelsSpawner(gameObject.GetComponentInChildren<Drag>().turels);

                }
            
                else 
                {
              
                    anotherSlot.localPosition = Vector3.zero;
                }  
            }
            else
            {
                anotherSlot.SetParent(transform);
                anotherSlot.localPosition = Vector3.zero;
            }
            
            
            
            
            
            
        }
        
       private void TurrelsSpawner(Turels turels)
        {
            switch (turels)
            {
                case Turels.level1:
                   Debug.Log("Turrel 1");
                   GameObject turel = Instantiate(_turrels[1]);
                   turel.transform.SetParent(gameObject.transform);
                   turel.GetComponent<RectTransform>().localScale = Vector3.one;
                   turel.transform.localPosition = Vector3.zero;


                   break;
                case Turels.level2:
                    Debug.Log("Turrel 2");
                    GameObject turel2 = Instantiate(_turrels[2]);
                    turel2.transform.SetParent(gameObject.transform);
                    turel2.GetComponent<RectTransform>().localScale = Vector3.one;
                    turel2.transform.localPosition = Vector3.zero;
                    break;
                case Turels.level3:
                    Debug.Log("Turrel 3");
                    GameObject turel3 = Instantiate(_turrels[3]);
                    turel3.transform.SetParent(gameObject.transform);
                    turel3.GetComponent<RectTransform>().localScale = Vector3.one;
                    turel3.transform.localPosition = Vector3.zero;
                    break;
                case Turels.level4:
                    Debug.Log("Turrel 4");
                    GameObject turel4 = Instantiate(_turrels[4]);
                    turel4.transform.SetParent(gameObject.transform);
                    turel4.GetComponent<RectTransform>().localScale = Vector3.one;
                    turel4.transform.localPosition = Vector3.zero;
                    break;
                case Turels.level5:
                    Debug.Log("Turrel 5");
                    GameObject turel5 = Instantiate(_turrels[5]);
                    turel5.transform.SetParent(gameObject.transform);
                    turel5.GetComponent<RectTransform>().localScale = Vector3.one;
                    turel5.transform.localPosition = Vector3.zero;
                    break;
            }
        }
    }
}
