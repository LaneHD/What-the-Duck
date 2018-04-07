using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controls : MonoBehaviour
{
    public float speed = 1F;
    public GameObject UI;
    public GameObject Menu;
    public bool playing = false;
    public bool moving = false;
    Vector3 direction = new Vector3(0, 1).normalized;
    public Rigidbody2D RigidBody2D;
    public Text score;
    private float PositionY;
    public GameObject player;
    public Text highScore;
    public bool tutorial = true;
    void Start()
    {
        highScore.text = PlayerPrefs.GetInt("Highscore").ToString();
        PositionY = player.transform.position.y;
    }
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Menu.SetActive(false);
            UI.SetActive(true);
            if (playing)
                moving = true;
            if (moving)
            {
                // Move object across XY plane
                RigidBody2D.velocity = direction * speed;
            }
            playing = true;

        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("COLL");
        if (collision.gameObject.tag == "Finish")
        {
            int score = Int32.Parse(this.score.text);
            score++;
            this.score.text = score++.ToString();
            tutorial = false;
        }
        else if(collision.gameObject.tag == "Enemy")
        {
            int score = Int32.Parse(this.score.text);
            score-=2;
            this.score.text = score.ToString();
        }

        moving = false;
        RigidBody2D.velocity = new Vector2(0.0F, 0.0F);
        player.transform.position = new Vector3(0.0F, PositionY, 0.0F);
        if (PlayerPrefs.GetInt("Highscore") < Int32.Parse(this.score.text))
        {
            PlayerPrefs.SetInt("Highscore", Int32.Parse(this.score.text));
        }

        if (Int32.Parse(score.text) < 0)
        {
            score.text = "0";
        }
    }
}
