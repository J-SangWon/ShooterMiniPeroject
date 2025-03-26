using UnityEngine;

public class Monster : MonoBehaviour
{
    public float speed = 3f;  // 몬스터 이동 속도
    public int health = 5;    // 몬스터 체력 (초기값 5)

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;  // 왼쪽으로 이동

        // 화면 왼쪽 끝을 벗어나면 제거
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }

    //합치기 전이라 주석처리
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Shot"))
    //    {
    //        Shot shot = collision.GetComponent<Shot>();
    //        if (shot != null)
    //        {
    //            health -= shot.AttackDamage;

    //            if (health <= 0) Die();
    //        }
    //        Destroy(collision.gameObject);
    //    }
    //    else if (collision.CompareTag("Thunder")) // Thunder에 맞았을 때 체력 10 감소
    //    {
    //        health -= 10;

    //        if (health <= 0) Die();
    //        Destroy(collision.gameObject);
    //    }
    //    else if (collision.CompareTag("Player")) // 플레이어와 충돌
    //    {
    //        Player player = collision.GetComponent<Player>();
    //        if (player != null)
    //        {
    //            player.life--; //플레이어 목숨 1 감소
    //        }
    //        Destroy(gameObject); //몬스터 제거
    //    }
    //}

    void Die()
    {
        Destroy(gameObject);
    }


}

