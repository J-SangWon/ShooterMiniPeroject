using UnityEngine;

public class GravityPowerUp : MonoBehaviour
{

    public float UpSpeed = 5f;
    public float RotationSpeed = 350f;
    Rigidbody2D rig;

    public float ReturnSpeed = 2f;
    public float Stop = 0.1f;

    private Vector2 initialPosition; 
    private bool Returning = false; 

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.linearVelocity = new Vector2(0f, UpSpeed);
        rig.angularVelocity = RotationSpeed;
        initialPosition = transform.position; 
    }



    void FixedUpdate()
    {
        if (rig.linearVelocity.y < 0)
        {
            Returning = true;
        }

        if (Returning)
        {
            
            Vector2 returnDirection = (initialPosition - (Vector2)transform.position).normalized;
            rig.AddForce(returnDirection * ReturnSpeed);

           
            if (Vector2.Distance(transform.position, initialPosition) < Stop)
            {
                rig.linearVelocity = Vector2.zero;
                rig.angularVelocity = 0;
                rig.isKinematic = true;
                Returning = false;
            }
        }
    } 
}
