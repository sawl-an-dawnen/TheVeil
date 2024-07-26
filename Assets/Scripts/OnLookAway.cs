using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLookAway : MonoBehaviour
{
    public float angleThreshold = 30f; //the angle at which look away will trigger

    public GameObject[] activate;
    public GameObject[] destroy;

    private Transform playerCameraTransform;

    private void Awake()
    {
        playerCameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionToPlayer = playerCameraTransform.position - transform.position;
        directionToPlayer = directionToPlayer.normalized;

        Vector3 playerForward = playerCameraTransform.forward;

        float angle = Vector3.Angle(directionToPlayer, playerForward);
        Debug.Log(angle);

        if (angle < angleThreshold) 
        {
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
}

