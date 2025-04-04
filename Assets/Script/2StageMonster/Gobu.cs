﻿using System.Collections;
using UnityEngine;

public class Gobu : MonoBehaviour
{
    public int HP = 12;
    public float Speed = 3;
    public GameObject ms1;
    public Transform pos1;
    public float Angle = 0.1f;
    public float Delay = 0.1f;
    public float FireDelay = 5;

    Vector2 vec2 = Vector2.left;

    public ItemDropManager itemDropManager;

    void Start()
    {
        StartCoroutine(TripleFire());

        if (itemDropManager == null)
        {
            itemDropManager = FindAnyObjectByType<ItemDropManager>();
        }
    }

    IEnumerator TripleFire()
    {
        while (true)
        {
            for (int i = 0; i < 3; i++)
            {
                Instantiate(ms1, transform.position, Quaternion.identity).GetComponent<FloraBullet>().Move(new Vector2(-2, 0));
                Instantiate(ms1, transform.position, Quaternion.identity).GetComponent<FloraBullet>().Move(new Vector2(-2, Angle));
                Instantiate(ms1, transform.position, Quaternion.identity).GetComponent<FloraBullet>().Move(new Vector2(-2, -Angle));
                yield return new WaitForSeconds(Delay);
            }
                yield return new WaitForSeconds(FireDelay);
        }

    }

    void Update()
    {
        transform.Translate(vec2 * Speed * Time.deltaTime);
    }

    void GetDamage(int Damage)
    {
        HP -= Damage;
        if (HP <= 0)
        {
            Destroy(gameObject);
            if (itemDropManager != null)
            {
                itemDropManager.DropItem(transform.position);
            }
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shot"))
        {
            Shot shot = collision.GetComponent<Shot>();
            if (shot != null)
            {
                GetDamage(shot.AttackDamage);
            }
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Thunder"))
        {
            Thunder thunder = collision.GetComponent<Thunder>();
            GetDamage(thunder.ThunderDamage);
            //Destroy(collision.gameObject);
        }

 
    }

}
