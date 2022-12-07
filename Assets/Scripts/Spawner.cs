using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;
    public bool enable;
    public float cooldown;

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown <= 0)
        {
            enable = true;
        }
        if (enable)
        {
            Instantiate(Enemy, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.identity);
            enable = false;
            cooldown = 3.5f;
        }
    }
}
