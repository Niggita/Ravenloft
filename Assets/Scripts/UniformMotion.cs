using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniformMotion
{
	private float speed;
	private float time;
	private float distance;

	public float Speed
	{
		get{return speed;}
		set{ speed = value;}
	}

	public float Time
	{
		get{return time;}
		set{ time = value;}
	}

	public float Distance
	{
		get{return distance;}
		set{ distance = value;}
	}

	public float GetSpeed()
	{
		speed = distance / time;
		return speed;
	}

	public float GetTime()
	{
		time = distance / speed;
		return time;
	}

	public float GetDistance()
	{
		distance = speed * time;
		return distance;
	}
}
