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
    private bool canSpawnMonsters = false; // 몬스터 생성 가능 여부
    private Coroutine bossSpawnCoroutine; // 보스 생성 코루틴

    void Start()
    {
        if (monsterPrefabs == null || monsterPrefabs.Length == 0)
        {
            return;
        }
    }

    // UIManager에서 호출할 수 있도록 public 메서드 추가
    public void StartMonsterSpawn()
    {
        canSpawnMonsters = true;
        StartCoroutine(SpawnMonsterRoutine());
        bossSpawnCoroutine = StartCoroutine(BossSpawnTimer());
    }

    IEnumerator SpawnMonsterRoutine()
    {
        while (!isBossSpawned && canSpawnMonsters) // 보스가 등장하기 전까지만 몬스터 생성
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnMonster();
        }
    }

    IEnumerator BossSpawnTimer()
    {
        yield return new WaitForSeconds(bossSpawnTime);
        SpawnBoss();
    }

    public void CancelBossSpawn()
    {
        if (bossSpawnCoroutine != null)
        {
            StopCoroutine(bossSpawnCoroutine);
        }
    }

    void SpawnMonster()
    {
        if (monsterPrefabs == null || monsterPrefabs.Length == 0 || isBossSpawned || !canSpawnMonsters)
        {
            return;
        }

        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(spawnX, randomY, 0);

        // Monster1과 Monster2 중 하나를 랜덤 선택
        GameObject selectedMonster = monsterPrefabs[Random.Range(0, monsterPrefabs.Length)];
        Instantiate(selectedMonster, spawnPosition, Quaternion.identity);
    }

    public void StopMonsterSpawn()
    {
        canSpawnMonsters = false;
        StopAllCoroutines();
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
            UIManager.instance.ShowBossText("보스 출현!"); // 보스 출현 텍스트 표시
        }
    }
}
