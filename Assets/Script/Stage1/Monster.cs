using Unity.VisualScripting;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float speed = 3f;
    public int health = 5;
    private Animator anim;  // 애니메이터 추가
    public ItemDropManager itemDropManager;
    void Start()
    {
        anim = GetComponent<Animator>();  // 애니메이터 가져오기

        if (itemDropManager == null)
        {
            itemDropManager = FindAnyObjectByType<ItemDropManager>();
        }
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shot"))
        {
            Shot shot = collision.GetComponent<Shot>();
            if (shot != null)
            {
                health -= shot.AttackDamage;
                anim.SetTrigger("Hit");  // 맞았을 때 애니메이션 재생

                if (health <= 0) Die();
            }
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Thunder"))
        {
            Thunder thunder = collision.GetComponent<Thunder>();
            health -= thunder.ThunderDamage;
            anim.SetTrigger("Hit");

            if (health <= 0) Die();
            //Destroy(collision.gameObject);
        }
        

        void Die()
        {
            anim.SetTrigger("Die"); // 죽는 애니메이션 실행
            Destroy(gameObject, 0.1f); // 0.5초 후 몬스터 제거
            if (itemDropManager != null)
            {
                itemDropManager.DropItem(transform.position);
            }
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
        // 몬스터가 파괴될 때 아이템 드롭
        
    }


    
}