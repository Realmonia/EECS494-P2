using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {
    static public GameControl instance;

    public GameObject player;
    public GameObject gameOverText;
    public GameObject winText;

    void Awake() {
        if (instance == null) instance = this;
        else Destroy(this);
    }

    void Start() {
        Debug.Assert(player, "player should not be null!", this);
        Debug.Assert(gameOverText, "gameOverText should not be null!", this);
    }

    private void Update() {
        if (player.GetComponent<Health>().health <= 0) {
            GameOverLoss();
        }
    }


    public void Reset() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOverLoss() {
        gameOverText.SetActive(true);

        StartCoroutine(GameOverSequence());
    }

    public void GameOverSuccess() {
        winText.SetActive(true);
        StartCoroutine(GameOverSequence());
    }

    private IEnumerator GameOverSequence() {
        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        // Stop all movement.
        foreach (GameObject o in allObjects) {
            if (o.GetComponent<Rigidbody>() && o.name != "Player") Destroy(o);
        }

        // Stop music.
        Camera.main.GetComponent<AudioSource>().enabled = false;

        yield return new WaitForSeconds(2.0f);

        Reset();
    }
}
