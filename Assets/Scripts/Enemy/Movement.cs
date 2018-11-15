using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement
{
	protected BezierLines bezierLines;

	protected float bezierPointPosition;

	protected Vector3 renewedPosition;
	protected Vector3 targetPosition;

	protected UniformMotion uniformMotion;

	protected Enemy thisEnemy;

	protected QuadraticBezierCurve createPathQuadratic(Vector3 start)
	{
		QuadraticBezierCurve quadraticCurve = bezierLines.CreateQuadraticLineDots (
			start, 
			GameControl.gameControl.PlayerInstance.CurrentPosition,
			GameControl.gameControl.BatBoundaries);
		bezierPointPosition = 0f;
		calculateMovementParameters (quadraticCurve);
		return quadraticCurve;
	}

	protected CubicBezierCurve createPathCubic(Vector3 start)
	{
		CubicBezierCurve cubicCurve = bezierLines.CreateCubicLineDots (
			start,
			targetPosition,
			GameControl.gameControl.BatBoundaries);
		bezierPointPosition = 0f;
		calculateMovementParameters (cubicCurve);
		return cubicCurve;
	}

	protected QuadraticBezierCurve updatePath(QuadraticBezierCurve curve)
	{
		bezierPointPosition = 0f;
		curve = bezierLines.NextDots (curve,
			targetPosition,
			GameControl.gameControl.BatBoundaries);
		renewedPosition = curve.p0;
		return curve;
	}

	protected CubicBezierCurve updatePath(CubicBezierCurve curve)
	{
		bezierPointPosition = 0f;
		curve = bezierLines.NextDots (curve,
			targetPosition,
			GameControl.gameControl.BatBoundaries);
		renewedPosition = curve.p0;
		return curve;
	}

	protected void calculateMovementParameters(QuadraticBezierCurve curve)
	{
		uniformMotion.Distance = bezierLines.ApproximateLineLength (curve);
		uniformMotion.Speed = thisEnemy.Speed;
		uniformMotion.GetTime ();
	}

	protected void calculateMovementParameters(CubicBezierCurve curve)
	{
		uniformMotion.Distance = bezierLines.ApproximateLineLength (curve);
		uniformMotion.Speed = thisEnemy.Speed;
		uniformMotion.GetTime ();
	}

	protected bool nextStepMovement()
	{
		bezierPointPosition +=
			1 / (uniformMotion.Time / Time.smoothDeltaTime);
		return bezierPointPosition > 1f ? true : false;
	}
		
	public Vector3 RenewedPosition
	{
		get{return renewedPosition;}
	}

	public Vector3 TargetPosition
	{
		get{return targetPosition;}
	}
}
