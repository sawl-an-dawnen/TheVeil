using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingFan : MonoBehaviour, IInteractable
{
    public Vector3 rotationAxis = Vector3.up; // Specify the rotation axis
    public float rotationSpeed = 200f; // Specify the rotation speed in degrees per second
    public float acceleration = 80f;
    public AudioClip sound;
    public bool status;
    public bool power;
    private string text;
    private AudioSource audioSource;
    private AudioSource fanNoise;
    private float currentSpeed;

    private void Awake()
    {
        audioSource = GameObject.FindGameObjectWithTag("SFX-2").GetComponent<AudioSource>();
        fanNoise = gameObject.GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        //if on
        if (power && status)
        {
            text = "[turn off]";
            if (currentSpeed < rotationSpeed)
            {
                currentSpeed += Time.deltaTime * acceleration;
            }
            fanNoise.enabled = true;
        }
        //if off
        if (power && !status)
        {
            text = "[turn on]";
            if (currentSpeed > 0f)
            {
                currentSpeed -= Time.deltaTime * acceleration;
            }
            fanNoise.enabled = false;
        }
        //no power
        if (!power)
        {
            text = "[no power]";
            if (currentSpeed > 0f)
            {
                currentSpeed -= Time.deltaTime * acceleration;
            }
            fanNoise.enabled = false;
        }
        // Rotate the object around the specified axis at constant speed
        transform.Rotate(rotationAxis, currentSpeed * Time.deltaTime);
    }

    public void Interact()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(sound);
        status = !status;
    }

    public string Prompt
    {
        get
        {
            return this.text;
        }
    }
}

