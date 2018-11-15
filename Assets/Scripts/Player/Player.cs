using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
	protected Camera playerCamera;

	protected void Update()
	{
		if (playerCamera != null) {
			playerCamera.transform.position = transform.position;
			playerCamera.transform.rotation = transform.rotation;
		}
	}

	public void BindCamera(Camera camera)
	{
		playerCamera = camera;
	}
}
