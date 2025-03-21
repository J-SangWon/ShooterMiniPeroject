using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float ItemVelocity = 2f;
    public float UpwardForce = 5f;
    public float RotationSpeed = 300f;
    //public GameObject PowerUpEffet; //�Ŀ��� ����Ʈ
    //public int Count = 0; //ī��Ʈ ����
    Rigidbody2D rig;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.linearVelocity = new Vector2(0f, UpwardForce);

        rig.angularVelocity = RotationSpeed;
    }

    void Update()
    {

    }


    //�÷��̾� �浹�� powerup����Ʈ ��� �� ����
    //�÷��̾������� �ڵ��̵��� �±� �ٲ� ��
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        //�Ŀ��� ����Ʈ �����ѻ�������
    //        if (Count >= 3)
    //            Count = 3;

    //        else if (Count <= 3)
    //        {
    //                                       //�Ŀ�������Ʈ �̸�
    //            GameObject go = Instantiate(PowerUpEffet, transform.position, Quaternion.identity);
    //            Destroy(go, 1);
    //            Count += 1;
    //        }
    //        Destroy(gameObject);
    //    }
    //}

    //���� ��ũ��Ʈ�� �ű�� �۵� �� �� ���Ϳ��Լ� ������ ���
    //public void PowerUpDrop()
    //{
    //    float dropChance = 0.5f;
    //    if (Random.value < dropChance)
    //    {
    //        Instantiate(PowerUp, transform.position, Quaternion.identity);
    //    }
    //}
}
