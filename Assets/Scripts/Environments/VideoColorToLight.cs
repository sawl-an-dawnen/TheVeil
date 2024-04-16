using UnityEngine;
using UnityEngine.Video;

public class VideoColorToLight : MonoBehaviour
{
    public Light targetLight;
    public VideoPlayer videoPlayer;
    private int sampleWidth;
    private int sampleHeight;
    private RenderTexture renderTexture;

    void Awake()
    {
        // Create a RenderTexture for sampling video frame
        renderTexture = videoPlayer.targetTexture;
        sampleWidth = renderTexture.width / 5;
        sampleHeight = renderTexture.height / 5;
    }

    void Update()
    {
        // Check if the video is playing
        if (videoPlayer.isPlaying)
        {
            // Sample the color from the video frame
            Color videoColor = SampleVideoColor();

            // Apply the color to the light
            targetLight.color = videoColor;
        }
    }

    Color SampleVideoColor()
    {
        // Set the active RenderTexture
        RenderTexture.active = renderTexture;

        // Create a new Texture2D and read the RenderTexture data
        Texture2D texture = new Texture2D(sampleWidth, sampleHeight);
        texture.ReadPixels(new Rect(0, 0, sampleWidth, sampleHeight), 0, 0);
        texture.Apply();

        // Reset the active RenderTexture
        //RenderTexture.active = null;

        // Get the average color from the sampled texture
        Color averageColor = Color.black;
        Color[] pixels = texture.GetPixels();
        foreach (Color pixel in pixels)
        {
            averageColor += pixel;
        }
        averageColor /= pixels.Length;

        // Dispose of the texture
        Destroy(texture);

        //Debug.Log(averageColor);

        return averageColor;
    }

    void OnDestroy()
    {
        // Clean up RenderTexture
        //renderTexture.Release();
    }
}
