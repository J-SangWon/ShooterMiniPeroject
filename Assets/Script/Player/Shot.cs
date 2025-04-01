using UnityEngine;
using static ShotPos;

public class Shot : MonoBehaviour
{
    //탄의 종류 0:불 1:얼음
    public int ShotType;
    public GameObject[] HitEffect;
    public float Speed = 7f;
    public int AttackDamage;
    GameObject go;

    public enum PlayerType { Player1, Player2 }
    public PlayerType playerType; // 플레이어 타입 변수

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.right * Speed * Time.deltaTime);
    }
    //공격 타격
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            //몬스터 타격
            GameObject effectPrefab = (playerType == PlayerType.Player1) ?
                (Player1.instance.isFire ? HitEffect[0] : HitEffect[1]) :
                (Player2.instance.isFire ? HitEffect[0] : HitEffect[1]);
            AttackDamage = (playerType == PlayerType.Player1) ?
                (Player1.instance.isFire ? 1 : 2) :
                (Player2.instance.isFire ? 1 : 2);
            GameObject effectInstance = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effectInstance, 0.5f);
            Destroy(gameObject);
            PlayerSound.instance.HitShot();
        }
        if (collision.CompareTag("Boss"))
        {
            //몬스터 타격
            GameObject effectPrefab = (playerType == PlayerType.Player1) ?
                (Player1.instance.isFire ? HitEffect[0] : HitEffect[1]) :
                (Player2.instance.isFire ? HitEffect[0] : HitEffect[1]);
            AttackDamage = (playerType == PlayerType.Player1) ?
                (Player1.instance.isFire ? 1 : 2) :
                (Player2.instance.isFire ? 1 : 2);
            GameObject effectInstance = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effectInstance, 0.5f);
            Destroy(gameObject);
            PlayerSound.instance.HitShot();
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }




}
