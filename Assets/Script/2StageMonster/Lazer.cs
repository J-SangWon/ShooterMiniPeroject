using UnityEngine;

public class Lazer : MonoBehaviour
{

    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
        }
    }
      
}
