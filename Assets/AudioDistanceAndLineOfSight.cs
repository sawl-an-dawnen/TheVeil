using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDistanceAndLineOfSight : MonoBehaviour
{
    public Transform player; // Reference to the player
    public AudioSource audioSource; // The AudioSource component
    public float maxVolumeDistance = 10f; // Distance at which the audio is at max volume
    public float minVolumeDistance = 2f; // Distance at which the audio starts fading
    public float maxVolume = 1.0f; // Maximum volume of the AudioSource
    public float obstructionVolumeMultiplier = 0.3f; // The volume multiplier when obstructed (e.g., 30% of max)
    public LayerMask obstructionMask; // LayerMask to detect obstacles (like walls)
    public bool debugRaycast = true; // Toggle to enable/disable raycast debugging

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        // Calculate the distance between the player and the object
        float distance = Vector3.Distance(player.position, transform.position);

        // Check if the player has line of sight to the object
        bool hasLineOfSight = CheckLineOfSight();

        // Adjust the volume based on distance and line of sight
        float targetVolume = CalculateVolumeBasedOnDistance(distance);

        // If player doesn't have line of sight, apply the obstruction volume multiplier
        if (!hasLineOfSight)
        {
            targetVolume *= obstructionVolumeMultiplier; // Reduce volume based on the multiplier
        }

        // Smoothly transition the volume to the target value
        audioSource.volume = Mathf.Lerp(audioSource.volume, targetVolume, Time.deltaTime * 5f);
    }

    // Function to calculate volume based on player's distance
    private float CalculateVolumeBasedOnDistance(float distance)
    {
        // Calculate the volume based on the player's distance from the object
        return Mathf.Clamp01((maxVolumeDistance - distance) / (maxVolumeDistance - minVolumeDistance)) * maxVolume;
    }

    // Function to check if there's a clear line of sight between the player and the audio source
    private bool CheckLineOfSight()
    {
        Vector3 directionToPlayer = player.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;

        // Raycast from the object to the player and check if there's any obstruction
        if (Physics.Raycast(transform.position, directionToPlayer.normalized, out RaycastHit hit, distanceToPlayer, obstructionMask) && hit.collider.tag != "Player")
        {
            // If debug mode is enabled, draw the ray in red (indicating an obstruction)
            if (debugRaycast)
            {
                Debug.DrawRay(transform.position, directionToPlayer.normalized * hit.distance, Color.red);
            }
            // If the ray hits something before reaching the player, there's an obstruction
            return false;
        }

        // If debug mode is enabled, draw the ray in green (indicating a clear line of sight)
        if (debugRaycast)
        {
            Debug.DrawRay(transform.position, directionToPlayer.normalized * distanceToPlayer, Color.green);
        }

        // No obstruction, player has line of sight
        return true;
    }
}
