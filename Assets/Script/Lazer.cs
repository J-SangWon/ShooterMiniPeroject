using UnityEngine;

public class Lazer : MonoBehaviour
{
    public float ItemSpeed = 100;
    public float RotationSpeed = 200f;
 
    Rigidbody2D rig = null;
    void Start()
    {
        //�����Ǽ� ���������� �̵��ϱ�
        rig = GetComponent<Rigidbody2D>();
        Vector2 random = Random.insideUnitCircle.normalized;
        rig.AddForce(random * ItemSpeed, ForceMode2D.Force);
        rig.angularVelocity = Random.Range(-RotationSpeed, RotationSpeed);
    }

    void Update()
    {

    }
}
