using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnSightTrigger : MonoBehaviour
{
    public bool collisionOnly = false;
    public float angleThreshold = 30f; //the angle at which look away will trigger

    public float timeToTrigger = 3f;
    public float time = 1f;

    public Texture2D imageTexture;
    public AudioClip sound;



    public GameObject[] activate;
    public GameObject[] destroy;

    public PhysicalDoor[] doors; //doors that will toggle open/closer

    private Transform playerCameraTransform;
    private RawImage imageUI;
    private AudioSource audioSource;
    private bool visible = false;
    private bool activated = false;
    private bool flag = false;

    private void Awake()
    {
        playerCameraTransform = Camera.main.transform;
        imageUI = GameObject.FindGameObjectWithTag("UI_JumpScare_Raw").GetComponent<RawImage>();
        audioSource = GameObject.FindGameObjectWithTag("SFX-2").GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //ANGLE CALCULATION
        Vector3 directionToPlayer = transform.position - playerCameraTransform.position;
        directionToPlayer = directionToPlayer.normalized;

        Vector3 playerForward = playerCameraTransform.forward;

        float angle = Vector3.Angle(directionToPlayer, playerForward);
        Debug.Log(angle);

        //RAY COLLISION
        Ray r_0 = new(gameObject.transform.position, -directionToPlayer);
        if (Physics.Raycast(r_0, out RaycastHit hitInfo_0, 10f, 3))
        {
            Debug.DrawRay(gameObject.transform.position, -directionToPlayer * 10f, Color.green);
            if (hitInfo_0.collider.tag == "Player")
            {
                visible = true;
            }
            else
            {
                visible = false;
            }
        }

        if (visible && angle < angleThreshold && !activated)
        {
            if (!collisionOnly)
            {
                StartCoroutine(DisplayImage());
                activated = true;
            }
        }
        if (flag)
        {
            foreach (GameObject a in activate)
            {
                a.SetActive(true);
            }
            foreach (GameObject d in destroy)
            {
                Destroy(d);
            }
            foreach (PhysicalDoor pd in doors)
            {
                pd.ToggleDoor(true);
            }
            Destroy(this);
        }

    }

    private IEnumerator DisplayImage()
    {
        Vector2 originalSizeDelta = imageUI.rectTransform.sizeDelta;
        if (imageTexture != null) { 
            yield return new WaitForSeconds(timeToTrigger);
            //playerManager.DeactivateControl();
            imageUI.texture = imageTexture;
            imageUI.enabled = true;

            activated = true;
            audioSource.PlayOneShot(sound);

            float textureAspect = (float)imageTexture.width / imageTexture.height;
            imageUI.rectTransform.sizeDelta = new Vector2(imageUI.rectTransform.sizeDelta.y * textureAspect, imageUI.rectTransform.sizeDelta.y);
        }   

        yield return new WaitForSeconds(time);

        flag = true;
        imageUI.rectTransform.sizeDelta = originalSizeDelta;
        activated = false;
        imageUI.enabled = false;
        //playerManager.ActivateControl();
        //Destroy(gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DisplayImage());
            activated = true;
        }
    }
}
