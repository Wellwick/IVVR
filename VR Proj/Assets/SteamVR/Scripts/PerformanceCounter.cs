using UnityEngine;
using System.Collections.Generic;

public class PerformanceCounter : MonoBehaviour
{
    public int FrameQueueSize;

    Queue<float> frameTimes;
    float deltaTime = 0.0f;

    float minfps = 300;
    float maxfps = 0;

    float fps2;

    void Start() {
        frameTimes = new Queue<float>();
    }

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;

        frameTimes.Enqueue(Time.time);

        float firstFrame = frameTimes.Peek();

        if (frameTimes.Count > FrameQueueSize) {
            firstFrame = frameTimes.Dequeue();
            fps2 = (frameTimes.Count) / (Time.time - firstFrame);
            if (fps2 < minfps)  {
                minfps = fps2;
            }
            if (fps2 > maxfps)
            {
                maxfps = fps2;
            }
        }

    }

    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 100;
        style.normal.textColor = new Color(1.0f, 1.0f, 0.25f, 1.0f);
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps), ({2:0.} fps)", msec, fps, fps2);
        //text = text + "\n" + string.Format("min/max {0:0.}/{1:0.} fps", minfps, maxfps);
        GUI.Label(rect, text, style);
    }
}