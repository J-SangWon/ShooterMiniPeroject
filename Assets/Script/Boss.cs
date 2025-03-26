using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform[] firePoints;
    public GameObject bulletPrefab;
    public float fireRate = 2f;
    private float nextFireTime = 0f;
    public float speed = 1f;  // 보스의 이동 속도
    public int health = 50;   // 보스의 체력
    public GameObject deathEffect; // 보스 사망 이펙트 (사망 시 나타날 이펙트)

    //public IteamDropManager itemDropManager; //아이템 드롭 매니저 참조, 합치기 전이라 주석처리

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate;
        }

        void Fire()
        {
            foreach (Transform firePoint in firePoints)
            {
                Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            }
        }

        // 보스는 왼쪽으로 이동
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // 화면 왼쪽 끝을 벗어나면 제거
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }


    // //합치기 전이라 주석처리
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
    //    else if (collision.CompareTag("Player")) //플레이어오 충돌
    //    {
    //        Player player = collision.GetComponent<player>();
    //        if (player != null)
    //        {
    //            player.life--; //플레이어 목숨 1감소
    //        }
    //        
    //    }
    //}

    //합치기 전이라 주석처리
    //void DropItem()
    //{
    //    if (itemDropManager != null)
    //    {
    //        itemDropManager.DropItem(transform.position);
    //    }
    //}

    // 보스 사망 처리
    void Die()
    {
        if (deathEffect != null)
        {
            // 사망 이펙트 생성
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject); // 보스 몬스터 삭제
    }
}
