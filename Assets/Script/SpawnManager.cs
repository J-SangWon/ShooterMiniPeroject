using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] monsterPrefabs; // Monster1, Monster2�� ���� �迭
    public GameObject bossPrefab;       // Boss ����
    public float spawnInterval = 2f;    // ���� ���� ����
    public float spawnX = 8.5f;         // ���Ͱ� ������ X ��ġ (������ ��)
    public float minY = -4f;            // �ּ� Y ��
    public float maxY = 4f;             // �ִ� Y ��
    public float bossSpawnTime = 20f;   // ���� ���� ���� �ð� (��)
    private bool isBossSpawned = false; // ������ �����ߴ��� Ȯ���ϴ� ����

    void Start()
    {
        if (monsterPrefabs == null || monsterPrefabs.Length == 0)
        {
            return;
        }

        // ���� ���� ��ƾ ����
        StartCoroutine(SpawnMonsterRoutine());

        // 20�� �ڿ� ���� ����
        Invoke("SpawnBoss", bossSpawnTime);
    }

    IEnumerator SpawnMonsterRoutine()
    {
        while (!isBossSpawned) // ������ �����ϱ� �������� ���� ����
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

        // Monster1�� Monster2 �� �ϳ��� ���� ����
        GameObject selectedMonster = monsterPrefabs[Random.Range(0, monsterPrefabs.Length)];
        Instantiate(selectedMonster, spawnPosition, Quaternion.identity);
    }

    void SpawnBoss()
    {
        if (bossPrefab != null)
        {
            // ���� ���� ���� ��ġ (������ �� ���)
            Vector3 bossSpawnPosition = new Vector3(7.7f, 0f, 0f);
            Instantiate(bossPrefab, bossSpawnPosition, Quaternion.identity);

            // ������ �����Ǿ����� ǥ���ϰ� ���� ���� �ߴ�
            isBossSpawned = true;
        }
    }
}
