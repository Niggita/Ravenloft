using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Кубическая кривая Безье - четыре точки
public struct CubicBezierCurve
{
	public Vector3 p0;
	public Vector3 p1;
	public Vector3 p2;
	public Vector3 p3;
}

//Квадратичная кривая Безье - три точки
public struct QuadraticBezierCurve
{
	public Vector3 p0;
	public Vector3 p1;
	public Vector3 p2;
}