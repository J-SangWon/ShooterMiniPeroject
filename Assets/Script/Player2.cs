using Unity.VisualScripting;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    //다른 스크립트에서 사용할 수 있게 싱글톤
    public static Player2 instance = null;

    public ShotPos shotPos;
    public bool isFire = true;
    //이동
    public float MoveSpeed = 5f;
    private Vector2 MinBounds;
    private Vector2 MaxBounds;
    public Transform[] Pos = new Transform[3];
    public Vector3 direction;

    //목숨 카운트
    public int LifeCount = 3;

    //애니메이션 전환
    Animator Ani;
    SpriteRenderer SP;

    //아이템
    public int ItemCount;
    [SerializeField]
    private GameObject GetItemEffect;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        // 화면의 경계 설정
        Camera cam = Camera.main;
        Vector3 bottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 topRight = cam.ViewportToWorldPoint(new Vector3(1, 1, 0));
        MinBounds = new Vector2(bottomLeft.x, bottomLeft.y);
        MaxBounds = new Vector2(topRight.x, topRight.y);

        //애니메이션 컴포넌트 받기
        Ani = GetComponent<Animator>();
        SP = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        //이동
        float moveX = MoveSpeed * Time.deltaTime * Input.GetAxis("Horizontal2");
        float moveY = MoveSpeed * Time.deltaTime * Input.GetAxis("Vertical2");
        //화면 경계 밖으로 나가지 못하게 설정
        Vector3 NewPosition = transform.position + new Vector3 (moveX, moveY, 0);
        NewPosition.x = Mathf.Clamp(NewPosition.x, MinBounds.x, MaxBounds.x);
        NewPosition.y = Mathf.Clamp(NewPosition.y, MinBounds.y, MaxBounds.y);
        transform.position = NewPosition;

        //키 입력받는 거에 대해서 이동 및 공격
        KeyInput();



        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            //아이템 충돌
            GameObject go = Instantiate(GetItemEffect, transform.position, Quaternion.identity);
            ItemCount++;
            Destroy(go, 1);


        }
        if (collision.gameObject.CompareTag("Monster"))
        {
            //몬스터 충돌
            PlayerDead();
        }

    }

    void PlayerDead()
    {
        Ani.SetBool("Dead", true);
        if(LifeCount > 0)
        {
            LifeCount--;
            Invoke("ResetDeadState", 1f);
        }
    }

    public void ResetDeadState()
    {
        Ani.SetBool("Dead", false);
    }

    void KeyInput()
    {
        direction.x = Input.GetAxisRaw("Horizontal2");

        if (direction.x < 0)
        {
            SP.flipX = true;
            Ani.SetBool("Move", true);
        }
        else if (direction.x > 0)
        {
            SP.flipX = false;
            Ani.SetBool("Move", true);
        }
        else if (direction.x == 0)
        {
            Ani.SetBool("Move", false);
        }
        //공격 키와 레이저 키
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            shotPos.ShotThunder();
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            Ani.SetTrigger("Attack");
            GameObject shot = Instantiate(isFire ? shotPos.ShotType[0] : shotPos.ShotType[1], transform.position, Quaternion.identity);
            shot.GetComponent<Shot>().playerType = Shot.PlayerType.Player2; // 플레이어 타입 할당
        }

    }
}
