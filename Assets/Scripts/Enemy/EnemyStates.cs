using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityScript.Scripting.Pipeline;

public abstract class EnemyStates
{
	protected Enemy enemy;

	protected enum EnemyState
	{
		PATROIL,
		ATTACK,
		DAMAGE,
	}

	protected EnemyState enemyState;
	protected EnemyPatroiling enemyPatroil;
	protected EnemyAttacking enemyAttack;
	protected EnemyHit enemyHit;

	public abstract void StateUpdate();

	protected virtual void InitializePatroilState (Enemy enemy)
	{
		if(enemyPatroil == null)
			enemyPatroil = new EnemyPatroiling (enemy);
	}

	protected virtual void InitializeAttackState (Enemy enemy)
	{
		if(enemyAttack == null)
			enemyAttack = new EnemyAttacking (enemy);
	}
	protected virtual void InitializeDamageState (Enemy enemy)
	{
		if(enemyHit == null)
			enemyHit = new EnemyHit (enemy);
	}

	protected virtual void setState(EnemyState state)
	{
		enemyState = state;
	}

	protected virtual void StatePatroil()
	{
		setState (EnemyState.PATROIL);
	}

	protected virtual void StateAttack()
	{
		setState (EnemyState.ATTACK);
	}

	protected virtual void StateDamage()
	{
		setState (EnemyState.DAMAGE);
	}
}
