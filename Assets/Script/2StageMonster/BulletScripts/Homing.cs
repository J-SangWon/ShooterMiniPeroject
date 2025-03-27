using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Homing : MonoBehaviour
{
    public GameObject Target;
    public float Speed = 3f;

    Vector2 dir;
    Vector2 dirNo;

    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
        dir = Target.transform.position - transform.position;
        dirNo = dir.normalized;
    }

    void Update()
    {
        transform.Translate(dirNo * Speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
