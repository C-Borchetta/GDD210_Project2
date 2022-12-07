using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyscript : MonoBehaviour
{
    public Transform target;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= (transform.position - target.transform.position).normalized * moveSpeed * Time.deltaTime;
    }

    public void TakeDamage(float damage)
    {
            Destroy(gameObject);
    }
}

