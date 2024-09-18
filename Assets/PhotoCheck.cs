using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PhotoCheck : MonoBehaviour
{
    public int id;
    private GameManager gameManager;
    private RawImage image;

    public void Awake() 
    {
        image = gameObject.GetComponent<RawImage>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        if (gameManager.photos[id] == true)
        {
            image.color = new Color(255,255,255,255);
        }
        else 
        {
            image.color = new Color(0,0,0,0);
        }
    }
}
