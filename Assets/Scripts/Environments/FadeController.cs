using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class FadeController : MonoBehaviour
{
    public float fadeInTime = 5f;
    public float fadeOutTime = 5f;
    public Texture textureOverride = null;
    [HideInInspector]
    public bool fading = false;
    private RawImage image;

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
        StartCoroutine(Fade(1f, 0f, fadeInTime));
    }

    public void FadeOut() {
        fading = true;
        StartCoroutine(Fade(0f, 1f, fadeOutTime));
    }

    private IEnumerator Fade(float start, float target, float overTime)
    {
        float startTime = Time.time;
        while (Time.time < startTime + overTime)
        {
            image.color = new Color(0f, 0f, 0f, Mathf.Lerp(start, target, (Time.time - startTime) / overTime));
            yield return null;
        }
        fading = false;
    }
}
