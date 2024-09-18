using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPhotoCheck : MonoBehaviour
{
    public GameObject die;
    public GameObject wakeUp;
    private GameManager gameManager;
    private bool flag = false;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        for (int i = 0; i < gameManager.photos.Length; i++)
        {
            if (gameManager.photos[i] == false) 
            {
                flag = true;
                break; 
            }
        }
        if (flag) 
        { 
            die.SetActive(true);
            wakeUp.SetActive(false);
            return;
        }
        die.SetActive(false);
        wakeUp.SetActive(true);
    }
}
