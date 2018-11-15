using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerRotating : MonoBehaviour
{
	[SerializeField] private float sensivity;
	[SerializeField] private float maxYAngle;
	[SerializeField] private Transform objectTransform;

	private Vector2 objectRotation;

	private void Update()
	{
		objectRotation.x += Input.GetAxis ("Mouse X") * sensivity;
		objectRotation.y -= Input.GetAxis ("Mouse Y") * sensivity;
		objectRotation.x = Mathf.Repeat (objectRotation.x, 360);
		objectRotation.y = Mathf.Clamp (objectRotation.y, -maxYAngle, maxYAngle);

		objectTransform.rotation = Quaternion.Euler (
			objectRotation.y,
			objectRotation.x,
			0
		);
	}
}