using UnityEngine;

public class ItemDropManager : MonoBehaviour
{
    public GameObject PowerUp;
    public GameObject Hp;
    public GameObject Lazer;
    public GameObject EvolutionItem;

    //�÷��̾���
    //public GameObject PowerUpEffet; //�Ŀ��� ����Ʈ
    //public int Count = 0; //ī��Ʈ ����

    //public GameObject HpUpEffect; //����Ʈ
    //public int HpCount = 5; //Hp ī��Ʈ

    //public GameObject LazerEffect; //����Ʈ
    //public int LazerCount = 0; //������ ī��Ʈ

    //public GameObject EvolutionEffect;
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


