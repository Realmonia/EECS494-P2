using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

    public GameObject Enemy;

    public int enemyAmountLimit = 10;
    public int spawnRate = 1;
	
	// Spawn enemy function
	public void Spawn_helper () {
        if (Camera.main.GetComponent<Counter>().enemy < enemyAmountLimit) {
            for (int i = 0; i < spawnRate; ++i) {
                Instantiate(Enemy, Vector3.zero, Quaternion.identity);
            }
            Camera.main.GetComponent<Counter>().enemy += spawnRate;
        }
    }

/*    IEnumerator Spawn() {
        while (true) {
            if (Camera.main.GetComponent<Counter>().enemy < enemyAmountLimit) {
                for (int i = 0; i < spawnRate; ++i) {
                    Instantiate(Enemy, Vector3.zero, Quaternion.identity);
                }
                Camera.main.GetComponent<Counter>().enemy += spawnRate;
            }
            yield return new WaitForSeconds(1.0f);
        }
    }
*/
}
