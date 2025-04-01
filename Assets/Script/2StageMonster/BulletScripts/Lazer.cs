using UnityEngine;

public class Lazer : MonoBehaviour
{
    Transform LazerPos;

    void Start()
    {
        LazerPos = GameObject.Find("Goru").GetComponent<Goru>().Pos[1];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {

        }
    }

    private void Update()
    {
        transform.position = LazerPos.position;
    }
}
