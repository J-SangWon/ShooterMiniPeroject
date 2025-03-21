using UnityEngine;

public class EvolutionItem : MonoBehaviour
{
    public float ItemVelocity = 2f;
    public float UpwardForce = 5f;
    public float RotationSpeed = 300f;
    //public GameObject EvolutionItemEffect; //임펙트
    //public int EvolutionCount = 0; //Hp 카운트
    Rigidbody2D rig = null;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.linearVelocity = new Vector2(0f, UpwardForce);

        rig.angularVelocity = RotationSpeed;
    }

    //플레이어쪽으로 코드이동시 태그 바꿀 것
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Player"))
    //    {

    //        if (EvolutionCount >= 1)
    //            EvolutionCount = 1;

    //        else if (EvolutionCount <= 1)
    //        {
    //                                        //임펙트 이름
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
    //보스쪽으로 이동하면 될듯
    //public void EvolutionDrop()
    //{
    //    Instantiate(EvolutionItem, transform.position, Quaternion.identity);
    //}
}
