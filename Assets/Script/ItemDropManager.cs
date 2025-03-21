using UnityEngine;

public class ItemDropManager : MonoBehaviour
{
    public GameObject PowerUp;
    public GameObject Hp;
    public GameObject Lazer;
    public GameObject EvolutionItem;

    //플레이어쪽
    //public GameObject PowerUpEffet; //파워업 임펙트
    //public int Count = 0; //카운트 세기

    //public GameObject HpUpEffect; //임펙트
    //public int HpCount = 5; //Hp 카운트

    //public GameObject LazerEffect; //임펙트
    //public int LazerCount = 0; //레이저 카운트

    //public GameObject EvolutionEffect;
    public void DropItem(Vector3 position)
    {

        GameObject[] items = { PowerUp, Hp, Lazer };


        int random = Random.Range(0, items.Length);


        Instantiate(items[random], position, Quaternion.identity);
    }

    

    //플레이어쪽 아이템 획득트리거
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Item"))
    //    {
    //        switch (gameObject.tag)
    //        {
    //            case "Hp" :
    //                if (HpCount >= 5)
    //                    HpCount = 5;

    //                else if (HpCount <= 5)
    //                {
    //                    GameObject go = Instantiate(Hp, transform.position, Quaternion.identity);
    //                    Destroy(go, 1);
    //                    HpCount += 1;
    //                }
    //                break;
    //            case "PowerUp":
    //                if (Count >= 3)
    //                    Count = 3;

    //                else if (Count <= 3)
    //                {
    //                    GameObject go = Instantiate(PowerUp, transform.position, Quaternion.identity);
    //                    Destroy(go, 1);
    //                    Count += 1;
    //                }
    //                break;
    //            case "Lazer":
    //                if (LazerCount >= 3)
    //                    LazerCount = 3;

    //                else if (LazerCount < 3)
    //                {
    //                    GameObject go = Instantiate(Lazer, transform.position, Quaternion.identity);
    //                    Destroy(go, 1);
    //                    LazerCount += 1;
    //                }
    //                break;
    //            case "EvolutionItem":
    //                isFire = false;
    //                break;
    //        }
            
    //        Destroy(gameObject);
    //    }
    //}

    //몬스터쪽 3가지 아이템중 하나를 드롭
    //public ItemDropManager itemDropManager;

    //private void Destroy()
    //{
    //    if (itemDropManager != null)
    //    {
    //        itemDropManager.DropItem(transform.position);
    //    }
    //}



}


