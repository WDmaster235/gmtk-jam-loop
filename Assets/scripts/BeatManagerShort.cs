using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BeatManagerShort : MonoBehaviour
{
    [SerializeField] private float bpm;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float steps;

    public CircleSpawner circleSpawner;
    public float IntervalLength;
    private int LastInterval;
    private float sampledTime;

    void Start()
    {
        IntervalLength = 60f / (bpm * steps);
    }

    void Update()
    {
        sampledTime = (audioSource.timeSamples / (audioSource.clip.frequency * IntervalLength));
        CheckForNewInterval(sampledTime);
        if (Input.GetKeyDown("h"))
            PlayLevel();
    }

    void CheckForNewInterval(float interval)
    {
        if (Mathf.FloorToInt(interval) != LastInterval)
        {
            LastInterval = Mathf.FloorToInt(interval);
            circleSpawner.BeatLength++;
        }
    }

    public void PlayLevel()
    {
        audioSource.Play();
    }
}
