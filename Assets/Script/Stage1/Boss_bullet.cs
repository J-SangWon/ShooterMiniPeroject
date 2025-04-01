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

    private void Die()
    {
        Destroy(gameObject);
    }


    // //��ġ�� ���̶� �ּ�ó��

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shot"))
        {
            Shot shot = collision.GetComponent<Shot>();
            if (shot != null)
            {
                health -= shot.AttackDamage;

                if (health <= 0)
                {
                    Die();  // �Ǵ� Destroy(gameObject);
                }
            }
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Thunder"))
        {
            health -= 10;

            if (health <= 0)
            {
                Die();  // �Ǵ� Destroy(gameObject);
            }
            Destroy(collision.gameObject);
        }
    }



    private bool IsOutOfBounds()
    {
        // ī�޶��� ����Ʈ�� �������� ȭ�� ������ �������� Ȯ��
        Vector3 screenPos = Camera.main.WorldToViewportPoint(transform.position);
        return screenPos.x < 0 || screenPos.x > 1 || screenPos.y < 0 || screenPos.y > 1;
    }


}
