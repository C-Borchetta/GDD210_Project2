using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float movespeed;
    //Arrows
    public float bulletcd;
    public GameObject upbullet;
    public GameObject downbullet;
    public GameObject leftbullet;
    public GameObject rightbullet;
    //score
    public TMP_Text Score;
    private bool counting = true;
    private float T;
    //UI
    public Image Health;
    public GameObject Losescreen;
    public GameObject Pausescreen;
    public GameObject Pausebutton;

    // Start is called before the first frame update
    void Start()
    {
        bulletcd = 0;
        T = 0;
        Health.fillAmount = 0.9f;
        Losescreen.SetActive(false);
        Pausescreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        //Player movement
        transform.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f) * Time.deltaTime * movespeed;

        //Score counter
        T += Time.deltaTime;

        if(counting == true)
        {
            Score.text = "Score:" + Mathf.Round(T) / 1f;
        }

        // Shooter
        bulletcd -= Time.deltaTime;

        if (Input.GetKey(KeyCode.UpArrow) && bulletcd <= 0)
        {
            Instantiate(upbullet, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
            bulletcd = 0.45f;

        }
        else if (Input.GetKey(KeyCode.LeftArrow) && bulletcd <= 0)
        {
            Instantiate(leftbullet, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z), Quaternion.identity);
            bulletcd = 0.45f;

        }
        else if (Input.GetKey(KeyCode.RightArrow) && bulletcd <= 0)
        {
            Instantiate(rightbullet, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), Quaternion.identity);
            bulletcd = 0.45f;

        }
        else if (Input.GetKey(KeyCode.DownArrow) && bulletcd <= 0)
        {

            Instantiate(downbullet, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), Quaternion.identity);
            bulletcd = 0.45f;

        }

        //Lose state 
        if (Health.fillAmount <= 0.1f)
        {
            Losescreen.SetActive(true);
            Pausebutton.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        enemyscript e = collision.gameObject.GetComponent<enemyscript>();
        if (e)
        {
            Health.fillAmount -= 0.1f;
        }

    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        Pausescreen.SetActive(true);
        Pausebutton.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        Pausescreen.SetActive(false);
        Pausebutton.SetActive(true);
    }
}
