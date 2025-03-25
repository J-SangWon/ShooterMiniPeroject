using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform[] firePoints;
    public GameObject bulletPrefab;
    public float fireRate = 2f;
    private float nextFireTime = 0f;
    public float speed = 1f;  // ������ �̵� �ӵ�
    public int health = 50;   // ������ ü��
    public GameObject deathEffect; // ���� ��� ����Ʈ (��� �� ��Ÿ�� ����Ʈ)

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

        // ������ �������� �̵�
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // ȭ�� ���� ���� ����� ����
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }

    // �Ѿ˰� �浹 �� ü�� ����
    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Shot")) // �Ѿ˰� �浹 ����
    //    {
    //        // ü�� ����
    //        health -= other.GetComponent<Shot>().AttackDamage;

    //        // ü���� 0 �����̸� ���� ��� ó��
    //        if (health <= 0)
    //        {
    //            Die();
    //        }

    //        // �Ѿ� ����
    //        Destroy(other.gameObject);
    //    }
    //}

    // ���� ��� ó��
    void Die()
    {
        if (deathEffect != null)
        {
            // ��� ����Ʈ ����
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject); // ���� ���� ����
    }
}
