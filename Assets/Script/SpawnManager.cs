using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] monsterPrefabs; // Monster1, Monster2를 담을 배열
    public GameObject bossPrefab;       // Boss 몬스터
    public float spawnInterval = 2f;    // 몬스터 생성 간격
    public float spawnX = 10f;          // 몬스터가 생성될 X 위치 (오른쪽 끝)
    public float minY = -4f;            // 최소 Y 값
    public float maxY = 4f;             // 최대 Y 값
    public float bossSpawnTime = 20f;   // 보스 몬스터 등장 시간 (초)

    void Start()
    {
        if (monsterPrefabs == null || monsterPrefabs.Length == 0)
        {
            Debug.LogError("SpawnManager: monsterPrefabs 배열이 비어 있습니다. Inspector에서 Monster1과 Monster2를 추가하세요!");
            return;
        }

        // 몬스터 생성 루틴 시작
        StartCoroutine(SpawnMonsterRoutine());

        // 20초 뒤에 보스 생성
        Invoke("SpawnBoss", bossSpawnTime);
    }

    IEnumerator SpawnMonsterRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnMonster();
        }
    }

    void SpawnMonster()
    {
        if (monsterPrefabs == null || monsterPrefabs.Length == 0)
        {
            Debug.LogError("SpawnManager: monsterPrefabs 배열이 비어 있어서 몬스터를 생성할 수 없습니다!");
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
            Vector3 bossSpawnPosition = new Vector3(spawnX, 0, 0);
            Instantiate(bossPrefab, bossSpawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("SpawnManager: bossPrefab이 할당되지 않았습니다. Inspector에서 Boss 프리팹을 할당하세요!");
        }
    }
}
