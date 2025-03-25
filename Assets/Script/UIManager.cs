using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public static bool isWaitingForStart = true;

    public UnityEngine.UI.Image[] lifeIcons;
    public UnityEngine.UI.Image[] laserIcons;
    public UnityEngine.UI.Image[] lifeIconsP2;
    public UnityEngine.UI.Image[] laserIconsP2;
    public TextMeshProUGUI StageText;
    public TextMeshProUGUI bossText;
    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI stageClearText;
    public TextMeshProUGUI startGameText;
    public BackgroundRepeat backgroundRepeat;
    public GameObject introPanel;


    private bool isGameOver = false;
    private int lifeCount = 3;
    private int laserCount = 3;
    private int stage = 1;
    private int maxLife = 3;
    private int lifeCountP2 = 3;
    private int laserCountP2 = 3;
    private int maxLifeP2 = 3;

    private bool isBossDefeated = false;
    private int finalStage = 2;

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
        lifeCount = maxLife;
        laserCount = 3;
        stage = 1;
        isBossDefeated = false;

        lifeCountP2 = maxLifeP2;
        laserCountP2 = 3;

        UpdateUI();
        UpdateLifeUI();
        UpdateLaserUI();
        UpdateLifeUI_P2();
        UpdateLaserUI_P2();

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

    public void ReduceLife()
    {
        if (isWaitingForStart) return;

        if (lifeCount > 0)
        {
            lifeCount--;
            UpdateLifeUI();

            if (lifeCount <= 0)
            {
                GameOver();
            }
        }
    }

    public void ReduceLife_P2()
    {
        if (isWaitingForStart) return;

        if (lifeCountP2 > 0)
        {
            lifeCountP2--;
            UpdateLifeUI_P2();

            if (lifeCountP2 <= 0)
            {
                GameOver();
            }
        }
    }


    public void IncreaseLife()
    {
        if (isWaitingForStart) return;

        if (lifeCount < maxLife)
        {
            lifeCount++;
            UpdateLifeUI();
        }
    }

    public void IncreaseLife_P2()
    {
        if (isWaitingForStart) return;

        if (lifeCountP2 < maxLifeP2)
        {
            lifeCountP2++;
            UpdateLifeUI_P2();
        }
    }


    void UpdateLifeUI()
    {

        if (isGameOver) return;

        for (int i = 0; i < lifeIcons.Length; i++)
        {
            lifeIcons[i].enabled = (i < lifeCount);
        }
    }

    void UpdateLifeUI_P2()
    {

        if (isGameOver) return;

        for (int i = 0; i < lifeIconsP2.Length; i++)
        {
            lifeIconsP2[i].enabled = (i < lifeCountP2);
        }
    }

    public void UseLaser()
    {
        if (isWaitingForStart) return;

        if (laserCount > 0)
        {
            laserCount--;
            UpdateLaserUI();
        }
    }

    public void UseLaser_P2()
    {
        if (isWaitingForStart) return;

        if (laserCountP2 > 0)
        {
            laserCountP2--;
            UpdateLaserUI_P2();
        }
    }


    public void RechargeLaser()
    {
        if (isWaitingForStart) return;

        if (laserCount < 3)
        {
            laserCount++;
            UpdateLaserUI();
        }
    }

    public void RechargeLaser_P2()
    {
        if (isWaitingForStart) return;

        if (laserCountP2 < 3)
        {
            laserCountP2++;
            UpdateLaserUI_P2();
        }
    }


    void UpdateLaserUI()
    {

        if (isGameOver) return;

        for (int i = 0; i < laserIcons.Length; i++)
        {
            laserIcons[i].enabled = (i < laserCount);
        }
    }

    void UpdateLaserUI_P2()
    {

        if (isGameOver) return;

        for (int i = 0; i < laserIconsP2.Length; i++)
        {
            laserIconsP2[i].enabled = (i < laserCountP2);
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

        lifeCount = maxLife;
        laserCount = 3;
        lifeCountP2 = maxLifeP2;
        laserCountP2 = 3;
        stage = 1;
        isBossDefeated = false;

        UpdateUI();
        UpdateLifeUI();
        UpdateLaserUI();
        UpdateLifeUI_P2();
        UpdateLaserUI_P2();

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