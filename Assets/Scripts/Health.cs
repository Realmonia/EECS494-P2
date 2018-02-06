using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int health;

    public int GetHealth() {
        return health;
    }

	// Update is called once per frame
	void Update () {
		if (health <= 0 && gameObject.tag == "Enemy") {
            Camera.main.GetComponent<Counter>().score += 1;
            Camera.main.GetComponent<Counter>().enemy -= 1;
            Destroy(this.gameObject);
        }
	}
}
