using UnityEngine;

public class Monster : MonoBehaviour
{
    public float speed = 3f;
    public int health = 5;
    private Animator anim;  // 애니메이터 추가

    void Start()
    {
        anim = GetComponent<Animator>();  // 애니메이터 가져오기
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }

    //합치기 전 주석 처리
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Shot"))
    //    {
    //        Shot shot = collision.GetComponent<Shot>();
    //        if (shot != null)
    //        {
    //            health -= shot.AttackDamage;
    //            anim.SetTrigger("Hit");  // 맞았을 때 애니메이션 재생

    //            if (health <= 0) Die();
    //        }
    //        Destroy(collision.gameObject);
    //    }
    //    else if (collision.CompareTag("Thunder"))
    //    {
    //        health -= 10;
    //        anim.SetTrigger("Hit");

    //        if (health <= 0) Die();
    //        Destroy(collision.gameObject);
    //    }
    //    else if (collision.CompareTag("Player")) // Player와 충돌
    //    {
    //        Player player = collision.GetComponent<Player>();
    //        if (player != null)
    //        {
    //            player.life--; // 플레이어 목숨 1 감소
    //        }

    //        anim.SetTrigger("Hit");  // 플레이어와 충돌해도 몬스터 피격 애니메이션 실행
    //        Destroy(gameObject); // 몬스터 제거
    //    }
    //}

    void Die()
    {
        anim.SetTrigger("Die"); // 죽는 애니메이션 실행
        Destroy(gameObject, 0.5f); // 0.5초 후 몬스터 제거
    }
}
