using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventGenerator : MonoBehaviour {

    public float Power;
    public float time_limit_lower;
    public float time_limit_upper;
    public GameObject Spawner;
    public GameObject FireController;

    private float time_;

    void Start() {
        //Select the instance of AudioProcessor and pass a reference
        //to this object
        AudioProcessor processor = FindObjectOfType<AudioProcessor>();
        processor.onBeat.AddListener(onOnbeatDetected);
        processor.onSpectrum.AddListener(onSpectrum);
        time_ = 0f;
    }

    private void Update() {
        time_ += Time.deltaTime;
        if (time_ > time_limit_upper) {
            Spawner.GetComponent<SpawnEnemy>().Spawn_helper();
            time_ = 0f;
        }
    }

    void onOnbeatDetected() {
        Debug.Log("Beat and spawn" + time_.ToString());
        if (time_ > time_limit_lower) {
            Spawner.GetComponent<SpawnEnemy>().Spawn_helper();
            time_ = 0f;
        }
    }

    //This event will be called every frame while music is playing
    void onSpectrum(float[] spectrum) {
        //The spectrum is logarithmically averaged
        //to 12 bands
        float curSum = 0f;

        for (int i = 0; i < spectrum.Length; ++i) {
            Vector3 start = new Vector3(i, 0, 0);
            Vector3 end = new Vector3(i, spectrum[i], 0);
            Debug.DrawLine(start, end);
            curSum += spectrum[i];
        }

        FireController.GetComponent<Fire>().fireRate = Mathf.RoundToInt(curSum / 0.2f) + 1;
    }
}