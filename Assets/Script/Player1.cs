using UnityEngine;

public class Player1 : MonoBehaviour
{

    //다른 스크립트에서 사용할 수 있게 싱글톤
    public static Player1 Instance = null;

    //이동
    public float MoveSpeed = 5f;
    private Vector2 MinBounds;
    private Vector2 MaxBounds;
    public Transform[] Pos = new Transform[3];

    //애니메이션 전환
    Animator Ani;

    //아이템
    public int ItemCount;
    [SerializeField]
    private GameObject GetItemEffect;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
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




    }

    void Update()
    {
        //이동
        float moveX = MoveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float moveY = MoveSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        //화면 경계 밖으로 나가지 못하게 설정
        Vector3 NewPosition = transform.position + new Vector3 (moveX, moveY, 0);
        NewPosition.x = Mathf.Clamp(NewPosition.x, MinBounds.x, MaxBounds.x);
        NewPosition.y = Mathf.Clamp(NewPosition.y, MinBounds.y, MaxBounds.y);
        transform.position = NewPosition;

        //공격 키와 레이저 키
        if (Input.GetKeyDown(KeyCode.Space)) 
        { 
            //레이저
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            //공격
        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            //아이템 충돌

            GameObject go = Instantiate(GetItemEffect, transform.position, Quaternion.identity);
            Destroy(go, 1);
        }
        if (collision.gameObject.CompareTag("Moster"))
        {
            //몬스터 충돌
        }

    }


}
