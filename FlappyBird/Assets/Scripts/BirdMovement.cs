﻿using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {

    Vector3 velocity = Vector3.zero;
    public Vector3 gravity;
    public Vector3 flapVelocity;
    public float maxSpeed = 5f;
    public float forwardSpeed = 1f;
    bool didFlap = false;

	// Use this for initialization
	void Start () {
	
	}

    // Do graphic & input updates here
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            didFlap = true;
        }
    }
	
	// Do physics engine update here
	void FixedUpdate () {
        velocity.x = forwardSpeed;
        velocity += gravity * Time.deltaTime;
        if (didFlap)
        {
            didFlap = false;
            if (velocity.y < 0)
            {
                velocity.y = 0;
            }
            velocity += flapVelocity;
        }

        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        transform.position += velocity * Time.deltaTime;

        float angle = 0f;
        if (velocity.y < 0)
        {
            angle = Mathf.Lerp(0, -90, -velocity.y / maxSpeed);
        }

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
