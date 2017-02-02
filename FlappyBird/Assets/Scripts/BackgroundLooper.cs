using UnityEngine;
using System.Collections;

public class BackgroundLooper : MonoBehaviour {

    int numBGPanels = 6;
    float pipeMax = -0.2f;
    float pipeMin = -1.1f;

    private void Start()
    {
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");
        foreach(GameObject pipe in pipes)
        {
            Vector3 pos = pipe.transform.position;
            pos.y = Random.Range(pipeMin, pipeMax);
            pipe.transform.position = pos;

        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Triggered : " + collider.name);
        
        float widthBackground = ((BoxCollider2D) collider).size.x;
        Vector3 pos = collider.transform.position;
        pos.x += widthBackground * numBGPanels;

        if (collider.tag == "Pipe")
        {
            pos.y = Random.Range(pipeMin, pipeMax);
        }

        collider.transform.position = pos;
    }
}
