using UnityEngine;

public class EvolutionItem : MonoBehaviour
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

            Vector2 returnD = (initialPosition - (Vector2)transform.position).normalized;
            rig.AddForce(returnD * ReturnSpeed);


            if (Vector2.Distance(transform.position, initialPosition) < Stop)
            {
                rig.linearVelocity = Vector2.zero;
                rig.angularVelocity = 0;
                rig.isKinematic = true;
                Returning = false;
            }
        }
    }


    //보스쪽에서 드랍시키기
    //public void EvolutionDrop()
    //{
    //    Instantiate(EvolutionItem, transform.position, Quaternion.identity);
    //}
}
