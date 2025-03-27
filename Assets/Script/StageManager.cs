using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public static StageManager instance = null;
    public GameObject objectsToPersist1; // 씬 전환 시 유지할 오브젝트 1
    public GameObject objectsToPersist2; // 씬 전환 시 유지할 오브젝트 2
    private static GameObject persistentObject1; // 유지할 오브젝트 1의 인스턴스
    private static GameObject persistentObject2; // 유지할 오브젝트 2의 인스턴스

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시에도 유지
        }
        else
        {
            Destroy(gameObject);
        }

        if (persistentObject1 == null)
        {
            persistentObject1 = objectsToPersist1;
            DontDestroyOnLoad(persistentObject1);
        }
        else
        {
            Destroy(objectsToPersist1);
        }

        if (persistentObject2 == null)
        {
            persistentObject2 = objectsToPersist2;
            DontDestroyOnLoad(persistentObject2);
        }
        else
        {
            Destroy(objectsToPersist2);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 초기 화면 씬 이름 설정
        string initialSceneName = "NewMini";

        // 초기 화면 씬으로 돌아왔을 때 중복 생성 방지
        if (scene.name == initialSceneName)
        {
            if (persistentObject1 != null && persistentObject1.transform.parent != null)
            {
                Destroy(persistentObject1);
                persistentObject1 = null;
            }

            if (persistentObject2 != null && persistentObject2.transform.parent != null)
            {
                Destroy(persistentObject2);
                persistentObject2 = null;
            }
        }
    }

    public void LoadStage1()
    {
        SceneManager.LoadScene("NewMini");
    }

    public void LoadStage2()
    {
        SceneManager.LoadScene("Stage2");
    }
}