using UnityEngine;

public class Shot : MonoBehaviour
{
    //탄의 종류 0:불 1:얼음
    public int ShotType;


    void Start()
    {
        
    }

    void Update()
    {
        
    }
    //공격 타격
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            //몬스터 타격

        }
    }


}
