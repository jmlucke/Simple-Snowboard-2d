using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControls : MonoBehaviour
{
    // used for snowboarder (main player)
    Rigidbody2D rb2D;
    [SerializeField] float playerTorqueAmount=7f;
    SurfaceEffector2D surfaceE2d;
    [SerializeField] float boostSpeed=35f;
    [SerializeField] float normalSpeed=20f;
    bool movementPlayer = true;
    public bool audioPlayer = true;
    void Start()
    {
        rb2D =  GetComponent<Rigidbody2D>();
        surfaceE2d = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(movementPlayer)
        {
            RotatePlayer();
            RespondToBoost();
        }
         

    }
    public void DisableControls()
    {
        movementPlayer = false;
        audioPlayer = false;
    }
    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            surfaceE2d.speed = boostSpeed;
        }
        else
        {
            surfaceE2d.speed = normalSpeed;
        }
    }
    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2D.AddTorque(playerTorqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2D.AddTorque(-playerTorqueAmount);
        }
    }
}
