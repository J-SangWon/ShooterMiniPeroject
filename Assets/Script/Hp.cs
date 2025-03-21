using UnityEngine;

public class Hp : MonoBehaviour
{
    public float ItemVelocity = 100; //이동속도
    public float RotationSpeed = 300f;//회전속도
    
    Rigidbody2D rig = null;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        rig.AddForce(randomDirection * ItemVelocity, ForceMode2D.Force);
        rig.angularVelocity = Random.Range(-RotationSpeed, RotationSpeed);
    }

    void Update()
    {

    }
    
}
