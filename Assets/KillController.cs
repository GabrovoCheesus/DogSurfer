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
        SpriteRenderer renderer = other.GetComponent<SpriteRenderer>();
        renderer.color = new Color(0.5f, 0.5f, 0.5f, .5f); // Set to opaque gray

        PlayerController controller = other.GetComponent<PlayerController>();
        controller.PlayDethScene();
    }

}
