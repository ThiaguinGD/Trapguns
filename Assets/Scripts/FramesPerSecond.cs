using TMPro;
using UnityEngine;

public class FramesPerSecond : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI display;
    [SerializeField] private string textBefore;
    private float fps, timer;
    private static FramesPerSecond instance;

    private void Awake()
    {
        instance = this;
        fps = 1f / Time.deltaTime;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 2)
        {
            fps = 1f / Time.deltaTime;
            if (display != null) display.text = !string.IsNullOrEmpty(textBefore) ? textBefore + " " + fps.ToString("0") : "FPS: " + fps.ToString("0");
            timer = 0;
        }
    }

    public static float Get()
    {
        return instance.fps;
    }
}