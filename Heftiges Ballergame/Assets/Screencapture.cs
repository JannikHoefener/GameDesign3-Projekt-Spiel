using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screencapture : MonoBehaviour
{
    public string filename;
    public int scale;

    // Start is called before the first frame update
    void Start()
    {
        ScreenCapture.CaptureScreenshot(filename, scale);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
