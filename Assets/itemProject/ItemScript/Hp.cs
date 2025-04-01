using UnityEngine;

public class Hp : MonoBehaviour
{
    public float ItemSpeed = 100; //�̵��ӵ�
    public float RotationSpeed = 300f;//ȸ���ӵ�
    
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
