using UnityEngine;

public class ShotPos : MonoBehaviour
{
    public GameObject[] ShotType = new GameObject[2];
    
    public float verticalOffset = 0.5f;
    void Start()
    {

    }

    public void ShotFire()
    {
        int ItemCount = Player1.instance.ItemCount;
        if (ItemCount == 0) 
            Instantiate(ShotType[0], transform.position, Quaternion.identity);
        else if (ItemCount == 1)
        {
            Instantiate(ShotType[0], transform.position, Quaternion.identity);
            Instantiate(ShotType[0], transform.position + Vector3.up * verticalOffset, Quaternion.identity);
        }
        else if (ItemCount == 2)
        {
            Instantiate(ShotType[0], transform.position, Quaternion.identity);
            Instantiate(ShotType[0], transform.position + Vector3.up * verticalOffset, Quaternion.identity);
            Instantiate(ShotType[0], transform.position + Vector3.down * verticalOffset, Quaternion.identity);
        }

    }
    public void ShotIce()
    {
        int ItemCount = Player1.instance.ItemCount;
        if (ItemCount == 0)
            Instantiate(ShotType[1], transform.position, Quaternion.identity);
        else if (ItemCount == 1)
        {
            Instantiate(ShotType[1], transform.position, Quaternion.identity);
            Instantiate(ShotType[1], transform.position + Vector3.up * verticalOffset, Quaternion.identity);
        }
        else if (ItemCount == 2)
        {
            Instantiate(ShotType[1], transform.position, Quaternion.identity);
            Instantiate(ShotType[1], transform.position + Vector3.up * verticalOffset, Quaternion.identity);
            Instantiate(ShotType[1], transform.position + Vector3.down * verticalOffset, Quaternion.identity);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {

        }
    }
}
