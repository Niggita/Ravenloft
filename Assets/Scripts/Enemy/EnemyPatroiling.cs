using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.ConstrainedExecution;
using UnityEditor;

public class EnemyPatroiling : Movement, IEntityAction
{
	private CubicBezierCurve cubicCurve;

	public OnStartAction StartAttack;

	protected virtual void InitializeEnemyPath(Vector3 start)
	{
		cubicCurve = createPathCubic (start);
	}

	protected virtual void SetLabelPosition()
	{
		targetPosition = GenerationMath.RandomPositionAround(
			GameControl.gameControl.PlayerInstance.CurrentPosition,
			GameControl.gameControl.BatBoundaries
		);
	}

	protected virtual void attackDecision(Enemy enemy)
	{
		if (Random.Range (0f, 1f) > enemy.AttackDecisionProbability) 
		{
			StartAttack ();
		}
	}

	public EnemyPatroiling(Enemy enemy)
	{
		bezierLines = new BezierLines ();
		uniformMotion = new UniformMotion ();
		thisEnemy = enemy;
	}

	public virtual void StartPatroil(Vector3 currentPosition)
	{
		SetLabelPosition ();
		InitializeEnemyPath (currentPosition);
	}

	public virtual void DoAction(Enemy enemy)
	{
		bool wayDone = nextStepMovement ();
		if (wayDone) {
			SetLabelPosition ();
			updatePath (cubicCurve);
			attackDecision (enemy);
		} 
		else 
		{
			renewedPosition = bezierLines.CalculateBezierPoint (
				bezierPointPosition,
				cubicCurve);
			enemy.transform.LookAt (renewedPosition);
			enemy.CurrentPosition = renewedPosition;
		}
	}
}
