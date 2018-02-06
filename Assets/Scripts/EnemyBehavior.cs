using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    public float radiusSpeed;
    public float randomSpeed;
    public GameObject player;


	// Use this for initialization
	void Start () {
        Vector3 born_position = Vector3.zero;
        if (Random.Range(0f, 1f) > 0.5f) {
            if (Random.Range(0f, 1f) > 0.5f)
                born_position.x = 10f;
            else
                born_position.x = -10f;
            born_position.y = Random.Range(-7f, 6f);
        } else {
            if (Random.Range(0f, 1f) > 0.5f)
                born_position.y = -7f;
            else
                born_position.y = 6f;
            born_position.x = Random.Range(-10f, 10f);
        }
        player = GameObject.Find("Player");
        gameObject.transform.position = born_position;
        gameObject.transform.up = (gameObject.transform.position - player.transform.position).normalized;
        StartCoroutine(RandomMovement());
    }

    IEnumerator RandomMovement() {
        while (true) {
            // make enemy do random movement but heading forward center
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero - gameObject.transform.up * radiusSpeed
                + new Vector3(gameObject.transform.up.y, -gameObject.transform.up.x, gameObject.transform.up.z) * Random.Range(-1, 1) * randomSpeed;

            // make enemy face the player
            gameObject.transform.up = (gameObject.transform.position - player.transform.position).normalized;
            yield return new WaitForSeconds(0.5f);
        }
    }


    private void OnCollisionEnter(Collision collision) {
        Debug.Log(collision);
        if (collision.gameObject.tag == "Player") {
            Debug.Log("hit player!");
            collision.gameObject.GetComponent<Health>().health -= 1;
            if (!GameObject.Find("Bomb(Clone)"))
                player.GetComponent<Explosion>().Explode();
        }
        if (collision.gameObject.tag == "Bullet") {
            Debug.Log("get hit by bullet!");
            gameObject.GetComponent<Health>().health -= 1;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Bomb") {
            Debug.Log("destroyed by a bomb!");
        }
    }
}
