using UnityEngine;

public class ItemDropManager : MonoBehaviour
{
    public GameObject PowerUp;
    public GameObject Hp;
    public GameObject Lazer;


    //�÷��̾���
    //public GameObject Effet; //�Ŀ��� ����Ʈ
    //public int Count = 0; //�Ŀ��� ī��Ʈ ����

    
    //public int HpCount = 3; //Hp ī��Ʈ

    
    //public int LazerCount = 0; //������ ī��Ʈ


    public void DropItem(Vector3 position)
    {

        GameObject[] items = { PowerUp, Hp, Lazer };


        int random = Random.Range(0, items.Length);


        Instantiate(items[random], position, Quaternion.identity);
    }



    //�÷��̾��� ������ ȹ��Ʈ����
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
    //                    GameObject go = Instantiate(Effet, transform.position, Quaternion.identity);
    //                    Destroy(go, 1);
    //                    HpCount += 1;
    //                }
    //                break;
    //            case "PowerUp":
    //                if (Count >= 3)
    //                    Count = 3;

    //                else if (Count <= 3)
    //                {
    //                    GameObject go = Instantiate(Effet, transform.position, Quaternion.identity);
    //                    Destroy(go, 1);
    //                    Count += 1;
    //                }
    //                break;
    //            case "Lazer":
    //                if (LazerCount >= 3)
    //                    LazerCount = 3;

    //                else if (LazerCount < 3)
    //                {
    //                    GameObject go = Instantiate(Effect, transform.position, Quaternion.identity);
    //                    Destroy(go, 1);
    //                    LazerCount += 1;
    //                }
    //                break;
    //            case "EvolutionItem":
    //                GameObject go = Instantiate(Effect, transform.position, Quaternion.identity);
    //                Destroy(go, 1);
    //                isFire = false;
    //                break;
    //        }

    //        Destroy(gameObject);
    //    }
    //}

    //������ 3���� �������� �ϳ��� ���
    //public ItemDropManager itemDropManager;

    //private void Destroy()
    //{
    //    if (itemDropManager != null)
    //    {
    //        itemDropManager.DropItem(transform.position);
    //    }
    //}



}


