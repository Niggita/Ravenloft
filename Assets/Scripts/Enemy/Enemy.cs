using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
	[SerializeField] protected float speed;
	[SerializeField] protected Entity attackTarget;

	[SerializeField] protected float attackDecisionProbability;
	[SerializeField] protected float biteDuration;

	protected EnemyStates states;

	public Entity AttackTarget
	{
		get{ return attackTarget;}
		set{ attackTarget = value;}
	}

	public float Speed
	{
		get{ return speed;}
		set{ speed = value;}
	}

	public float AttackDecisionProbability
	{
		get{ return attackDecisionProbability;}
	}
}
