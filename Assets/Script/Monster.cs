using UnityEngine;

public class Monster : MonoBehaviour
{
    public float speed = 3f;  // ���� �̵� �ӵ�
    public ItemDropManager itemDropManager;

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
    }
    private void Destroy()
    {
        if (itemDropManager != null)
        {
            itemDropManager.DropItem(transform.position);
        }
    }
}
