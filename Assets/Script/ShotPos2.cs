using UnityEngine;
using System.Collections;

public class ShotPos2 : MonoBehaviour
{
    public GameObject[] ShotType = new GameObject[2];
    public GameObject ThunderPrefab;

    public float verticalOffset = 0.5f;

    public float SpawnInterval = 0.1f; // 생성 간격
    public float DistanceInterval = 2f; // 거리 간격
    public float LifeTime = 2f; // 수명

    private float screenWidth;

    void Start()
    {
        // 화면 너비 계산
        screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
    }

    public void ShotFire()
    {
        int ItemCount = Player2.instance.ItemCount;
        if (ItemCount == 0) 
            Instantiate(ShotType[0], transform.position, Quaternion.identity);
        else if (ItemCount == 1)
        {
            Instantiate(ShotType[0], transform.position, Quaternion.identity);
            Instantiate(ShotType[0], transform.position + Vector3.up * verticalOffset, Quaternion.identity);
        }
        else if (ItemCount == 2)
        {
            Instantiate(ShotType[0], transform.position, Quaternion.identity);
            Instantiate(ShotType[0], transform.position + Vector3.up * verticalOffset, Quaternion.identity);
            Instantiate(ShotType[0], transform.position + Vector3.down * verticalOffset, Quaternion.identity);
        }

    }
    public void ShotIce()
    {
        int ItemCount = Player2.instance.ItemCount;
        if (ItemCount == 0)
            Instantiate(ShotType[1], transform.position, Quaternion.identity);
        else if (ItemCount == 1)
        {
            Instantiate(ShotType[1], transform.position, Quaternion.identity);
            Instantiate(ShotType[1], transform.position + Vector3.up * verticalOffset, Quaternion.identity);
        }
        else if (ItemCount == 2)
        {
            Instantiate(ShotType[1], transform.position, Quaternion.identity);
            Instantiate(ShotType[1], transform.position + Vector3.up * verticalOffset, Quaternion.identity);
            Instantiate(ShotType[1], transform.position + Vector3.down * verticalOffset, Quaternion.identity);
        }
    }

    public void ShotThunder()
    {
        StartCoroutine(SpawnThunder());
    }
    IEnumerator SpawnThunder()
    {
        float startX = transform.position.x;
        float currentX = startX;

        while (currentX < screenWidth)
        {
            Vector3 spawnPosition = new Vector3(currentX, transform.position.y, transform.position.z);
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
