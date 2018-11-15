using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
	public Vector3 CurrentPosition
	{
		get{ return transform.position;}
		set{ transform.position = value;}
	}
}
