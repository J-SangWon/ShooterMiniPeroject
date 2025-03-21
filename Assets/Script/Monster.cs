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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Player�� �浹 ����
        {
            Debug.Log($"{gameObject.name}��(��) Player�� �浹��!");
            // Player�� �״� ó���� Player ��ũ��Ʈ���� �ϸ� ��.
        }



<<<<<<< Updated upstream
        if (other.CompareTag("Shot"))
        {
            // Shot�� �浹 �� ü�� ����
            health -= 1;
            Destroy(other.gameObject); // �Ѿ��� ����

            Debug.Log($"{gameObject.name}��(��) Shot�� �浹�Ͽ� ü�� ����! ���� ü��: {health}");

            // ü���� 0 ������ �� ���� ����
            if (health <= 0)
            {
                Destroy(gameObject);
                Debug.Log($"{gameObject.name}��(��) ü���� 0 ���Ϸ� �����Ͽ� ������!");
            }
=======
        //if (other.CompareTag("Shot"))
        //{
        //    // Shot�� �浹 �� ü�� ����
        //    health -= 1;
        //    Destroy(other.gameObject); // �Ѿ��� ����

        //    Debug.Log($"{gameObject.name}��(��) Shot�� �浹�Ͽ� ü�� ����! ���� ü��: {health}");

        //    // ü���� 0 ������ �� ���� ����
        //    if (health <= 0)
        //    {
        //        Destroy(gameObject);
        //        Debug.Log($"{gameObject.name}��(��) ü���� 0 ���Ϸ� �����Ͽ� ������!");
        //    }
>>>>>>> Stashed changes
        }
    }

