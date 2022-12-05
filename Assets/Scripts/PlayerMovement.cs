using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float movespeed;
    public float bulletcd;
    public GameObject bulletprefab;

    // Start is called before the first frame update
    void Start()
    {
        bulletcd = 0;
    }

    // Update is called once per frame
    void Update()
    {

        bulletcd -= Time.deltaTime;


        transform.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f) * Time.deltaTime * movespeed;

        // Shooter
        if (Input.GetKey(KeyCode.UpArrow) && bulletcd <= 0)
        {
            Instantiate(bulletprefab, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
            bulletcd = 0.5f;

        }
        else if (Input.GetKey(KeyCode.LeftArrow) && bulletcd <= 0)
        {
            Instantiate(bulletprefab, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z), Quaternion.identity);
            bulletcd = 0.5f;

        }
        else if (Input.GetKey(KeyCode.RightArrow) && bulletcd <= 0)
        {
            Instantiate(bulletprefab, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), Quaternion.identity);
            bulletcd = 0.5f;

        }
        else if (Input.GetKey(KeyCode.DownArrow) && bulletcd <= 0)
        {

            Instantiate(bulletprefab, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), Quaternion.identity);
            bulletcd = 0.5f;

        }
    }
}
