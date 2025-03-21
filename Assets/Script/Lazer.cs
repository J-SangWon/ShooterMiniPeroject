using UnityEngine;

public class Lazer : MonoBehaviour
{
    public float ItemVelocity = 100;
    public float RotationSpeed = 200f;
    //public GameObject LazerEffect; //임펙트
    //public int LazerCount = 0; //레이저 카운트
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

    //플레이어쪽으로 코드이동시 태그 바꿀 것
    //Destroy(collision.gameObject);
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {

    //        if (LazerCount >= 3)
    //            LazerCount = 3;

    //        else if (Count <= 3)
    //        {
    //                                        //LazerEffect 이름
    //            GameObject go = Instantiate(LazerEffect, transform.position, Quaternion.identity);
    //            Destroy(go, 1);
    //            LazerCount += 1;
    //        }
    //       
    //        Destroy(gameObject);
    //    }
    //}
}
