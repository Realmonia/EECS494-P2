using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    SphereCollider cd;
    SpriteRenderer sr;
    public float explosion_rate;
    float current_radius;

	// Use this for initialization
	void Start () {
        cd = gameObject.GetComponent<SphereCollider>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        current_radius = cd.radius;
	}
	
	// Update is called once per frame
	void Update () {
        current_radius += explosion_rate * Time.deltaTime;
        if (current_radius < 10f) {
            cd.radius = current_radius;
            sr.size = new Vector2(2f*current_radius, 2f*current_radius);
        } else {
            cd.enabled = false;
            sr.enabled = false;
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Enemy") {
            Debug.Log("git by bomb!");
            Camera.main.GetComponent<Counter>().enemy -= 1;
            Destroy(other.gameObject);
        }
    }
}
