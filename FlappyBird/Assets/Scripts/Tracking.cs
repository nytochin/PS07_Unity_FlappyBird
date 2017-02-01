using UnityEngine;
using System.Collections;

public class Tracking : MonoBehaviour {

    Transform target;
    float offsetX;
	// Use this for initialization
	void Start () {
        GameObject target_t = GameObject.FindGameObjectWithTag("Player");
        if (target_t == null)
        {
            Debug.LogError("Couldn't find an object with tag 'Player'!");
            return;
        }
        target = target_t.transform;
        offsetX = transform.position.x - target.position.x;
    }
	
	// Update is called once per frame
	void Update () {
        if (target != null)
        {
            Vector3 t = gameObject.transform.position;
            t.x = target.position.x + offsetX;
            gameObject.transform.position = t;
        }
        
	}
}
