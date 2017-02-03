using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillController : MonoBehaviour {
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        if (controller == null)
            return;

        SpriteRenderer renderer = other.GetComponent<SpriteRenderer>();
        if (renderer == null)
            return;

        renderer.color = new Color(0.5f, 0.5f, 0.5f, .5f); // Set to opaque gray

        controller.PlayDethScene();
    }

}
