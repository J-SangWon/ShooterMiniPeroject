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
    //보스쪽으로 이동하면 될듯
    //public void EvolutionDrop()
    //{
    //    Instantiate(EvolutionItem, transform.position, Quaternion.identity);
    //}
}
