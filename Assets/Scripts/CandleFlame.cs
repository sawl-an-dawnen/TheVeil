using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleFlame : MonoBehaviour
{
    public float flickerSpeed = 1f;
    public float flickerIntensity = 0.1f;
    public float moveSpeed = 0.5f;
    public float moveRange = 0.1f;
    private Vector3 initialLocalPosition;
    private Vector3 initialLocalScale;
    private float timeOffset;

    void Awake()
    {
        initialLocalPosition = transform.localPosition;
        initialLocalScale = transform.localScale;
        timeOffset = Random.Range(0f, 2f * Mathf.PI); // Randomize the starting point of the flicker
    }

    void Update()
    {
        // Flicker effect
        float flicker = Mathf.PerlinNoise(Time.time * flickerSpeed, timeOffset) * flickerIntensity;
        transform.localScale = initialLocalScale + initialLocalScale * flicker;

        // Move horizontally within a range
        float moveOffset = Mathf.Sin(Time.time * moveSpeed) * moveRange;
        transform.localPosition = initialLocalPosition + new Vector3(moveOffset, 0f, 0f);
    }
}
