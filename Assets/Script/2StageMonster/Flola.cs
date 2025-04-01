using System.Collections;
using UnityEngine;

public class Flola : MonoBehaviour
{
    public int HP = 6;
    public float Speed = 2;
    public Transform Pos1;
    public GameObject Ms1;
    public float attackRate = 3;
    public ItemDropManager itemDropManager;
    void Start()
    {
        StartCoroutine(CircleFire());

        if (itemDropManager == null)
        {
            itemDropManager = FindAnyObjectByType<ItemDropManager>();
        }
    }

    IEnumerator CircleFire()
    {
        int count = 20;
        float intervalAngle = 360 / count;
        float weightAngle = 0f;

        
        while (true)
        {
            for (int i = 0; i < count; i++)
            {
                GameObject clone = Instantiate(Ms1, transform.position, Quaternion.identity);

                float angle = weightAngle + intervalAngle * i;
                float x = Mathf.Cos(angle * Mathf.Deg2Rad);
                float y = Mathf.Sin(angle * Mathf.Deg2Rad);

                clone.GetComponent<FloraBullet>().Move(new Vector2(x, y));
            }
        weightAngle += 20;

        yield return new WaitForSeconds(attackRate);
        }
    }

    void GetDamage(int Damage)
    {
        HP -= Damage;
        if (HP <= 0)
        {
            Destroy(gameObject);
            if (itemDropManager != null)
            {
                itemDropManager.DropItem(transform.position);
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shot"))
        {
            Shot shot = collision.GetComponent<Shot>();
            if (shot != null)
            {
                GetDamage(shot.AttackDamage);
            }
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Thunder"))
        {
            Thunder thunder = collision.GetComponent<Thunder>();
            GetDamage(thunder.ThunderDamage);
            //Destroy(collision.gameObject);
        }


    }

    void Update()
    {
        transform.Translate(Vector2.left * Speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }



}
