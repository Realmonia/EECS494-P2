using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour {


    public int powerup_id;

    public float dropSpeed;

    /* ID for PowerUps
     * 0: Health
     * 1: Bomb
     */

    private void Start() {
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0f, -1f * dropSpeed, 0f);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            if (powerup_id == 1)
                other.gameObject.GetComponent<Inventory>().AddBomb();
            Destroy(gameObject);
        }
    }

    private void Update() {
        if (transform.position.y < -10f) {
            Destroy(gameObject);
        }
    }
}
