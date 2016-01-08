using UnityEngine;
using System.Collections;

public class SimpleWrap : MonoBehaviour {

	Renderer[] renderers;

    bool isWrappingX = false;
    bool isWrappingY = false;

    float screenWidth;
    float screenHeight;

	// Use this for initialization
	void Start () {
        renderers = GetComponentsInChildren<Renderer>();
        var cam = Camera.main;

        var screenBottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, transform.position.z));
        var screenTopRight = cam.ViewportToWorldPoint(new Vector3(1, 1, transform.position.z));

        screenWidth = screenTopRight.x - screenBottomLeft.x;
        screenHeight = screenTopRight.y - screenBottomLeft.y;
	}
	
	// Update is called once per frame
	void Update () {
        ScreenWrap();
	}

    void ScreenWrap()
    {
        foreach (var renderer in renderers)
        {
            if (renderer.isVisible)
            {
                isWrappingX = false;
                isWrappingY = false;
                return;
            }
        }
        if (isWrappingX && isWrappingY)
        {
            return;
        }
        var cam = Camera.main;
        var newPosition = transform.position;
        var viewportPosition = cam.WorldToViewportPoint(transform.position);

        if (!isWrappingX && (viewportPosition.x > 1 || viewportPosition.x < 0))
        {
            newPosition.x = -newPosition.x;
            isWrappingX = true;
        }
        if (!isWrappingY && (viewportPosition.y > 1 || viewportPosition.y < 0))
        {
            newPosition.y = -newPosition.y;

            isWrappingY = true;
        }
        transform.position = newPosition;

    }
}
