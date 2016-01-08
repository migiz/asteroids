using UnityEngine;
using System.Collections;

public class ScreenWrap : MonoBehaviour {

	Renderer[] renderers;

	bool isWrappingX = false;
	bool isWrappingY = false;

	Transform[] ghosts = new Transform[8];

	float screenWidth;
	float screenHeight;

	// Use this for initialization
	void Start () {
		renderers = GetComponentsInChildren<Renderer>();
		var cam = Camera.main;

		var screenBottomLeft = cam.ViewportToWorldPoint(new Vector2(0, 0));
		var screenTopRight = cam.ViewportToWorldPoint(new Vector2(1, 1));

		screenWidth = screenTopRight.x - screenBottomLeft.x;
		screenHeight = screenTopRight.y - screenBottomLeft.y;

		CreateGhostShips();
	}
	
	// Update is called once per frame
	void Update () {
		Wrap();
	}

	void CreateGhostShips() {

		for (int i = 0; i < 8; i++)
		{
			ghosts[i] = Instantiate(transform, Vector2.zero, Quaternion.identity) as Transform;
			DestroyImmediate(ghosts[i].GetComponent<ScreenWrap>());
		}
		PositionGhostShips();
	}
	void Wrap()
	{
		var isVisible = false;
		foreach (var renderer in renderers)
		{
			if (renderer.isVisible)
			{
				isVisible = true;
				break;
			}
		}
		if (!isVisible)
		{
			SwapShips();
		}
	}

	void SwapShips()
	{
		foreach(var ghost in ghosts)
		{
			if (ghost.position.x < screenWidth && ghost.position.x > -screenWidth &&
				ghost.position.y < screenHeight && ghost.position.y > -screenHeight)
			{
				transform.position = ghost.position;
				break;
			}
		}
		PositionGhostShips();
	}

	void PositionGhostShips()
	{
		var ghostPosition = transform.position;

		//Right
		ghostPosition.x = transform.position.x + screenWidth;
		ghostPosition.y = transform.position.y;
		ghosts[0].position = ghostPosition;

		// Bottom-right
		ghostPosition.x = transform.position.x + screenWidth;
		ghostPosition.y = transform.position.y - screenHeight;
		ghosts[1].position = ghostPosition;

		// Bottom
		ghostPosition.x = transform.position.x;
		ghostPosition.y = transform.position.y - screenHeight;
		ghosts[2].position = ghostPosition;

		// Bottom-left
		ghostPosition.x = transform.position.x - screenWidth;
		ghostPosition.y = transform.position.y - screenHeight;
		ghosts[3].position = ghostPosition;

		// Left
		ghostPosition.x = transform.position.x - screenWidth;
		ghostPosition.y = transform.position.y;
		ghosts[4].position = ghostPosition;

		// Top-left
		ghostPosition.x = transform.position.x - screenWidth;
		ghostPosition.y = transform.position.y + screenHeight;
		ghosts[5].position = ghostPosition;

		// Top
		ghostPosition.x = transform.position.x;
		ghostPosition.y = transform.position.y + screenHeight;
		ghosts[6].position = ghostPosition;

		// Top-right
		ghostPosition.x = transform.position.x + screenWidth;
		ghostPosition.y = transform.position.y + screenHeight;
		ghosts[7].position = ghostPosition;

		for (int i = 0; i < 8; i++)
		{
			ghosts[i].rotation = transform.rotation;
		}
	}
}
