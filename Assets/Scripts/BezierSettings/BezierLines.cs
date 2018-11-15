using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierLines
{
	//Возвращает четыре точки, нужные для построения кубической кривой Безье
	public CubicBezierCurve CreateCubicLineDots(Vector3 startPosition, Vector3 finishPosition, EnemyBoundaries boundaries)
	{
		CubicBezierCurve cubicCurve = new CubicBezierCurve ();
		cubicCurve.p0 = startPosition;
		cubicCurve.p1 = GenerationMath.RandomPositionInCylinder (
			startPosition,
			Vector3.Distance (startPosition, finishPosition),
			boundaries);
		cubicCurve.p3 = finishPosition;
		cubicCurve.p2 = GenerationMath.RandomPositionInCylinder (
			finishPosition,
			Vector3.Distance (startPosition, finishPosition),
			boundaries);
		return cubicCurve;
	}
	//Возвращает три точки, нужные для построения квадратичной кривой Безье
	public QuadraticBezierCurve CreateQuadraticLineDots(Vector3 startPosition, Vector3 finishPosition, EnemyBoundaries boundaries)
	{
		QuadraticBezierCurve quadraticCurve = new QuadraticBezierCurve ();
		quadraticCurve.p0 = startPosition;
		quadraticCurve.p1 = GenerationMath.RandomPositionOnCylinder (
			startPosition,
			Vector3.Distance (startPosition, finishPosition),
			boundaries);
		quadraticCurve.p2 = finishPosition;
		return quadraticCurve;
	}
	//Возвращает следующий сегмент кубической кривой Безье,
	//Зависящий от предыдущего
	public CubicBezierCurve NextDots(CubicBezierCurve oldSettings, Vector3 nextPosition, EnemyBoundaries boundaries)
	{
		CubicBezierCurve cubicCurve = new CubicBezierCurve ();

		cubicCurve.p0 = oldSettings.p3;
		cubicCurve.p1 = oldSettings.p2;

		cubicCurve.p3 = nextPosition;
		cubicCurve.p2 = GenerationMath.RandomPositionInCylinder (
			cubicCurve.p3,
			Vector3.Distance (cubicCurve.p0, nextPosition),
			boundaries);
		return cubicCurve;
	}
	//Возвращает следующий сегмент квадратичной кривой Безье,
	//Зависящий от предыдущего
	public QuadraticBezierCurve NextDots(QuadraticBezierCurve oldSettings, Vector3 nextPosition, EnemyBoundaries boundaries)
	{
		QuadraticBezierCurve quadraticCurve = new QuadraticBezierCurve ();

		quadraticCurve.p0 = oldSettings.p2;

		quadraticCurve.p2 = nextPosition;
		quadraticCurve.p1 = GenerationMath.RandomPositionInCylinder (
			quadraticCurve.p2,
			Vector3.Distance (quadraticCurve.p0, nextPosition),
			boundaries);
		return quadraticCurve;
	}
	//Рассчитывает следующую точку кубической кривой Безье по заданным точкам
	public Vector3 CalculateBezierPoint(float t, CubicBezierCurve curve)
	{
		Vector3 position = new Vector3();
		position = 
			Mathf.Pow(1f - t, 3) * curve.p0 +
			3f * Mathf.Pow(1f - t, 2) * t * curve.p1 +
			3f * (1f - t) * Mathf.Pow(t, 2) * curve.p2 +
			Mathf.Pow(t, 3) * curve.p3;
		return position;
	}
	//Рассчитывает следующую точку квадратичной кривой Безье по заданным точкам
	public Vector3 CalculateBezierPoint(float t, QuadraticBezierCurve curve)
	{
		Vector3 position = new Vector3();
		position = 
			Mathf.Pow (1f - t, 2) * curve.p0 +
			(1f - t) * 2 * t * curve.p1 +
			Mathf.Pow (t, 2) * curve.p2;
		return position;		
	}
	//Высчитывает приблизительную длину кубической кривой Безье
	public float ApproximateLineLength(CubicBezierCurve curve)
	{
		float length = 0f;
		Vector3 point1 = curve.p0;
		Vector3 point2;
		for(float i = 0.05f; i < 1f; i += 0.05f)
		{
			point2 = CalculateBezierPoint (i, curve);
			length += Vector3.Distance (point1, point2);
			point1 = point2;
		}
		return length;
	}
	//Высчитывает приблизительную длину квадратичной кривой Безье
	public float ApproximateLineLength(QuadraticBezierCurve curve)
	{
		float length = 0f;
		Vector3 point1 = curve.p0;
		Vector3 point2;
		for(float i = 0.05f; i < 1f; i += 0.05f)
		{
			point2 = CalculateBezierPoint (i, curve);
			length += Vector3.Distance (point1, point2);
			point1 = point2;
		}
		return length;
	}
}
