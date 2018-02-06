using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerup : MonoBehaviour {

    public GameObject Powerup1;

    private void Start() {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn() {
        while (true) {
            Instantiate(Powerup1, new Vector3(0f, 10f, 0f), transform.rotation);
            yield return new WaitForSeconds(30f);
        }
    }
}
