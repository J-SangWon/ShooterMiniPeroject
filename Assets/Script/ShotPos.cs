using UnityEngine;
using System.Collections;
using static Shot;

public class ShotPos : MonoBehaviour
{
    public GameObject[] ShotType = new GameObject[2];
    public GameObject ThunderPrefab;

    private float verticalOffset = 0.5f; //탄 위아래 간격

    private float SpawnInterval = 0.1f; // 생성 간격
    private float DistanceInterval = 2f; // 거리 간격
    private float LifeTime = 1.0f; // 수명

    private float screenWidth;

    void Start()
    {
        // 화면 너비 계산
        screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
    }

    public void ShotFire(PlayerType playerType)
    {

        int ItemCount = playerType == PlayerType.Player1 ? Player1.instance.ItemCount : Player2.instance.ItemCount;
        PlayerSound.instance.ShotSound();
        if (ItemCount == 0)
        {
            GameObject shot = Instantiate(ShotType[0], transform.position, Quaternion.identity);
            shot.GetComponent<Shot>().playerType = playerType; // 플레이어 타입 할당
        }
        else if (ItemCount == 1)
        {
            GameObject shot1 = Instantiate(ShotType[0], transform.position, Quaternion.identity);
            shot1.GetComponent<Shot>().playerType = playerType; // 플레이어 타입 할당
            GameObject shot2 = Instantiate(ShotType[0], transform.position + Vector3.up * verticalOffset, Quaternion.identity);
            shot2.GetComponent<Shot>().playerType = playerType; // 플레이어 타입 할당
        }
        else if (ItemCount >= 2)
        {
            GameObject shot1 = Instantiate(ShotType[0], transform.position, Quaternion.identity);
            shot1.GetComponent<Shot>().playerType = playerType; // 플레이어 타입 할당
            GameObject shot2 = Instantiate(ShotType[0], transform.position + Vector3.up * verticalOffset, Quaternion.identity);
            shot2.GetComponent<Shot>().playerType = playerType; // 플레이어 타입 할당
            GameObject shot3 = Instantiate(ShotType[0], transform.position + Vector3.down * verticalOffset, Quaternion.identity);
            shot3.GetComponent<Shot>().playerType = playerType; // 플레이어 타입 할당
        }


    }
    public void ShotIce(PlayerType playerType)
    {
        int ItemCount = playerType == PlayerType.Player1 ? Player1.instance.ItemCount : Player2.instance.ItemCount;
        PlayerSound.instance.ShotSound();
        if (ItemCount == 0)
            Instantiate(ShotType[1], transform.position, Quaternion.identity);
        else if (ItemCount == 1)
        {
            Instantiate(ShotType[1], transform.position, Quaternion.identity);
            Instantiate(ShotType[1], transform.position + Vector3.up * verticalOffset, Quaternion.identity);
        }
        else if (ItemCount >= 2)
        {
            Instantiate(ShotType[1], transform.position, Quaternion.identity);
            Instantiate(ShotType[1], transform.position + Vector3.up * verticalOffset, Quaternion.identity);
            Instantiate(ShotType[1], transform.position + Vector3.down * verticalOffset, Quaternion.identity);
        }
    }

    //특수공격
    public void ShotThunder()
    {
        StartCoroutine(SpawnThunder());
    }
    IEnumerator SpawnThunder()
    {
        float startX = transform.position.x;
        float currentX = startX;
        PlayerSound.instance.ThunderAttackSound();

        while (currentX < screenWidth)
        {
            Vector3 spawnPosition = new Vector3(currentX, transform.position.y, 0);
            GameObject thunder = Instantiate(ThunderPrefab, spawnPosition, Quaternion.identity);
            Destroy(thunder, LifeTime);

            currentX += DistanceInterval;
            yield return new WaitForSeconds(SpawnInterval);
        }
    }
    void Update()
    {
        
    }
}
