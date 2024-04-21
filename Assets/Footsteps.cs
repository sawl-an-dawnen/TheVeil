using System.Net;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioClip[] woodSurfaceClips, concreteSurfaceClips, grassSurfaceClips;
    public float footstepTimer;

    private FirstPersonController fpc;
    private AudioSource audioSource;
    private int index;
    private int stepIndex;
    private float timer;
    readonly float stepVolume = 0.5f;

    // Start is called before the first frame update
    void Awake()
    {
        fpc = gameObject.GetComponent<FirstPersonController>();
        audioSource = GameObject.FindGameObjectWithTag("Footsteps").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray r_0 = new(gameObject.transform.position, -gameObject.transform.up);//cast ray down
        if (Physics.Raycast(r_0, out RaycastHit hitInfo_0))
        {
            if (hitInfo_0.collider.gameObject)
            {
                //Debug.DrawRay(raySource.position, -raySource.up, Color.green);
                Debug.Log(hitInfo_0.collider.tag);

                switch (hitInfo_0.collider.tag) 
                {
                    case "Wood":
                        index = 0;
                        break;
                    case "Concrete":
                        index = 1;
                        break;
                    case "Grass":
                        index = 2;
                        break;
                }
            }
        }

        if (fpc.isWalking && fpc.isGrounded)
        {
            audioSource.volume = stepVolume;
            timer -= Time.deltaTime;

            if (timer <= 0) 
            {
                timer = footstepTimer;
                if (fpc.isSprinting)
                {
                    audioSource.volume = stepVolume * 1.5f;
                    timer = footstepTimer * .6f;
                }
                else if (fpc.isCrouched)
                {
                    audioSource.volume = stepVolume * .5f;
                    timer = footstepTimer * 1.5f;
                }
                switch (index) 
                {
                    case 0:
                        stepIndex = Random.Range(0, woodSurfaceClips.Length);
                        audioSource.PlayOneShot(woodSurfaceClips[stepIndex]);
                        break;
                    case 1:
                        stepIndex = Random.Range(0, concreteSurfaceClips.Length);
                        audioSource.PlayOneShot(concreteSurfaceClips[stepIndex]);
                        break;
                    case 2:
                        stepIndex = Random.Range(0, grassSurfaceClips.Length);
                        audioSource.PlayOneShot(grassSurfaceClips[stepIndex]);
                        break;
                }
            }
        }
    }
}
