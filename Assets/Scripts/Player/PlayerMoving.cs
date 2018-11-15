using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class PlayerMoving : MonoBehaviour 
{
	[SerializeField] private float speed;
	[SerializeField] private Transform objectTransform;

	private Vector3 direction;

	private void Update()
	{
		direction = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
		direction = transform.TransformDirection (direction);

		objectTransform.position = Vector3.MoveTowards (
			objectTransform.position,
			objectTransform.position + direction,
			speed * Time.deltaTime
		);
	}
}
