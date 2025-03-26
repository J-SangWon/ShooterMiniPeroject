using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 3f; // �Ѿ� �ӵ�
    public int health = 3; // �Ѿ� ü��

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (IsOutOfBounds())
        {
            Destroy(gameObject);
        }

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    // //��ġ�� ���̶� �ּ�ó��
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
    //    else if (collision.CompareTag("Player")) //�÷��̾�� �浹
    //    {
    //        Player player = collision.GetComponent<player>();
    //        if (player != null)
    //        {
    //            player.life--; //�÷��̾� ��� 1����
    //        }
    //        Destroy(gameObject);
    //    }
    //}

    private bool IsOutOfBounds()
    {
        // ī�޶��� ����Ʈ�� �������� ȭ�� ������ �������� Ȯ��
        Vector3 screenPos = Camera.main.WorldToViewportPoint(transform.position);
        return screenPos.x < 0 || screenPos.x > 1 || screenPos.y < 0 || screenPos.y > 1;
    }


}
