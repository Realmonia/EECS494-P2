using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour {

    private Vector3 initial_position;

    public float destroy_distance = 10.0f;

	// Use this for initialization
	void Start () {
        initial_position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(initial_position, transform.position) > destroy_distance) {
            Destroy(gameObject);
        }
	}
}
