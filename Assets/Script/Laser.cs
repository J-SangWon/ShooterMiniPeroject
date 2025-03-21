using System.Threading;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Player1 player;
    public int LaserDamage = 10;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
           

            
        }
    }
}
