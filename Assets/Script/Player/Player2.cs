﻿using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static Shot;

public class Player2 : MonoBehaviour
{
    //다른 스크립트에서 사용할 수 있게 싱글톤
    public static Player2 instance = null;

    public ShotPos shotPos;
    public Shot.PlayerType playerType = Shot.PlayerType.Player2;
    public bool isFire = true;
    //이동
    public float MoveSpeed = 5f;
    private Vector2 MinBounds;
    private Vector2 MaxBounds;
    public Transform[] Pos = new Transform[3];
    public Vector3 direction;

    //대쉬
    public float DashDistance = 5f;
    public float DashDuration = 0.1f;
    private bool isDashing = false;

  

    //무적
    public bool isInvincible = false;

    //애니메이션 전환
    Animator Ani;
    SpriteRenderer SP;

    //아이템
    //목숨 카운트
    [SerializeField]
    private GameObject GetItemEffect;
    public int ThunderCount = 3;
    public int ItemCount = 0; //파워업 카운트 세기
    public int LifeCount = 3;
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
    public void Respawn()
    {
        // 플레이어 재생성 로직 추가
        LifeCount = 3;
        isFire = true;
        ItemCount = 0;
        ThunderCount = 3;
        UIManager.instance.UpdateLifeUI(2, LifeCount);
        transform.position = new Vector3(-7, 0, 0); // 초기 위치로 이동
        isInvincible = true;
        Ani.SetBool("Dead", false);
        StartCoroutine(Blink(3f)); // 무적 시간 동안 깜빡임
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
            //아이템 충돌
            GameObject go = Instantiate(GetItemEffect, transform.position, Quaternion.identity);
            Destroy(go, 1);
            string itemName = collision.gameObject.name;
            if (itemName.Contains("Hp"))
            {
                if (LifeCount < 3) //hp가 3넘어가면 3으로 맞춰주기
                {
                    LifeCount += 1;
                    UIManager.instance.UpdateLifeUI(2, LifeCount); // UI 업데이트
                }
            }
            else if (itemName.Contains("PowerUp"))
            {
                if (ItemCount < 3)
                {
                    ItemCount += 1;
                }
            }
            else if (itemName.Contains("Lazer"))
            {
                if (ThunderCount < 3)
                {
                    ThunderCount += 1;
                    UIManager.instance.UpdateLaserUI(2, ThunderCount);
                }
            }
            else if (itemName.Contains("EvolutionItem"))
            {
                isFire = false;
            }
            Destroy(collision.gameObject);


        }
        if (collision.gameObject.CompareTag("Monster") && !isInvincible)
        {
            //몬스터 충돌
            PlayerDead();
            StartInvincible(5f);
        }
        if (collision.gameObject.CompareTag("MonShot") && !isInvincible)
        {
            //몬스터 충돌
            PlayerDead();
            //무적판정 넣기
            StartInvincible(5f);

        }
        if (collision.gameObject.CompareTag("Boss") && !isInvincible)
        {
            //몬스터 충돌
            PlayerDead();
            //무적판정 넣기
            StartInvincible(5f);

        }

    }

    void PlayerDead()
    {
        if (LifeCount > 0)
        {
            Ani.SetBool("Dead", true);
            PlayerSound.instance.PlayerDeadSound();
            LifeCount--;
            UIManager.instance.UpdateLifeUI(2, LifeCount);
            if (LifeCount > 0)
            {
                Invoke("ResetDeadState", 1f);
            }
            else
            {
                //UIManager.instance.CheckGameOverCondition();
                UIManager.instance.PlayerDied(2);
            }

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
            if(ThunderCount > 0)
            {
                shotPos.ShotThunder();
                ThunderCount--;
                UIManager.instance.UpdateLaserUI(2, ThunderCount);
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            Ani.SetTrigger("Attack");
            if (isFire)
            {
                shotPos.ShotFire(playerType); // ShotPos를 통해 Shot 생성
            }
            else
            {
                shotPos.ShotIce(playerType); // ShotPos를 통해 Shot 생성
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad3) && !isDashing)
        {
            Dash();
        }

    }

    void Dash()
    {
        if (!isDashing)
        {
            isDashing = true;
            Vector2 DashDirection = direction.normalized; //대쉬 방향
            Vector2 TargetPosition = (Vector2)transform.position + DashDirection * DashDistance;
            StartCoroutine(DashCoroutine(TargetPosition));
            StartInvincible(1f);
        }
    }
    IEnumerator DashCoroutine(Vector2 targetPosition)
    {
        float timer = 0f;
        Vector2 startPosition = transform.position;
        while (timer < DashDuration)
        {
            timer += Time.deltaTime;
            float t = timer / DashDuration;
            transform.position = Vector2.Lerp(startPosition, targetPosition, t); // Lerp를 사용하여 부드럽게 이동
            yield return null;
        }
        transform.position = targetPosition; // 목표 위치로 이동
        isDashing = false; //다음 대쉬 대기
    }
    //무적
    public void StartInvincible(float duration)
    {
        isInvincible = true;
        StartCoroutine(Blink(duration));
    }
    //무적 끝
    public void EndInvincible()
    {
        isInvincible = false;
        GetComponent<SpriteRenderer>().enabled = true;
    }
    //무적 동안 깜빡임
    IEnumerator Blink(float duration)
    {
        float timer = 0f;
        while (timer < duration)
        {
            GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled; // 보이게/안 보이게 전환
            yield return new WaitForSeconds(0.1f);
            timer += 0.1f;
        }
        EndInvincible();
    }

}
