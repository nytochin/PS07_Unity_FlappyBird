using UnityEngine;
using System.Collections;

public class BackgroundLooper : MonoBehaviour {

    int numBGPanels = 6;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Triggered : " + collider.name);
        
        float widthBackground = ((BoxCollider2D) collider).size.x;
        Vector3 pos = collider.transform.position;
        pos.x += widthBackground * numBGPanels - widthBackground/2f;
        collider.transform.position = pos;
    }
}
