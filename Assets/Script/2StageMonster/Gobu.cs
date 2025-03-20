using System.Collections;
using UnityEngine;

public class Gobu : MonoBehaviour
{
    public float Speed = 3;
    public GameObject ms1;
    public Transform pos1;
    Vector2 vec2 = Vector2.left;

    void Start()
    {
        StartCoroutine(TripleFire());
    }

    IEnumerator TripleFire()
    {
        while (true)
        {
            for (int i = 0; i < 3; i++)
            {
                Instantiate(ms1, transform.position, Quaternion.identity).GetComponent<FloraBullet>().Move(new Vector2(-1, 0));
                Instantiate(ms1, transform.position, Quaternion.identity).GetComponent<FloraBullet>().Move(new Vector2(-1, 0.1f));
                Instantiate(ms1, transform.position, Quaternion.identity).GetComponent<FloraBullet>().Move(new Vector2(-1, -0.1f));
                WaitForSeconds Wait = new WaitForSeconds(.5f);
                yield return new WaitForSeconds(.1f);
            }
                yield return new WaitForSeconds(5);
        }

    }

    void Update()
    {
        transform.Translate(vec2 * Speed * Time.deltaTime);
    }
}
