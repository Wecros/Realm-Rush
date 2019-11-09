using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotTaking : MonoBehaviour
{
    [SerializeField] KeyCode screenshotKey = KeyCode.C;
    int screenshotIndex = 0;
	
	// Update is called once per frame
	void Update()
    {
		if (Input.GetKeyDown(screenshotKey))
        {
            if (System.IO.File.Exists("Screenshot(" + screenshotIndex + ").png"))
            {
                screenshotIndex++;
            }
            ScreenCapture.CaptureScreenshot("Screenshot(" + screenshotIndex + ").png");
            screenshotIndex++;
        }
	}
}
