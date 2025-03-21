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

    //�����ʿ��� ������ ��ӸŴ����� ����� ���Ͱ� ���� �� ������ ������ �� �ϳ� ����
    //public ItemDropManager itemDropManager;

    //private void Destroy()
    //{
    //    if (itemDropManager != null)
    //    {
    //        itemDropManager.DropItem(transform.position);
    //    }
    //}
}
