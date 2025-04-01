using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform[] firePoints;
    public GameObject bulletPrefab;
    public float fireRate = 2f;
    private float nextFireTime = 0f;
    public float speed = 1f;      // 보스의 이동 속도
    public int health = 100;      // 보스의 체력

    private float minY = -3f;     // 보스 이동 최소 y 좌표
    private float maxY = 3f;      // 보스 이동 최대 y 좌표
    private int direction = 1;    // 이동 방향 (1: 위, -1: 아래)
    public GameObject evolutionItem;

    public void EvolutionDrop()
    {
        Instantiate(evolutionItem, transform.position, Quaternion.identity);
    }
    void Start()
    {
        UIManager.instance.SetBoss(this);
    }
    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate;
        }

        // y축으로 이동
        transform.Translate(Vector2.up * speed * direction * Time.deltaTime);

        // 화면 상하 경계에서 방향 전환
        if (transform.position.y >= maxY || transform.position.y <= minY)
        {
            direction *= -1;
        }
    }

    void Fire()
    {
        foreach (Transform firePoint in firePoints)
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shot"))
        {
            Shot shot = collision.GetComponent<Shot>();
            health -= shot.AttackDamage;
            UIManager.instance.DamageBoss(shot.AttackDamage);
            if (shot != null)
            {
                if (health <= 0)
                {
                    Die();
                }
            }
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Thunder")) // Thunder 충돌 시
        {
            Thunder thunder = collision.GetComponent<Thunder>();
            health -= thunder.ThunderDamage;
            UIManager.instance.DamageBoss(thunder.ThunderDamage);
            if (health <= 0)
            {
                Die();
            }
            //Destroy(collision.gameObject);
        }
    }

    private void Die()
    {
        // 사망 처리 코드
        Destroy(gameObject);
        EvolutionDrop();

    }

    IEnumerator GotoStage2()
    {
        yield return new WaitForSeconds(1f);
    }

    // 체력 값을 반환하는 메서드 추가
    public float GetHealth()
    {
        return health;
    }
}
