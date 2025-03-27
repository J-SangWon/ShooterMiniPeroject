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

    //public IteamDropManager itemDropManager; //������ ��� �Ŵ��� ����, ��ġ�� ���̶� �ּ�ó��

    private float minY = -3f; // ���� �̵� �ּ� y ��ǥ
    private float maxY = 3f; // ���� �̵� �ִ� y ��ǥ
    private int direction = 1; // �̵� ���� (1: ��, -1: �Ʒ�)

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate;
        }

        // ������ y�����θ� �̵�
        transform.Translate(Vector2.up * speed * direction * Time.deltaTime);

        // ȭ�� ���Ʒ� ���� ������ ���� ����
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

    //��ġ�� ���̶� �ּ�ó��
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
    //    else if (collision.CompareTag("Thunder")) // Thunder�� �¾��� �� ü�� 10 ����
    //    {
    //        health -= 10;

    //        if (health <= 0) Die();
    //        Destroy(collision.gameObject);
    //    }
    //    else if (collision.CompareTag("Player")) // �÷��̾�� �浹
    //    {
    //        Player player = collision.GetComponent<Player>();
    //        if (player != null)
    //        {
    //            player.life--; // �÷��̾� ��� 1 ����
    //        }
    //    }
    //}

    
    /*
    void DropItem()
    {
        if (itemDropManager != null)
        {
            itemDropManager.DropItem(transform.position);
        }
    }
    */

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
