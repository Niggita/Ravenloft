using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : IEntityAction 
{
	public OnStartAction HitDone;
	public OnStartAction HitFailed;

	public EnemyHit(Enemy enemy){}

	public void DoAction(Enemy enemy)
	{
		var distanceToTarget = Vector3.Distance (
			enemy.CurrentPosition,
			enemy.AttackTarget.CurrentPosition
		);
		if (distanceToTarget < 0.1f)
			HitDone ();
		else
			HitFailed ();
	}
}
