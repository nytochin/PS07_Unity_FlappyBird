using UnityEngine;
using System.Collections;

public class GroundMover : MonoBehaviour {

    float speed = 0f;
    Rigidbody2D player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float vel = player.velocity.x * 0.7f;
        transform.position = transform.position + Vector3.right * vel * Time.deltaTime;
	}


}
