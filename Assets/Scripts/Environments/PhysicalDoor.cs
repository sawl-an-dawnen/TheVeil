using UnityEngine;
using System.Collections;

public class PhysicalDoor : MonoBehaviour, IInteractable
{
    public float degree = 90f;
    public float speed = 0.5f;
    public AudioClip openClip;
    public AudioClip closeClip;
    public bool locked = false;
    public AudioClip lockedClip;
    [HideInInspector]
    public bool isOpen = false;
    private AudioSource audioSource;
    private bool coroutineRunning = false;
    private string text;

    private void Awake()
    {
        audioSource = GameObject.FindWithTag("SFX-1").GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (isOpen) { text = "[close]"; }
        if (!isOpen) { text = "[open]"; }
        if (locked) { text = "[locked]"; }
    }

    public void Interact()
    {
        if (locked)
        {
            audioSource.PlayOneShot(lockedClip);
        }
        else
        {
            if (isOpen && !coroutineRunning) //if the door is open and the coroutine isn't running, rotate back to closed position
            {
                try { audioSource.PlayOneShot(closeClip); } //play the close door audio
                catch { }
                StartCoroutine(rotateObject(gameObject.transform.rotation, Quaternion.Euler(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y - degree, gameObject.transform.eulerAngles.z), speed));
                //gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, Quaternion.Euler(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y - degree, gameObject.transform.eulerAngles.z), speed);
                isOpen = false;
            }
            if (!isOpen && !coroutineRunning) //if the door is closed and the coroutine isn't running, rotate back to open position
            {
                try { audioSource.PlayOneShot(openClip); } //play the open door audio
                catch { }
                StartCoroutine(rotateObject(gameObject.transform.rotation, Quaternion.Euler(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y + degree, gameObject.transform.eulerAngles.z), speed));
                //gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, Quaternion.Euler(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y + degree, gameObject.transform.eulerAngles.z), speed);
                isOpen = true;
            }
        }
    }

    private IEnumerator rotateObject(Quaternion source, Quaternion target, float overTime)
    {
        coroutineRunning = true;
        float startTime = Time.time;
        while (Time.time < startTime + overTime)
        {
            gameObject.transform.rotation = Quaternion.Slerp(source, target, (Time.time - startTime) / overTime);
            yield return null;
        }
        transform.rotation = target;
        coroutineRunning = false;
    }

    public string Prompt
    {
        get
        {
            return this.text;
        }
    }

    public void LockDoor()
    {
        locked = true;
    }

    public void UnlockDoor()
    {
        locked = false;
    }

    public void CloseDoor()
    {
        if (isOpen && !coroutineRunning)
        {
            try { audioSource.PlayOneShot(closeClip); } //play the close door audio
            catch { }
            StartCoroutine(rotateObject(gameObject.transform.rotation, Quaternion.Euler(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y - degree, gameObject.transform.eulerAngles.z), speed));
            isOpen = false;
        }
    }

    public void OpenDoor()
    {
        if (!isOpen && !coroutineRunning)
        {
            try { audioSource.PlayOneShot(openClip); } //play the open door audio
            catch { }
            StartCoroutine(rotateObject(gameObject.transform.rotation, Quaternion.Euler(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y + degree, gameObject.transform.eulerAngles.z), speed));
            isOpen = true;
        }
    }
}