using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] monsterPrefabs; // Monster1, Monster2�� ���� �迭
    public GameObject bossPrefab;       // Boss ����
    public float spawnInterval = 2f;    // ���� ���� ����
    public float spawnX = 10f;          // ���Ͱ� ������ X ��ġ (������ ��)
    public float minY = -4f;            // �ּ� Y ��
    public float maxY = 4f;             // �ִ� Y ��
    public float bossSpawnTime = 20f;   // ���� ���� ���� �ð� (��)

    void Start()
    {
        if (monsterPrefabs == null || monsterPrefabs.Length == 0)
        {
            Debug.LogError("SpawnManager: monsterPrefabs �迭�� ��� �ֽ��ϴ�. Inspector���� Monster1�� Monster2�� �߰��ϼ���!");
            return;
        }

        // ���� ���� ��ƾ ����
        StartCoroutine(SpawnMonsterRoutine());

        // 20�� �ڿ� ���� ����
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
            Debug.LogError("SpawnManager: monsterPrefabs �迭�� ��� �־ ���͸� ������ �� �����ϴ�!");
            return;
        }

        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(spawnX, randomY, 0);

        // Monster1�� Monster2 �� �ϳ��� ���� ����
        GameObject selectedMonster = monsterPrefabs[Random.Range(0, monsterPrefabs.Length)];
        Instantiate(selectedMonster, spawnPosition, Quaternion.identity);
    }

    void SpawnBoss()
    {
        if (bossPrefab != null)
        {
            // ���� ���� ���� ��ġ (������ �� ���)
            Vector3 bossSpawnPosition = new Vector3(spawnX, 0, 0);
            Instantiate(bossPrefab, bossSpawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("SpawnManager: bossPrefab�� �Ҵ���� �ʾҽ��ϴ�. Inspector���� Boss �������� �Ҵ��ϼ���!");
        }
    }
}
