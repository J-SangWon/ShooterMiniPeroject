using UnityEngine;

public class EvolutionItem : MonoBehaviour
{
    public float ItemVelocity = 2f;
    public float UpwardForce = 5f;
    public float RotationSpeed = 300f;
    Rigidbody2D rig = null;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.linearVelocity = new Vector2(0f, UpwardForce);

        rig.angularVelocity = RotationSpeed;
    }
 
    void Update()
    {

    }
    //���������� �̵��ϸ� �ɵ�
    //public void EvolutionDrop()
    //{
    //    Instantiate(EvolutionItem, transform.position, Quaternion.identity);
    //}
}
