using UnityEngine;

public class Hp : MonoBehaviour
{
    public float ItemVelocity = 100;
    public float RotationSpeed = 200f;
    //public GameObject HpUpEffect; //����Ʈ
    //public int HpCount = 5; //Hp ī��Ʈ
    Rigidbody2D rig = null;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        rig.AddForce(randomDirection * ItemVelocity, ForceMode2D.Force);
        rig.angularVelocity = Random.Range(-RotationSpeed, RotationSpeed);
    }

    void Update()
    {

    }
    //�÷��̾� �浹�� Hpȸ�� �ڵ�
    //�÷��̾������� �ڵ��̵��� �±� �ٲ� ��
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {

    //        if (HpCount >= 5)
    //            HpCount = 5;

    //        else if (Count <= 5)
    //        {
    //                                        //hp����Ʈ �̸�
    //            GameObject go = Instantiate(HpUp, transform.position, Quaternion.identity);
    //            Destroy(go, 1);
    //            HpCount += 1;
    //        }
    //        Destroy(gameObject);
    //    }
    //}

    


}
