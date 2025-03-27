using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] monsterPrefabs; // Monster1, Monster2를 담을 배열
    public GameObject bossPrefab;       // Boss 몬스터
    public float spawnInterval = 2f;    // 몬스터 생성 간격
    public float spawnX = 8.5f;         // 몬스터가 생성될 X 위치 (오른쪽 끝)
    public float minY = -4f;            // 최소 Y 값
    public float maxY = 4f;             // 최대 Y 값
    public float bossSpawnTime = 20f;   // 보스 몬스터 등장 시간 (초)
    private bool isBossSpawned = false; // 보스가 등장했는지 확인하는 변수

    void Start()
    {
        if (monsterPrefabs == null || monsterPrefabs.Length == 0)
        {
            return;
        }

        // 몬스터 생성 루틴 시작
        StartCoroutine(SpawnMonsterRoutine());

        // 20초 뒤에 보스 생성
        Invoke("SpawnBoss", bossSpawnTime);
    }

    IEnumerator SpawnMonsterRoutine()
    {
        while (!isBossSpawned) // 보스가 등장하기 전까지만 몬스터 생성
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnMonster();
        }
    }

    void SpawnMonster()
    {
        if (monsterPrefabs == null || monsterPrefabs.Length == 0 || isBossSpawned)
        {
            return;
        }

        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(spawnX, randomY, 0);

        // Monster1과 Monster2 중 하나를 랜덤 선택
        GameObject selectedMonster = monsterPrefabs[Random.Range(0, monsterPrefabs.Length)];
        Instantiate(selectedMonster, spawnPosition, Quaternion.identity);
    }

    void SpawnBoss()
    {
        if (bossPrefab != null)
        {
            // 보스 몬스터 생성 위치 (오른쪽 끝 가운데)
            Vector3 bossSpawnPosition = new Vector3(7.7f, 0f, 0f);
            Instantiate(bossPrefab, bossSpawnPosition, Quaternion.identity);

            // 보스가 생성되었음을 표시하고 몬스터 생성 중단
            isBossSpawned = true;
        }
    }
}
