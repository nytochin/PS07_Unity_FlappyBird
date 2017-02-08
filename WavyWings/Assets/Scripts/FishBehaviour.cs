using UnityEngine;
using System.Collections;

public class FishBehaviour : MonoBehaviour {

    private Vector2 velocity;
    private bool isDiving;
    private Rigidbody2D rb;
    public float divingForce;
    public float forwardForce;
    public float highestSpeed;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("down"))
        {
            isDiving = true;
        } else
        {
            isDiving = false;
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector2(1,0) * forwardForce);
        if (rb.velocity.x > highestSpeed) {

            rb.velocity = new Vector2(highestSpeed, rb.velocity.y);
        }
        if (isDiving)
        {
            rb.AddForce(transform.up * -1 * divingForce);
        }
    }
}
