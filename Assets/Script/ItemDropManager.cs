using UnityEngine;

public class ItemDropManager : MonoBehaviour
{
    public GameObject PowerUp;
    public GameObject Hp;
    public GameObject ThunderItem;

    public void DropItem(Vector3 position)
    {

        GameObject[] items = { PowerUp, Hp, ThunderItem };


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
    //                if (HpCount >= 3)
    //                    HpCount = 3;

    //                else if (HpCount <= 3)
    //                {
    //                    GameObject go = Instantiate(GetItemEffect, transform.position, Quaternion.identity);
    //                    Destroy(go, 1);
    //                    HpCount += 1;
    //                }
    //                break;
    //            case "PowerUp":
    //                if (Count >= 3)
    //                    Count = 3;

    //                else if (Count <= 3)
    //                {
    //                    GameObject go = Instantiate(GetItemEffect, transform.position, Quaternion.identity);
    //                    Destroy(go, 1);
    //                    Count += 1;
    //                }
    //                break;
    //            case "ThunderItem":
    //                if (ThunderCount >= 3)
    //                    ThunderCount = 3;

    //                else if (ThunderCount < 3)
    //                {
    //                    GameObject go = Instantiate(GetItemEffect, transform.position, Quaternion.identity);
    //                    Destroy(go, 1);
    //                    ThunderCount += 1;
    //                }
    //                break;
    //            case "EvolutionItem":
    //                GameObject go = Instantiate(GetItemEffect, transform.position, Quaternion.identity);
    //                Destroy(go, 1);
    //                isFire = false;
    //                break;
    //        }

    //        Destroy(gameObject);
    //    }
    //}

    



}


