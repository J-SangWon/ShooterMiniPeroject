using System.Collections;
using UnityEngine;

public class Goru : MonoBehaviour
{
    public int HP = 10;
    public float Speed = 3;
    public float MaxPlace = 3;
    public float Angle = 0.1f;

    public GameObject Ms1;
    public GameObject Lazer;
    public GameObject LazerWarning;
    public Transform[] Pos;

    public Quaternion ZRot = Quaternion.AngleAxis(-90, Vector3.back);

    private Animator anim = null;


    void Start()
    {
        //StartCoroutine(TripleFire());
        StartCoroutine(LazerFire());
    }

    IEnumerator TripleFire()
    {
        while (true)
        {
            for (int i = 0; i < 3; i++)
            {
                Instantiate(Ms1, transform.position, Quaternion.identity).GetComponent<FloraBullet>().Move(new Vector2(-1, 0));
                Instantiate(Ms1, transform.position, Quaternion.identity).GetComponent<FloraBullet>().Move(new Vector2(-1, Angle));
                Instantiate(Ms1, transform.position, Quaternion.identity).GetComponent<FloraBullet>().Move(new Vector2(-1, -Angle));
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(5);
        }
    }

    IEnumerator LazerFire()
    {
        while (true)
        {

            GameObject warning = Instantiate(LazerWarning, Lazer.transform.position, ZRot);
            GameObject warning2 = Instantiate(LazerWarning, Pos[3].position, ZRot);

            yield return new WaitForSeconds(2);
            Destroy(warning);
            Destroy(warning2);
            GameObject lazer = Instantiate(Lazer, Lazer.transform.position, ZRot);
            GameObject lazer2 = Instantiate(Lazer, Pos[3].position, ZRot);
            yield return new WaitForSeconds(5);
            Destroy(lazer);
            Destroy(lazer2);
            yield return new WaitForSeconds(20);
        }
    }

    void Update()
    {
        Lazer.transform.position = Pos[2].position;


        if (transform.position.y > MaxPlace)
        {
            Speed *= -1;
        }
        else if (transform.position.y < -MaxPlace)
        {
            Speed *= -1;
        }
        transform.Translate(Vector2.up * Speed * Time.deltaTime);
    }
}
