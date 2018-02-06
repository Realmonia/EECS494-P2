using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowKeyControl : MonoBehaviour {


    Rigidbody rb;

    public float movement_speed = 4;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        Vector2 current_input = GetInput();
        if (transform.position.x <= -10f) {
            if (current_input.x < 0) {
                current_input.x = 0;
            }
        } else if (transform.position.x >= 10f) {
            if (current_input.x > 0) {
                current_input.x = 0;
            }
        } else if (transform.position.y <-7f) {
            if (current_input.y < 0) {
                current_input.y = 0;
            }
        } else if (transform.position.y >6f) {
            if (current_input.y > 0) {
                current_input.y = 0;
            }
        }
        rb.velocity = current_input * movement_speed;
    }

    Vector2 GetInput() {
        float horizontal_input = Input.GetAxisRaw("Horizontal");
        float vertical_input = Input.GetAxisRaw("Vertical");
        return new Vector2(horizontal_input, vertical_input);
    }
}
