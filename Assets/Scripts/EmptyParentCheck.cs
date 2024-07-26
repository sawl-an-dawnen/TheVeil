using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyParentCheck : MonoBehaviour
{
    public enum PromptID { One, Two, Three }

    public GameObject parentObject; //objects to collect
    public GameObject[] toActive; //once we've collected all the objs we active this array;
    public GameObject[] toDelete;

    // Update is called once per frame
    void Update()
    {
        if (parentObject.transform.childCount == 0)
        {
            foreach (GameObject obj in toActive)
            {
                obj.SetActive(true);
            }
            foreach (GameObject obj in toDelete)
            {
                Destroy(obj);
            }
            Destroy(this);
        }
    }
}
