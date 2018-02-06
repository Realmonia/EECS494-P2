using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Displayer : MonoBehaviour {

    public GameControl game;

    public GameObject healthText;
    public GameObject scoreText;
    public GameObject songText;
    public GameObject inventoryText;

    float time = 0f;

    int minp;
    int secp;

    string total;
    bool stop_timer = false;

	// Use this for initialization
	void Start () {
        float totalTime = Camera.main.GetComponent<AudioSource>().clip.length;
        minp = Mathf.FloorToInt(totalTime / 60f);
        secp = Mathf.RoundToInt(totalTime -= minp * 60);
        total = minp.ToString() + ":";
        if (secp < 10) total += "0";
        total += secp.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        string msg = "Health: " + gameObject.GetComponent<Health>().GetHealth().ToString();
        healthText.GetComponent<Text>().text = msg;

        string msg_score = "Score: " + Camera.main.GetComponent<Counter>().GetScore().ToString();
        scoreText.GetComponent<Text>().text = msg_score;

        string inventory = "Bomb: " + gameObject.GetComponent<Inventory>().GetBomb().ToString();
        inventoryText.GetComponent<Text>().text = inventory;

        if (!stop_timer) {
            time += Time.deltaTime;
        }
        int min = Mathf.FloorToInt(time / 60f);
        int sec = Mathf.RoundToInt(time - min * 60);



        string song = "Music Time: " + min + ":";
        if (sec < 10) song += "0";
        song += sec.ToString() + " / " + total;
        songText.GetComponent<Text>().text = song;

        if (min >= minp && sec >= secp) {
            stop_timer = true;
            game.GameOverSuccess();
        }
	}
}
