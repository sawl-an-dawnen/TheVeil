using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour, IInteractable
{
    public float speed = 0.5f;
    public float distance = 1f;
    public AudioClip openClip;
    public AudioClip closeClip;
    public bool locked = false;
    public AudioClip lockedClip;
    [HideInInspector]
    public bool isOpen = false;
    public bool zAxis = false;
    private AudioSource audioSource;
    private bool coroutineRunning = false;
    private string text;
    private float x = 0f;
    private float z = 0f;

    private void Awake()
    {
        //audioSource = GameObject.FindWithTag("Player_AudioSource").GetComponent<AudioSource>();
        if (zAxis)
        {
            z = distance;
        }
        else 
        {
            x = distance;
        }
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
                StartCoroutine(moveObject(gameObject.transform.position, new Vector3(gameObject.transform.position.x + x, gameObject.transform.position.y, gameObject.transform.position.z + z), speed));
                //gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, Quaternion.Euler(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y - degree, gameObject.transform.eulerAngles.z), speed);
                isOpen = false;
            }
            if (!isOpen && !coroutineRunning) //if the door is closed and the coroutine isn't running, rotate back to open position
            {
                try { audioSource.PlayOneShot(openClip); } //play the open door audio
                catch { }
                StartCoroutine(moveObject(gameObject.transform.position, new Vector3(gameObject.transform.position.x - x, gameObject.transform.position.y, gameObject.transform.position.z - z), speed));
                //gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, Quaternion.Euler(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y + degree, gameObject.transform.eulerAngles.z), speed);
                isOpen = true;
            }
        }
    }

    private IEnumerator moveObject(Vector3 source, Vector3 target, float overTime)
    {
        coroutineRunning = true;
        float startTime = Time.time;
        while (Time.time < startTime + overTime)
        {
            gameObject.transform.position = Vector3.MoveTowards(source, target, (Time.time - startTime) / overTime);
            yield return null;
        }
        transform.position = target;
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
        if (isOpen && !coroutineRunning) //if the door is open and the coroutine isn't running, rotate back to closed position
        {
            try { audioSource.PlayOneShot(closeClip); } //play the close door audio
            catch { }
            StartCoroutine(moveObject(gameObject.transform.position, new Vector3(gameObject.transform.position.x + x, gameObject.transform.position.y, gameObject.transform.position.z + z), speed));
            //gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, Quaternion.Euler(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y - degree, gameObject.transform.eulerAngles.z), speed);
            isOpen = false;
        }
    }

    public void OpenDoor()
    {
        if (!isOpen && !coroutineRunning) //if the door is closed and the coroutine isn't running, rotate back to open position
        {
            try { audioSource.PlayOneShot(openClip); } //play the open door audio
            catch { }
            StartCoroutine(moveObject(gameObject.transform.position, new Vector3(gameObject.transform.position.x - x, gameObject.transform.position.y, gameObject.transform.position.z - z), speed));
            //gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, Quaternion.Euler(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y + degree, gameObject.transform.eulerAngles.z), speed);
            isOpen = true;
        }
    }
}
