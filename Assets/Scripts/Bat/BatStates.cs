using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatStates : EnemyStates
{
	protected override void InitializePatroilState (Enemy enemy)
	{
		base.InitializePatroilState (enemy);
	}

	protected override void InitializeAttackState (Enemy enemy)
	{
		base.InitializeAttackState (enemy);
	}

	protected override void InitializeDamageState (Enemy enemy)
	{
		base.InitializeDamageState (enemy);
	}

	public BatStates (Bat bat)
	{
		enemy = bat;
		InitializePatroilState (bat);
		InitializeAttackState (bat);
		InitializeDamageState (bat);

		enemyPatroil.StartAttack += StateAttack;

		enemyAttack.DamageTarget += StateDamage;

		enemyHit.HitFailed += StatePatroil;
		enemyHit.HitDone += bat.Bite;
		enemyHit.HitDone += StatePatroil;
	}

	protected override void StatePatroil ()
	{
		base.StatePatroil ();
		enemyPatroil.StartPatroil (enemy.CurrentPosition);
		((Bat)enemy).Fly ();
	}

	protected override void StateAttack ()
	{
		base.StateAttack ();
		enemyAttack.StartAttack (enemy.CurrentPosition);
		((Bat)enemy).Fly ();
	}

	protected override void StateDamage ()
	{
		base.StateDamage ();
	}

	public void Run()
	{
		StatePatroil ();
	}

	public override void StateUpdate ()
	{
		switch (enemyState)
		{
		case EnemyState.PATROIL:
			{
				enemyPatroil.DoAction (enemy);
				((Bat)enemy).EndPointLabel.transform.position = enemyPatroil.TargetPosition;
				break;
			}
		case EnemyState.ATTACK:
			{
				enemyAttack.DoAction (enemy);
				break;
			}
		case EnemyState.DAMAGE:
			{
				enemyHit.DoAction (enemy);
				break;
			}
		}
	}

	public void AttackTarget()
	{
		StateAttack ();
	}

	public void BiteDone()
	{
		StatePatroil ();
	}
}
