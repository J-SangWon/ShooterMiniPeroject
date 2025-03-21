using UnityEngine;

public class EvolutionItem : MonoBehaviour
{
    public float ItemVelocity = 2f;
    public float UpwardForce = 5f;
    public float RotationSpeed = 300f;
    //public GameObject EvolutionItemEffect; //����Ʈ
    //public int EvolutionCount = 0; //Hp ī��Ʈ
    Rigidbody2D rig = null;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.linearVelocity = new Vector2(0f, UpwardForce);

        rig.angularVelocity = RotationSpeed;
    }

    //�÷��̾������� �ڵ��̵��� �±� �ٲ� ��
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {

    //        if (EvolutionCount >= 1)
    //            EvolutionCount = 1;

    //        else if (EvolutionCount <= 1)
    //        {
    //                                        //����Ʈ �̸�
    //            GameObject go = Instantiate(EvolutionItemEffect, transform.position, Quaternion.identity);
    //            Destroy(go, 1);
    //            EvolutionCount += 1;
    //        }
    //        Destroy(gameObject);
    //    }
    //}



    void Update()
    {
        
    }
    //���������� �̵��ϸ� �ɵ�
    //public void EvolutionDrop()
    //{
    //    Instantiate(EvolutionItem, transform.position, Quaternion.identity);
    //}
}
