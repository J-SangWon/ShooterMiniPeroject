using UnityEngine;

public class Lazer : MonoBehaviour
{
    public float ItemVelocity = 100;
    public float RotationSpeed = 200f;
    //public GameObject LazerEffect; //����Ʈ
    //public int LazerCount = 0; //������ ī��Ʈ
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

    //�÷��̾������� �ڵ��̵��� �±� �ٲ� ��
    //Destroy(collision.gameObject);
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {

    //        if (LazerCount >= 3)
    //            LazerCount = 3;

    //        else if (Count <= 3)
    //        {
    //                                        //LazerEffect �̸�
    //            GameObject go = Instantiate(LazerEffect, transform.position, Quaternion.identity);
    //            Destroy(go, 1);
    //            LazerCount += 1;
    //        }
    //       
    //        Destroy(gameObject);
    //    }
    //}
}
