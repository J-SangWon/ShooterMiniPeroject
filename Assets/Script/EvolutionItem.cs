using UnityEngine;

public class EvolutionItem : MonoBehaviour
{
    public float ItemVelocity = 2f;
    public float UpwardForce = 5f;
    public float RotationSpeed = 300f;

    public float floatSpeed = 1.5f;
    public float floatAmount = 0.1f;
    Rigidbody2D rig;
    private bool hasLanded = false;
    private Vector3 startPos;


    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.linearVelocity = new Vector2(0f, UpwardForce);

        rig.angularVelocity = RotationSpeed;
    }

    void Update()
    {
        if (hasLanded)
        {
            
            transform.position = startPos + new Vector3(0, Mathf.Sin(Time.time * floatSpeed) * floatAmount, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasLanded)
        {
            hasLanded = true;
            startPos = transform.position; 
            rig.linearVelocity = Vector2.zero;
            rig.angularVelocity = 0f;
            rig.bodyType = RigidbodyType2D.Kinematic;
        }
    }

    //보스쪽에서 드랍시키기
    //public void EvolutionDrop()
    //{
    //    Instantiate(EvolutionItem, transform.position, Quaternion.identity);
    //}
}
