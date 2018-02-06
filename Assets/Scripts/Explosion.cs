using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public GameObject bomb;

    // Update is called once per frame
    void Update () {
		if (Input.GetMouseButtonDown(1) && !GameObject.Find("Bomb(Clone)")) {
            if (gameObject.GetComponent<Inventory>().UseBomb()) Explode();
        }
	}

    public void Explode () {
        Debug.Log("Explode!");
        Instantiate(bomb, transform.position, Quaternion.identity);
    }
}
