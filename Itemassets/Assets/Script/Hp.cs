using UnityEngine;

public class Hp : MonoBehaviour
{
    public float ItemVelocity = 100;
    public float RotationSpeed = 200f;
    //public GameObject HpUpEffect; //임펙트
    //public int HpCount = 5; //Hp 카운트
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
    //플레이어 충돌시 Hp회복 코드
    //플레이어쪽으로 코드이동시 태그 바꿀 것
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {

    //        if (HpCount >= 5)
    //            HpCount = 5;

    //        else if (Count <= 5)
    //        {
    //                                        //hp임펙트 이름
    //            GameObject go = Instantiate(HpUp, transform.position, Quaternion.identity);
    //            Destroy(go, 1);
    //            HpCount += 1;
    //        }
    //        Destroy(gameObject);
    //    }
    //}

    


}
