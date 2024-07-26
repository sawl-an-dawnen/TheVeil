using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{

    public GameObject[] activate;
    public GameObject[] destroy;
    // Start is called before the first frame update

    // Update is called once per frame
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (GameObject a in activate)
            {
                a.SetActive(true);
            }
            foreach (GameObject d in destroy)
            {
                d.SetActive(false);
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (GameObject a in activate)
            {
                a.SetActive(false);
            }
            foreach (GameObject d in destroy)
            {
                d.SetActive(true);
            }
        }
    }
}
