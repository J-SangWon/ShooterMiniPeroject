using UnityEngine;

public class Boss : MonoBehaviour
{
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    public float speed = 2f;  // ������ �̵� �ӵ�
=======
    public float speed = 1f;  // ������ �̵� �ӵ�
>>>>>>> Stashed changes
    public int health = 50;   // ������ ü��
    public GameObject deathEffect; // ���� ��� ����Ʈ (��� �� ��Ÿ�� ����Ʈ)

=======
    public float speed = 1f;  // ������ �̵� �ӵ�
    public int health = 50;   // ������ ü��
    public GameObject deathEffect; // ���� ��� ����Ʈ (��� �� ��Ÿ�� ����Ʈ)

    //[Header("Item Drop Settings")]
    //public GameObject[] itemPrefabs;
    //public float dropChance = 1f;

    private SpawnManager spawnManager;

>>>>>>> Stashed changes
    void Update()
    {
        // ������ �������� �̵�
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // ȭ�� ���� ���� ����� ����
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }

    // �Ѿ˰� �浹 �� ü�� ����
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shot")) // �Ѿ˰� �浹 ����
        {
            // ü�� ����
            health -= other.GetComponent<Shot>().AttackDamage;

            // ü���� 0 �����̸� ���� ��� ó��
            if (health <= 0)
            {
                Die();
            }

            // �Ѿ� ����
            Destroy(other.gameObject);
        }
    }
=======
=======
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes

    // ���� ��� ó��
    void Die()
    {
        if (deathEffect != null)
        {
            // ��� ����Ʈ ����
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }

<<<<<<< Updated upstream
        Destroy(gameObject); // ���� ���� ����
    }
=======
        if (spawnManager != null)
        {
            spawnManager.BossDefeated();
        }

        Destroy(gameObject); // ���� ���� ����
    }

    //void DropItem()
    //{
    //    if(itemPrefabs.Length > 0 && Random.value <= dropChance)
    //    {
    //        int randomIndex = Random.Range(0, itemPrefabs.Length);
    //        Vector3 dropPosition = transform.position;
    //        Instantiate(itemPrefabs[randomIndex], dropPosition, Quaternion.identity);
    //    }
    //}

    public void SetSpawnManager(SpawnManager manager)
    {
        spawnManager = manager;
    }
>>>>>>> Stashed changes
}
