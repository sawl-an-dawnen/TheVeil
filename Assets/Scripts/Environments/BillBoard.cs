using Unity.VisualScripting;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    public float fadeSpeed = 1f;
    public float visibleDistance = 2f;
    public float offsetPercent = 5f;
    private SpriteRenderer sprite;
    private float originalAlpha;
    private float targetAlpha;
    bool fading, shining;
    private float distanceToPlayer;
    private Vector3 playerPosition;
    private Transform playerTransform;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        originalAlpha = sprite.color.a;
        targetAlpha = originalAlpha;
        fading = true;
        shining = false;
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(Camera.main.transform);

        playerPosition = playerTransform.position;
        distanceToPlayer = Mathf.Abs(Vector3.Magnitude(gameObject.transform.position - playerPosition));
        //Debug.Log(distanceToPlayer);

        if (distanceToPlayer < visibleDistance)
        {
            targetAlpha = (originalAlpha * (distanceToPlayer / visibleDistance));
            if (targetAlpha <= originalAlpha * offsetPercent * .01f) {
                targetAlpha = 0f;
            }
        }
        else 
        {
            targetAlpha = originalAlpha;
        }

        if (fading && sprite.color.a > 0)
        {
            sprite.color = new Color(255f, 255f, 255f, sprite.color.a - (Time.deltaTime * fadeSpeed));
        }
        else if (sprite.color.a <= 0) 
        {
            fading = false;
            shining = true;
        }
        if (shining && sprite.color.a < targetAlpha)
        {
            sprite.color = new Color(255f, 255f, 255f, sprite.color.a + (Time.deltaTime * fadeSpeed));
        }
        else if (sprite.color.a >= targetAlpha)
        {
            fading = true;
            shining = false;
        }
    }
}
