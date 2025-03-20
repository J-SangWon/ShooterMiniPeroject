using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float ItemVelocity = 2f;
    public float UpwardForce = 5f;
    public float RotationSpeed = 300f;
    Rigidbody2D rig;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.linearVelocity = new Vector2(0f, UpwardForce);

        rig.angularVelocity = RotationSpeed;
    }

    void Update()
    {

    }
}
