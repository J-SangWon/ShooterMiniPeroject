using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Lazer2 : MonoBehaviour
{
    Transform LazerPos2;

    void Start()
    {
        LazerPos2 = GameObject.Find("Goru").GetComponent<Goru>().Pos[2];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {

        }
    }

    private void Update()
    {
        transform.position = LazerPos2.position;
    }
}
