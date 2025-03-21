using UnityEngine;

public class Thunder : MonoBehaviour
{
    public Player1 player;
    public int ThunderDamage = 10;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            //몬스터 충돌


        }
    }


}
