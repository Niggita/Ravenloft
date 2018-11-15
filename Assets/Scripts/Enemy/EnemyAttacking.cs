using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacking : Movement, IEntityAction 
{
	private QuadraticBezierCurve quadraticCurve;

	public OnStartAction DamageTarget;

	protected virtual void InitializeAttack(Vector3 start)
	{
		targetPosition = GameControl.gameControl.PlayerInstance.CurrentPosition;
		do
		{
			quadraticCurve = createPathQuadratic (start);
		}
		while(Vector3.Angle (
			quadraticCurve.p1 - start,
			targetPosition - start)
			< 45f);
	}

	public EnemyAttacking(Enemy enemy)
	{
		bezierLines = new BezierLines ();
		uniformMotion = new UniformMotion ();
		thisEnemy = enemy;
	}

	public virtual void StartAttack(Vector3 currentPosition)
	{
		InitializeAttack (currentPosition);
	}

	public virtual void DoAction(Enemy enemy)
	{
		bool wayDone = nextStepMovement ();
		if (wayDone) 
		{
			//Bite the player
			DamageTarget ();
		}
		else 
		{
			renewedPosition = bezierLines.CalculateBezierPoint (
				bezierPointPosition,
				quadraticCurve);
			enemy.transform.LookAt (renewedPosition);
			enemy.CurrentPosition = renewedPosition;
		}
	}
}
