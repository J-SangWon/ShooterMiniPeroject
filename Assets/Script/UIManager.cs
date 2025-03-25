using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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

    private bool isGameOver = false;
    private int stage = 1;
    private bool isBossDefeated = false;
    private int finalStage = 2;

    public static UIManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        InitializeGame();
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

        yield return new WaitForSeconds(5f);
        ShowBossText("보스 출현!");

        yield return new WaitForSeconds(2f);
        HideBossText();
    }

    public void DefeatBoss()
    {
        if (isWaitingForStart || isBossDefeated) return;

        isBossDefeated = true;
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

    public void GameOver()
    {
        if (isWaitingForStart || isGameOver) return;

        isGameOver = true;
        Time.timeScale = 0;

        bossText.text = "GAME OVER";
        bossText.gameObject.SetActive(true);

        StartCoroutine(RestartAfterGameOver());
    }

    IEnumerator RestartAfterGameOver()
    {
        yield return new WaitForSecondsRealtime(2f);

        if (bossText != null)
        {
            bossText.gameObject.SetActive(false);
        }

        ResetGameState();
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

        bossText.text = message;
        bossText.gameObject.SetActive(true);
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

        UpdateUI();
        UpdateLifeUI(1, Player1.instance.LifeCount);
        UpdateLaserUI(1, Player1.instance.ThunderCount);
        UpdateLifeUI(2, Player2.instance.LifeCount);
        UpdateLaserUI(2, Player2.instance.ThunderCount);

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
}