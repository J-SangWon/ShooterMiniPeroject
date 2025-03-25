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

    // 총알과 충돌 시 체력 감소
    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Shot")) // 총알과 충돌 감지
    //    {
    //        // 체력 감소
    //        health -= other.GetComponent<Shot>().AttackDamage;

    //        // 체력이 0 이하이면 보스 사망 처리
    //        if (health <= 0)
    //        {
    //            Die();
    //        }

    //        // 총알 삭제
    //        Destroy(other.gameObject);
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
