using UnityEngine;

public class ItemDropManager : MonoBehaviour
{
    public GameObject PowerUp;
    public GameObject Hp;
    public GameObject Lazer;



    public void DropItem(Vector3 position)
    {

        GameObject[] items = { PowerUp, Hp, Lazer };


        int random = Random.Range(0, items.Length);


        Instantiate(items[random], position, Quaternion.identity);
    }

    //몬스터쪽에서 아이템 드롭매니저를 만들어 몬스터가 죽을 때 세가지 아이템 중 하나 생성
    //public ItemDropManager itemDropManager;

    //private void Destroy()
    //{
    //    if (itemDropManager != null)
    //    {
    //        itemDropManager.DropItem(transform.position);
    //    }
    //}
}
