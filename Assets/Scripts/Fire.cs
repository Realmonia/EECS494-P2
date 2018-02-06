using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    public GameObject Bullet;

    public float bulletSpeed = 10f;

    public int fireRate = 1;

    float time_ = 0f;
	
	// Update is called once per frame
	void Update () {
        time_ += Time.deltaTime;
        if (time_ > 0.2f) {
            if (Input.GetMouseButton(0)) {
                for (int i = 0; i < fireRate; ++i) {
                    GameObject spawned1 = Instantiate(Bullet, transform.position + new Vector3(transform.up.y, -transform.up.x, transform.up.z) * i * 0.2f, transform.rotation);
                    spawned1.GetComponent<Rigidbody>().velocity = spawned1.transform.up * bulletSpeed;
                    GameObject spawned2 = Instantiate(Bullet, transform.position - new Vector3(transform.up.y, -transform.up.x, transform.up.z) * i * 0.2f, transform.rotation);
                    spawned2.GetComponent<Rigidbody>().velocity = spawned2.transform.up * bulletSpeed;
                }
            }
            time_ = 0f;
        }
    }
}
