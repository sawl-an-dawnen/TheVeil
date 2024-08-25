using System.Collections;
using UnityEngine;

public class EventTriggerAfterDelay : MonoBehaviour
{
    // Time in seconds to wait before triggering the event
    public float delay = 5.0f;
    public GameObject[] activate;
    public GameObject[] destroy;
    public AudioClip sound;
    private AudioSource audioSource;

    private void Awake()
    {
       audioSource = GameObject.FindGameObjectWithTag("SFX-2").GetComponent<AudioSource>();
    }

    void Start()
    {
        // Start the coroutine to wait and trigger the event
        StartCoroutine(TriggerEventAfterDelay());
    }

    // Coroutine to handle the delay and event triggering
    IEnumerator TriggerEventAfterDelay()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(delay);

        // Call the event method
        TriggerEvent();
    }

    // Method to trigger your custom event
    void TriggerEvent()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(sound);
        foreach (GameObject a in activate)
        {
            a.SetActive(true);
        }
        foreach (GameObject d in destroy)
        {
            Destroy(d);
        }
        Destroy(this);
    }
}
