using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upbullet : MonoBehaviour
{
    public float bulletspeed;
    public float despawntimer;

    // Start is called before the first frame update
    void Start()
    {
        bulletspeed = 5.5f;
        despawntimer = 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 1, 0) * Time.deltaTime * bulletspeed;


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
