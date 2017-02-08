using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

    public GameObject player;
    public GameObject background;
    public float x_offset;

	// Use this for initialization
	void Start () {
        Vector3 leftCamera = new Vector3(0,0,0);
        x_offset = transform.position.x - player.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newCameraCoordinates = new Vector3(player.transform.position.x + x_offset, 
            transform.position.y, 
            transform.position.z);

        Vector3 cameraMovement = newCameraCoordinates - transform.position;
        
        // Change the position of the cameras
        transform.position = newCameraCoordinates;

        // Change the position of the background
        background.transform.position = background.transform.position + cameraMovement;


	}
}
