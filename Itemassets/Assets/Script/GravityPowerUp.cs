using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float ItemVelocity = 2f;
    public float UpwardForce = 5f;
    public float RotationSpeed = 300f;
    //public GameObject PowerUpEffet; //파워업 임펙트
    //public int Count = 0; //카운트 세기
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


    //플레이어 충돌시 powerup임펙트 출력 후 삭제
    //플레이어쪽으로 코드이동시 태그 바꿀 것
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {
    //        //파워업 임펙트 무제한생성막기
    //        if (Count >= 3)
    //            Count = 3;

    //        else if (Count <= 3)
    //        {
    //                                       //파워업임펙트 이름
    //            GameObject go = Instantiate(PowerUpEffet, transform.position, Quaternion.identity);
    //            Destroy(go, 1);
    //            Count += 1;
    //        }
    //        Destroy(gameObject);
    //    }
    //}

    //몬스터 스크립트로 옮기면 작동 할 듯 몬스터에게서 아이템 드랍
    //public void PowerUpDrop()
    //{
    //    float dropChance = 0.5f;
    //    if (Random.value < dropChance)
    //    {
    //        Instantiate(PowerUp, transform.position, Quaternion.identity);
    //    }
    //}
}
