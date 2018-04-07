using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class duck : MonoBehaviour
{
    public GameObject DuckObject;

    public int ActivationScore;
    public float Speed = 1;

    public float ScreenWidth;

    public Camera Cam;

    public bool active = false;

    public Rigidbody2D Rigidbody2D;

    private Vector3 direction = new Vector3(1, 0);

    public SpriteRenderer SpriteRenderer;

    public Controls Controls;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ScreenWidth = Cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height)).x;
        if (!active)
        {
            DuckObject.transform.position = new Vector3(0 - ScreenWidth - 1F, DuckObject.transform.position.y);
        }

        if (active)
        {
            if (DuckObject.transform.position.x < 0 - ScreenWidth + .5F)
            {
                direction = new Vector3(1, 0);
                SpriteRenderer.flipX = true;
                Rigidbody2D.velocity = direction * Speed;
            }
            else if (DuckObject.transform.position.x > ScreenWidth - .5F)
            {
                direction = new Vector3(-1, 0);
                SpriteRenderer.flipX = false;
                Rigidbody2D.velocity = direction * Speed;
            }
        }

        if (Controls.playing && Int32.Parse(Controls.score.text) >= ActivationScore)
        {
            active = true;
        }
        else
        {
            active = false;
        }

        if (Controls.tutorial)
        {
            active = false;
        }
    }
}
