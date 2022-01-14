using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float torqueAmount = 1f;
    [SerializeField] private float boostSpeed = 30f;
    [SerializeField] private float baseSpeed = 20f;

    private new Rigidbody2D rigidbody2D;
    private SurfaceEffector2D surfaceEffector2D;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    private void Update()
    {
        RotatePlayer();
        RespondToBoost();
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody2D.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigidbody2D.AddTorque(-torqueAmount);
        }
    }

    private void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.W))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }
}
