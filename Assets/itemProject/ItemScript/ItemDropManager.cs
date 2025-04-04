﻿using UnityEngine;

public class ItemDropManager : MonoBehaviour
{
    public GameObject PowerUp;
    public GameObject Hp;
    public GameObject ThunderItem;

    public void DropItem(Vector3 position)
    {

        Vector3 p = position;
        //50% 확률 드롭
        if (Random.Range(0f, 1f) > 0.7f)
            return;

        float random = Random.Range(0f, 1f);

        if (random < 0.3f) // 30%확률
        {
            Instantiate(Hp, p, Quaternion.identity);
        }
        else if (random < 0.8f) //50%확률
        {
            Instantiate(PowerUp, p, Quaternion.identity);
        }
        else // 20% 확률
        {
            Instantiate(ThunderItem, p, Quaternion.identity);
        }
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


