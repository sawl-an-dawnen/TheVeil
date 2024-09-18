using System.Net;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioClip[] woodSurfaceClips, concreteSurfaceClips, grassSurfaceClips;
    public float footstepTimer;
    public bool silent = false;

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
        audioSource = GameObject.FindGameObjectWithTag("FootSteps").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Ray r_0 = new(gameObject.transform.position, -gameObject.transform.up);//cast ray down
        if (Physics.Raycast(r_0, out RaycastHit hitInfo_0))
        {
            if (hitInfo_0.collider.gameObject)
            {
                //Debug.DrawRay(raySource.position, -raySource.up, Color.green);
                //Debug.Log(hitInfo_0.collider.name);

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
        //Debug.Log(fpc.isGrounded);
        if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) && fpc.isGrounded)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                audioSource.volume = stepVolume;
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
                if (!silent) { 
                    switch (index)
                    {
                        case 0:
                            //Debug.Log("WoodSound");
                            stepIndex = Random.Range(0, woodSurfaceClips.Length);
                            audioSource.PlayOneShot(woodSurfaceClips[stepIndex]);
                            break;
                        case 1:
                            //Debug.Log("ConcreteSound");
                            stepIndex = Random.Range(0, concreteSurfaceClips.Length);
                            audioSource.PlayOneShot(concreteSurfaceClips[stepIndex]);
                            break;
                        case 2:
                            //Debug.Log("GrassSound");
                            stepIndex = Random.Range(0, grassSurfaceClips.Length);
                            audioSource.PlayOneShot(grassSurfaceClips[stepIndex]);
                            break;
                    }
                }
            }
        }
    }

    /*
    void OnCollisionEnter(Collision collisionData)
    {
        Debug.Log(collisionData.gameObject.name);
    }
    */
}
