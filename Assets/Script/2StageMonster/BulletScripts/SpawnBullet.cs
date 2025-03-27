using System.Collections;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    public float Speed = 1f;
    public Vector2 vec2 = Vector2.left;
    public GameObject bullet;
    

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
            int count = 20;
            float intervalAngle = 360 / count;
            float weightAngle = 0f;


            while (true)
            {
                for (int i = 0; i < count; i++)
                {
                    GameObject clone = Instantiate(bullet, transform.position, Quaternion.identity);

                    float angle = weightAngle + intervalAngle * i;
                    float x = Mathf.Cos(angle * Mathf.Deg2Rad);
                    float y = Mathf.Sin(angle * Mathf.Deg2Rad);

                    clone.GetComponent<FloraBullet>().Move(new Vector2(x, y));
                }
                    weightAngle += 10;

                yield return new WaitForSeconds(3);
            }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.Translate(vec2 * Speed * Time.deltaTime);
    }
}
