using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 3f; // 총알 속도
    public int health = 3; // 총알 체력

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


    // //합치기 전이라 주석처리

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
                    Die();  // 또는 Destroy(gameObject);
                }
            }
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Thunder"))
        {
            health -= 10;

            if (health <= 0)
            {
                Die();  // 또는 Destroy(gameObject);
            }
            Destroy(collision.gameObject);
        }
    }



    private bool IsOutOfBounds()
    {
        // 카메라의 뷰포트를 기준으로 화면 밖으로 나갔는지 확인
        Vector3 screenPos = Camera.main.WorldToViewportPoint(transform.position);
        return screenPos.x < 0 || screenPos.x > 1 || screenPos.y < 0 || screenPos.y > 1;
    }


}
