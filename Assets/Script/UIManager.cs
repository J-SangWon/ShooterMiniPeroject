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
    public TextMeshProUGUI StageText;
    public TextMeshProUGUI bossText;
    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI stageClearText;
    public TextMeshProUGUI startGameText;
    public BackgroundRepeat backgroundRepeat;
    public GameObject introPanel;



    private int lifeCount = 3;
    private int laserCount = 3;
    private int stage = 1;
    private int maxLife = 3;

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


        HandleGameInput();
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

        UpdateUI();
        UpdateLifeUI();
        UpdateLaserUI();

        bossText.gameObject.SetActive(false);
        countdownText.gameObject.SetActive(false);
        stageClearText.gameObject.SetActive(false);
    }



    IEnumerator StartCountdown()
    {
        countdownText.gameObject.SetActive(true);

        countdownText.text = $"Stage {stage}";
        yield return new WaitForSeconds(2f);

        for (int i = 3; i > 0; i--)
        {

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

    void HandleGameInput()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            UseLaser();
        }
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
        stage++;
        isBossDefeated = false;
        stageClearText.gameObject.SetActive(false);
        UpdateUI();

        backgroundRepeat.ChangeBackground(stage);

        yield return StartCoroutine(StartCountdown());
    }

    public void GameOver()
    {
        if (isWaitingForStart) return;

        bossText.text = "GAME OVER";
        bossText.gameObject.SetActive(true);

        StartCoroutine(RestartAfterGameOver());
    }

    IEnumerator RestartAfterGameOver()
    {
        yield return new WaitForSeconds(2f);

        if (bossText != null)
        {
            bossText.gameObject.SetActive(false);
        }

        Time.timeScale = 1;


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

    public void IncreaseLife()
    {
        if (isWaitingForStart) return;

        if (lifeCount < maxLife)
        {
            lifeCount++;
            UpdateLifeUI();
        }
    }

    void UpdateLifeUI()
    {
        for (int i = 0; i < lifeIcons.Length; i++)
        {
            lifeIcons[i].enabled = (i < lifeCount);
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

    public void RechargeLaser()
    {
        if (isWaitingForStart) return;

        if (laserCount < 3)
        {
            laserCount++;
            UpdateLaserUI();
        }
    }

    void UpdateLaserUI()
    {
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
        lifeCount = maxLife;
        laserCount = 3;
        stage = 1;
        isBossDefeated = false;

        UpdateUI();
        UpdateLifeUI();
        UpdateLaserUI();

        
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
        if (stageClearText != null)
        {
            stageClearText.text = "Stage Clear!";
            stageClearText.gameObject.SetActive(true);
        }
    }
}