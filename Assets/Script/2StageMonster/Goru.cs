using System.Collections;
using UnityEngine;

public class Goru : MonoBehaviour
{
    public int HP = 10;
    public float Speed = 3;
    public float MaxPlace = 3;

    public GameObject Ms1;
    public Transform Pos1;
    public Transform Top;
    public Transform Bottom;
    public Transform Front;


    void Start()
    {
        StartCoroutine(TripleFire());
        StartCoroutine(Lazer());
    }

    IEnumerator TripleFire()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator Lazer()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
        }
    }

    void Update()
    {
        if(transform.position.y > MaxPlace)
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
