using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class FadeController : MonoBehaviour
{
    public float fadeInTime = 5f;
    public float fadeOutTime = 5f;
    public Texture textureOverride = null;
    public bool cursorLocked = true;
    public bool fading = false;
    private RawImage image;
    private IEnumerator couroutine;

    private void Awake()
    {
        image = gameObject.GetComponent<RawImage>();
        image.texture = textureOverride;
    }
    void Start()
    {
        FadeIn();
    }

    public void FadeIn() {

        fading = true;
        couroutine = Fade(1f, 0f, fadeInTime);
        StartCoroutine(couroutine);
    }

    public void FadeOut() {
        if (!cursorLocked) 
        {
            Cursor.lockState = CursorLockMode.None;
        }
        StopCoroutine(couroutine);
        fading = true;
        couroutine = Fade(0f, 1f, fadeInTime);
        StartCoroutine(couroutine);
    }

    private IEnumerator Fade(float start, float target, float overTime)
    {
        float colorOverride = (textureOverride != null) ? 1f : 0f;
        float startTime = Time.time;
        while (Time.time < startTime + overTime)
        {
            image.color = new Color(colorOverride, colorOverride, colorOverride, Mathf.Lerp(start, target, (Time.time - startTime) / overTime));
            yield return null;
        }
        fading = false;
    }
}
