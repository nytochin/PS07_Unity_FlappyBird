using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {

    Vector3 velocity = Vector3.zero;
    public float flapSpeed;
    public float forwardSpeed;

    bool didFlap = false;
    bool dead = false;
    Animator animator;

	// Use this for initialization
	void Start () {
        animator = transform.GetComponentInChildren<Animator>();
	}

    // Do graphic & input updates here
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            didFlap = true;
            animator.SetTrigger("DoFlap");
        }
    }
	
	// Do physics engine update here
	void FixedUpdate () {
        if (dead)
        {
            return;
        }

        if (GetComponent<Rigidbody2D>().velocity.x < 1f)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * forwardSpeed);
        }
        Debug.Log(GetComponent<Rigidbody2D>().velocity.x);
        if (didFlap)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * flapSpeed);
            didFlap = false;
        }

        if (GetComponent<Rigidbody2D>().velocity.y > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            float angle = Mathf.Lerp(0, -90, -GetComponent<Rigidbody2D>().velocity.y / 3f);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetTrigger("Death");
        dead = true;
    }
}
