using UnityEngine;

public class Item : MonoBehaviour
{
    public float ItemVelocity = 100;
    public float RotationSpeed = 200f;
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
