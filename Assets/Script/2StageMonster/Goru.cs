using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Goru : MonoBehaviour
{
    public int HP = 400;
    public float Speed = 3;
    public float MaxPlace = 3;
    public float attackRate = 3;

    public GameObject Lazer;
    public GameObject Lazer2;
    public GameObject LazerWarning;
    public GameObject LazerWarning2;
    public GameObject HOMING;
    public GameObject SPAWNBULLET;
    public GameObject MS1;
    public GameObject MS2;
    public Transform[] Pos;

    public Image HealthGage;


    public Quaternion ZRot = Quaternion.AngleAxis(-90, Vector3.back);
    public Quaternion ZRot2 = Quaternion.AngleAxis(80, Vector3.back);

    void Start()
    {
        Pattern();

    }



    IEnumerator TripleFire()
    {
        while (true)
        {

            for (int j = 0; j < 3; j++)
            {
                float sum = -.5f + .5f *j;
                Instantiate(MS2, transform.position, Quaternion.identity).GetComponent<FloraBullet>().Move(new Vector2(-1, sum));
                yield return new WaitForSeconds(.5f);
            }
        }
    }


    IEnumerator CircleFire()
    {
        int count = 17;
        float intervalAngle = 20;


        while (true)
        {
            for (int j = 0; j < 5; j++)
            {
                float weightAngle = 0f;
                for (int i = 0; i < count; i++)
                {
                    GameObject clone = Instantiate(MS1, Pos[1].position, Quaternion.Euler(0, 0, -235));

                    float angle = weightAngle + intervalAngle * i;
                    float x = Mathf.Cos(angle * Mathf.Deg2Rad);
                    float y = Mathf.Sin(angle * Mathf.Deg2Rad);

                    clone.GetComponent<FloraBullet>().Move(new Vector2(x, y));
                    weightAngle += 5;
                }
                yield return new WaitForSeconds(2f);
            }

            yield return new WaitForSeconds(attackRate);
        }
    }

    IEnumerator CircleFire2()
    {
        int count = 17;
        float intervalAngle = 20;

        while (true)
        {
            for (int j = 0; j > -5; j--)
            {
                float weightAngle = 0f;
                for (int i = 0; i < count; i++)
                {
                    GameObject clone = Instantiate(MS1, Pos[2].position, Quaternion.Euler(0, 0, -135));

                    float angle = weightAngle + intervalAngle * i;
                    float x = Mathf.Cos(angle * Mathf.Deg2Rad);
                    float y = Mathf.Sin(angle * Mathf.Deg2Rad);

                    clone.GetComponent<FloraBullet>().Move(new Vector2(x, y));
                    weightAngle += 5;
                }
                yield return new WaitForSeconds(2f);
            }

            yield return new WaitForSeconds(attackRate);
        }
    }
    IEnumerator LazerFire()
    {
        while (true)
        {
            
            GameObject go = Instantiate(LazerWarning, Pos[1].position, ZRot);
            GameObject go2 = Instantiate(LazerWarning2, Pos[2].position, ZRot);

            yield return new WaitForSeconds(2);
            Destroy(go);
            Destroy(go2);
            go = Instantiate(Lazer, Pos[1].position, ZRot);
            go2 = Instantiate(Lazer2, Pos[2].position, ZRot);
            yield return new WaitForSeconds(10);
            Destroy(go);
            Destroy(go2);
            yield return new WaitForSeconds(3);
        }
    }
    IEnumerator SpawnBullet()
    {
        while (true)
        {
            Instantiate(SPAWNBULLET, Pos[3].position, Quaternion.identity);
            yield return new WaitForSeconds(8);
        }
    }

    IEnumerator Homing()
    {
        while (true)
        {
            GameObject go = Instantiate(HOMING, Pos[0].position, Quaternion.identity);
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator UPgrade_Homing()
    {
        while (true)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int i = 1; i < 4; i++)
                {
                    GameObject go = Instantiate(HOMING, Pos[i].position, Quaternion.identity);
                }
                yield return new WaitForSeconds(.5f);
            }
            yield return new WaitForSeconds(2f);
        }

    }

    IEnumerator UpFire()
    {
        int count = 30;
        float intervalAngle = 15;


        while (true)
        {
            for (int j = 0; j < 5; j++)
            {
                float weightAngle = 0f;
                for (int i = 0; i < count; i++)
                {
                    GameObject clone = Instantiate(MS1, Pos[1].position, Quaternion.Euler(0, 0, -235));

                    float angle = weightAngle + intervalAngle * i;
                    float x = Mathf.Cos(angle * Mathf.Deg2Rad);
                    float y = Mathf.Sin(angle * Mathf.Deg2Rad);

                    clone.GetComponent<FloraBullet>().Move(new Vector2(x, y));
                    weightAngle += 1;
                    yield return new WaitForSeconds(.1f);
                }
                yield return new WaitForSeconds(2f);
            }

            yield return new WaitForSeconds(attackRate);
        }
    }

    IEnumerator DownFire()
    {
        int count = 30;
        float intervalAngle = -15;

        while (true)
        {
            for (int j = 0; j < 5; j++)
            {
                float weightAngle = 0f;
                for (int i = 0; i < count; i++)
                {
                    GameObject clone = Instantiate(MS1, Pos[2].position, Quaternion.Euler(0, 0, -150));

                    float angle = weightAngle + intervalAngle * i;
                    float x = Mathf.Cos(angle * Mathf.Deg2Rad);
                    float y = Mathf.Sin(angle * Mathf.Deg2Rad);

                    clone.GetComponent<FloraBullet>().Move(new Vector2(x, y));
                    weightAngle += 1;
                    yield return new WaitForSeconds(0.1f);
                }
                yield return new WaitForSeconds(2f);
            }

            yield return new WaitForSeconds(attackRate);
        }
    }

    IEnumerator CircleFireUp()
    {
        int count = 16;
        float intervalAngle = 12;

        while (true)
        {
                float weightAngle = 0f;
            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < count; i++)
                {
                    GameObject clone = Instantiate(MS2, Pos[1].position, Quaternion.identity);

                    float angle = weightAngle + intervalAngle * i;
                    float x = Mathf.Cos(angle * Mathf.Deg2Rad);
                    float y = Mathf.Sin(angle * Mathf.Deg2Rad);

                    clone.GetComponent<FloraBullet>().Move(new Vector2(x, y));
                    weightAngle += 10;
                }
                yield return new WaitForSeconds(1f);
            }

            yield return new WaitForSeconds(3);
        }
    }

    IEnumerator CircleFireDown()
    {
        int count = 16;
        float intervalAngle = 12;

        while (true)
        {
            float weightAngle = 0f;
            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < count; i++)
                {
                    GameObject clone = Instantiate(MS2, Pos[2].position, Quaternion.identity);

                    float angle = weightAngle + intervalAngle * i;
                    float x = Mathf.Cos(angle * Mathf.Deg2Rad);
                    float y = Mathf.Sin(angle * Mathf.Deg2Rad);

                    clone.GetComponent<FloraBullet>().Move(new Vector2(x, y));
                    weightAngle += 10;
                }
                yield return new WaitForSeconds(1f);
            }

            yield return new WaitForSeconds(3);
        }
    }

    void GetDamage(int Damage)
    {
        HealthGage.fillAmount = (float)HP / 400;
        HP -= Damage;
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        if (transform.position.y > MaxPlace)
        {
            Speed *= -1;
        }
        else if (transform.position.y < -MaxPlace)
        {
            Speed *= -1;
        }
        transform.Translate(Vector2.up * Speed * Time.deltaTime);
    }

    void Pattern()
    {
        if (HP >= 320)
        {
            StartCoroutine(TripleFire());
            StartCoroutine(CircleFire());
            StartCoroutine(CircleFire2());
            
        }
        else if( HP >= 240)
        {
            StopCoroutine(TripleFire());
            StopCoroutine(CircleFire());
            StopCoroutine(CircleFire2());

            StartCoroutine(CircleFireUp());
            StartCoroutine(SpawnBullet());
            StartCoroutine(Homing());
        }
        else if (HP >= 80)
        {
            StopCoroutine(CircleFireUp());
            StopCoroutine(SpawnBullet());
            StopCoroutine(Homing());

            StartCoroutine(UpFire());
            StartCoroutine(DownFire());
            StartCoroutine(UPgrade_Homing());
            StartCoroutine(CircleFireUp());
            StartCoroutine(CircleFireDown());

        }
        else
        {
            StopCoroutine(UpFire());
            StopCoroutine(DownFire());
            StopCoroutine(UPgrade_Homing());
            StopCoroutine(CircleFireUp());
            StopCoroutine(CircleFireDown());

            StartCoroutine(LazerFire());
            StartCoroutine(UPgrade_Homing());
            StartCoroutine(CircleFireUp());
            StartCoroutine(CircleFireDown());
            StartCoroutine(CircleFire());
            StartCoroutine(CircleFire2());
        }

    }

}
