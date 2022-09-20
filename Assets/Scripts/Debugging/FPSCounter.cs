using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class FPSCounter : MonoBehaviour
{
    [SerializeField] float targetFramerate = 60f;
    private float lowFpsThreshold = 0f;
    private float highFpsThreshold = float.MaxValue;
    private TextMeshProUGUI tmp;
    private float fps;
    private float pollingTime = 0.1f;
    private float time;
    private int frameCount;

    private void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        lowFpsThreshold = 30 * targetFramerate / 100;
        highFpsThreshold = 70 * targetFramerate / 100;
    }
    private void Update()
    {
        time += Time.unscaledDeltaTime;
        frameCount++;
        if (time >= pollingTime)
        {
            fps = frameCount / time;

            time -= pollingTime;
            frameCount = 0;
        }
    }
    private void LateUpdate()
    {
        tmp.text = FormatFPS();
    }

    private string FormatFPS()
    {
        if (fps < lowFpsThreshold)
        {
            return $"<color=red>{fps:F1} FPS</color>";
        }
        if (fps < highFpsThreshold)
        {
            return $"<color=yellow>{fps:F1} FPS</color>";
        }
        return $"<color=green>{fps:F1} FPS</color>";
    }
}
