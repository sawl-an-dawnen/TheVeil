using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if ((moveX != 0 || moveZ != 0) && characterController.isGrounded)
        {
            audioSource.volume = stepVolume;
            timer -= Time.deltaTime;
            if (hardSurface) { stepIndex = Random.Range(0, soundClips.Length); }
            else { stepIndex = Random.Range(0, forestClips.Length); }

            if (timer <= 0 && playerSpeed == walkSpeed)
            {
                if (hardSurface) { audioSource.PlayOneShot(soundClips[stepIndex]); }
                else { audioSource.PlayOneShot(forestClips[stepIndex]); }
                timer = footstepTimer;
            }
            else if (timer <= 0 && playerSpeed == sprintSpeed)
            {
                audioSource.volume = stepVolume * 1.5f;
                if (hardSurface) { audioSource.PlayOneShot(soundClips[stepIndex]); }
                else { audioSource.PlayOneShot(forestClips[stepIndex]); }
                timer = footstepTimer * 0.6f;
            }
            else if (timer <= 0 && playerSpeed == crouchSpeed)
            {
                audioSource.volume = stepVolume * 0.2f;
                if (hardSurface) { audioSource.PlayOneShot(soundClips[stepIndex]); }
                else { audioSource.PlayOneShot(forestClips[stepIndex]); }
                timer = footstepTimer * 1.5f;
            }
        }
        */
    }
}
