using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static bool isWaitingForStart = true;

    public Image[] lifeIconsP1;
    public Image[] laserIconsP1;
    public Image[] lifeIconsP2;
    public Image[] laserIconsP2;
    public TextMeshProUGUI StageText;
    public TextMeshProUGUI bossText;
    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI stageClearText;
    public TextMeshProUGUI startGameText;
    public BackgroundRepeat backgroundRepeat;
    public GameObject introPanel;

    //플레이어 사망 체크
    private bool isPlayer1Dead = false;
    private bool isPlayer2Dead = false;

    //보스 체력바
    public GameObject bossHealthBar;
    public Image bossHealthFill;

    private float bossCurrentHealth;
    private float bossMaxHealth;
    private bool isGameOver = false;
    private int stage = 1;
    private bool isBossDefeated = false;
    private int finalStage = 2;
    public static UIManager instance;
    private Boss boss;
    private Goru goru;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        InitializeGame();
        AudioManager.Instance.PlayLobbyBGM();
    }

    void Update()
    {
        if (isWaitingForStart)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartGame();
            }
            return;
        }

        if (isGameOver) return;
    }

    void StartGame()
    {
        isWaitingForStart = false;

        if (introPanel != null)
        {
            introPanel.SetActive(false);
        }

        startGameText.gameObject.SetActive(false);
        AudioManager.Instance.StopBGM();
        AudioManager.Instance.PlayStage1BGM();
        InitializeGame();
        StartCoroutine(StartCountdown());
    }

    void InitializeGame()
    {
        stage = 1;
        isBossDefeated = false;

        UpdateUI();
        UpdateLifeUI(1, Player1.instance.LifeCount);
        UpdateLaserUI(1, Player1.instance.ThunderCount);
        UpdateLifeUI(2, Player2.instance.LifeCount);
        UpdateLaserUI(2, Player2.instance.ThunderCount);

        bossText.gameObject.SetActive(false);
        countdownText.gameObject.SetActive(false);
        stageClearText.gameObject.SetActive(false);
    }

    IEnumerator StartCountdown()
    {
        if (isGameOver) yield break;
        countdownText.gameObject.SetActive(true);

        countdownText.text = $"Stage {stage}";
        yield return new WaitForSeconds(2f);

        for (int i = 3; i > 0; i--)
        {
            if (isGameOver) yield break;
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        countdownText.text = "Stage Start!";
        yield return new WaitForSeconds(1f);

        countdownText.gameObject.SetActive(false);

        // **카운트다운이 끝나면 SpawnManager에 신호 보내기**
        if (stage == 1)
        {
            FindAnyObjectByType<SpawnManager>().StartMonsterSpawn();
        }
        else if (stage == 2)
        {
            FindAnyObjectByType<SpawnManager2>().StartMonsterSpawn();
        }

        yield return new WaitForSeconds(2f);
    }

    public void DefeatBoss()
    {
        if (isWaitingForStart || isBossDefeated) return;

        isBossDefeated = true;
        //보스 죽으면 보스 체력바 숨기기
        HideBossHealthBar();
        StartCoroutine(ShowStageClearAfterDelay());
    }

    IEnumerator ShowStageClearAfterDelay()
    {
        yield return new WaitForSeconds(2f);

        ShowStageClear();

        if (stage >= finalStage)
        {
            yield return new WaitForSeconds(2f);

            if (stageClearText != null)
            {
                stageClearText.gameObject.SetActive(false);
            }

            ResetGameState();
        }
        else
        {
            yield return new WaitForSeconds(3f);
            StartCoroutine(NextStage());
        }
    }

    IEnumerator NextStage()
    {
        if (isGameOver) yield break;
        stage++;
        isBossDefeated = false;
        stageClearText.gameObject.SetActive(false);
        UpdateUI();

        backgroundRepeat.ChangeBackground(stage);

        yield return StartCoroutine(StartCountdown());
    }
    //public void CheckGameOverCondition()
    //{
    //    if (Player1.instance.LifeCount <= 0 && Player2.instance.LifeCount <= 0)
    //    {
    //        GameOver();
    //    }
    //}
    public void PlayerDied(int playerNum)
    {
        if (playerNum == 1)
        {
            isPlayer1Dead = true;
        }
        else if (playerNum == 2)
        {
            isPlayer2Dead = true;
        }

        if (isPlayer1Dead && isPlayer2Dead)
        {
            GameOver();
        }
    }

    public void RespawnPlayers()
    {
        // 플레이어 재생성 로직 추가
        Player1.instance.Respawn();
        Player2.instance.Respawn();

        isPlayer1Dead = false;
        isPlayer2Dead = false;
    }
    private void RemoveAllEnemies()
    {
        // 모든 적 제거
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Monster");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }

        // 보스 제거
        GameObject boss = GameObject.FindGameObjectWithTag("Boss");
        if (boss != null)
        {
            Destroy(boss);
        }
    }
    private void RemoveAllBullets()
    {
        // 모든 탄환 제거
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("MonShot");
        foreach (GameObject bullet in bullets)
        {
            Destroy(bullet);
        }
    }

    public void GameOver()
    {
        if (isWaitingForStart || isGameOver) return;

        isGameOver = true;
        Time.timeScale = 0;

        //게임오버 시 보스 체력바 숨기기
        HideBossHealthBar();
        bossText.text = "GAME OVER";
        bossText.gameObject.SetActive(true);

        // 몬스터 생성 중단
        FindAnyObjectByType<SpawnManager>().StopMonsterSpawn();
        FindAnyObjectByType<SpawnManager2>().StopMonsterSpawn();
        FindAnyObjectByType<SpawnManager>().CancelBossSpawn();
        FindAnyObjectByType<SpawnManager2>().CancelGoruSpawn();

        // 모든 적 제거
        RemoveAllEnemies();
        RemoveAllBullets();
        AudioManager.Instance.StopBGM();
        AudioManager.Instance.PlayLobbyBGM();

        // 보스 체력바 숨기기
        HideBossHealthBar();
        ResetBossHealthBar();

        StartCoroutine(RestartAfterGameOver());
    }

    IEnumerator RestartAfterGameOver()
    {
        yield return new WaitForSecondsRealtime(2f);

        if (bossText != null)
        {
            bossText.gameObject.SetActive(false);
        }

        RespawnPlayers();
        ResetGameState();
        // 현재 씬 다시 로드
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateLifeUI(int playerNum, int lifeCount)
    {
        if (isGameOver) return;

        Image[] lifeIcons = (playerNum == 1) ? lifeIconsP1 : lifeIconsP2;

        for (int i = 0; i < lifeIcons.Length; i++)
        {
            lifeIcons[i].enabled = (i < lifeCount);
        }

    }

    public void UpdateLaserUI(int playerNum, int laserCount)
    {
        if (isGameOver) return;

        Image[] laserIcons = (playerNum == 1) ? laserIconsP1 : laserIconsP2;

        for (int i = 0; i < laserIcons.Length; i++)
        {
            laserIcons[i].enabled = (i < laserCount);
        }
    }

    void UpdateUI()
    {
        StageText.text = $"Stage {stage}";
    }

    public void ShowBossText(string message)
    {
        if (isWaitingForStart) return;
        StartCoroutine(ShowBossTextCoroutine(message));
        //체력바 코루틴
        StartCoroutine(ShowBossHealthBarWithDelay());
    }
    public IEnumerator ShowBossTextCoroutine(string message)
    {
        bossText.text = message;
        bossText.gameObject.SetActive(true);
        StartCoroutine(ShowBossHealthBarWithDelay());

        yield return new WaitForSeconds(2f); // 2초 동안 표시 후 숨김

        bossText.gameObject.SetActive(false);
    }
    IEnumerator ShowBossHealthBarWithDelay()
    {
        yield return new WaitForSeconds(1f);
        InitBossHealthBar();
    }
    public void DamageBoss(float damage)
    {
        if (isWaitingForStart || isBossDefeated) return;
        //보스 체력바 데미지에 따라 줄어들게
        bossCurrentHealth = Mathf.Max(0, bossCurrentHealth - damage);
        UpdateBossHealthFill();

        //체력바 다 달면 보스가 죽는 판정
        if (bossCurrentHealth <= 0f)
        {
            DefeatBoss();
        }
    }
    void HideBossText()
    {
        bossText.gameObject.SetActive(false);
    }

    void ResetGameState()
    {
        Time.timeScale = 1;
        isGameOver = false;
        isWaitingForStart = true;

        stage = 1;
        isBossDefeated = false;
        //플레이어 정보 초기화

        UpdateUI();
        UpdateLifeUI(1, Player1.instance.LifeCount);
        UpdateLaserUI(1, Player1.instance.ThunderCount);
        UpdateLifeUI(2, Player2.instance.LifeCount);
        UpdateLaserUI(2, Player2.instance.ThunderCount);
        //체력바 리셋
        ResetBossHealthBar();

        // 몬스터 생성 중단
        FindAnyObjectByType<SpawnManager>().StopMonsterSpawn();
        FindAnyObjectByType<SpawnManager2>().StopMonsterSpawn();
        FindAnyObjectByType<SpawnManager>().CancelBossSpawn();
        FindAnyObjectByType<SpawnManager2>().CancelGoruSpawn();

        // 모든 적 제거
        RemoveAllEnemies();
        RemoveAllBullets();
        AudioManager.Instance.StopBGM();
        AudioManager.Instance.PlayLobbyBGM();

        // 보스 체력바 숨기기 및 리셋
        HideBossHealthBar();
        ResetBossHealthBar();

        backgroundRepeat.ChangeBackground(1);

        bossText.gameObject.SetActive(false);
        countdownText.gameObject.SetActive(false);
        stageClearText.gameObject.SetActive(false);

        if (introPanel != null)
        {
            introPanel.SetActive(true);
        }
    }

    public void ShowStageClear()
    {
        if (isGameOver) return;

        if (stageClearText != null)
        {
            stageClearText.text = "Stage Clear!";
            stageClearText.gameObject.SetActive(true);
        }
    }

    // Boss HealthBar
    public void SetBoss(Boss boss)
    {
        this.boss = boss;
        bossMaxHealth = boss.GetHealth();
        bossCurrentHealth = bossMaxHealth;
        InitBossHealthBar();
    }
    public void SetBoss(Goru goru)
    {
        this.goru = goru;
        bossMaxHealth = goru.HP;
        bossCurrentHealth = bossMaxHealth;
        InitBossHealthBar();
    }

    void InitBossHealthBar()
    {
        bossCurrentHealth = bossMaxHealth;
        UpdateBossHealthFill();
        bossHealthBar.SetActive(true);
    }

    void UpdateBossHealthFill()
    {
        bossHealthFill.fillAmount = bossCurrentHealth / bossMaxHealth;
    }

    void HideBossHealthBar()
    {
        bossHealthBar.SetActive(false);
    }

    void ResetBossHealthBar()
    {
        bossCurrentHealth = bossMaxHealth;
        UpdateBossHealthFill();
        bossHealthBar.SetActive(false);
    }
}
