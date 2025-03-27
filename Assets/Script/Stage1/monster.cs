using UnityEngine;

public class Monster : MonoBehaviour
{
    public float speed = 3f;  // ���� �̵� �ӵ�
    public int health = 5;    // ���� ü�� (�ʱⰪ 5)

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;  // �������� �̵�

        // ȭ�� ���� ���� ����� ����
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
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
    //            player.life--; //�÷��̾� ��� 1 ����
    //        }
    //        Destroy(gameObject); //���� ����
    //    }
    //}

    void Die()
    {
        Destroy(gameObject);
    }


}

