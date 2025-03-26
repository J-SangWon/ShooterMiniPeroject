using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    public static PlayerSound instance;
    public AudioSource Audio;
    public AudioClip HitSound;
    public AudioClip Shot;
    public AudioClip ThunderSound;
    public AudioClip PlayerDead;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        Audio = GetComponent<AudioSource>();
    }

    public void PlayerDeadSound()
    {
        Audio.PlayOneShot(PlayerDead);
    }
    public void ShotSound()
    {
        Audio.PlayOneShot(Shot);
    }
    public void HitShot()
    {
        Audio.PlayOneShot(HitSound);
    }
    public void ThunderAttackSound()
    {
        Audio.PlayOneShot(ThunderSound);
    }

}
