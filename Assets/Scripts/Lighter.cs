using UnityEngine;
using System.Collections;

public class Lighter : MonoBehaviour
{
    public float heightChange = 0.5f;
    public GameObject flame;
    public AudioClip onClip, offClip;
    private bool status = true;
    private AudioSource audioSource;


    private void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("SFX-2").GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && status)
        {
            TurnOff();
        }
        else if (Input.GetKeyDown(KeyCode.F) && !status)
        {
            TurnOn();
        }
    }

    public void TurnOn() {
        audioSource.Stop();
        audioSource.PlayOneShot(onClip);
        gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y + heightChange, gameObject.transform.localPosition.z);
        flame.SetActive(true);
        status = true;
    }
    public void TurnOff() {
        audioSource.Stop();
        audioSource.PlayOneShot(offClip);
        gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y - heightChange, gameObject.transform.localPosition.z);
        flame.SetActive(false);
        status = false;
    }
}
