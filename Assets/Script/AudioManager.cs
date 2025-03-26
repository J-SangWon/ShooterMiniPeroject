using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip LobbyBGM;
    public AudioClip stage1BGM;
    public AudioClip stage2BGM;

    private AudioSource audioSource;
    public static AudioManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시 파괴 방지
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayLobbyBGM()
    {
        audioSource.clip = LobbyBGM;
        audioSource.Play();
    }
    public void PlayStage1BGM()
    {
        audioSource.clip = stage1BGM;
        audioSource.Play();
    }

    public void PlayStage2BGM()
    {
        audioSource.clip = stage2BGM;
        audioSource.Play();
    }

    public void StopBGM()
    {
        audioSource.Stop();
    }
}