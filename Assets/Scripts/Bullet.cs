using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform bullettarget;
    public float bulletspeed;
    public float despawntimer;
    public Rigidbody bulletrb;

    // Start is called before the first frame update
    void Start()
    {
        bulletspeed = 5.5;
        bullettarget = FindObjectOfType<enemyscript>().transform;
        despawntimer = 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (bullettarget.position - transform.position).normalized * bulletspeed * Time.deltaTime;


        if (despawntimer <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            despawntimer -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        enemyscript e = collision.gameObject.GetComponent<enemyscript>();
        if (e != null)
        {
            e.TakeDamage(1);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
