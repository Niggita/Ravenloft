using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class Bat : Enemy
{
	[SerializeField] protected GameObject endLabelPrefab;

	protected GameObject endLabel;
	protected EnemyPatroiling batPath;
	protected Vector3 temp;

	protected BatSounds sounds;

	public List<AudioClip> attackSounds;
	public List<AudioClip> moveSounds;
	public AudioSource batAudioSource;

	protected void Awake()
	{
		sounds = new BatSounds (this);
		states = new BatStates (this);

		endLabel = Instantiate (endLabelPrefab);
		StartCoroutine (StartWorking ());
	}

	protected void Update()
	{
		states.StateUpdate ();
	}

	protected IEnumerator StartWorking()
	{
		yield return new WaitForSeconds (Random.Range
		(
				GameControl.gameControl.BatBoundaries.MinStartTime,
				GameControl.gameControl.BatBoundaries.MaxStartTime
		));
		((BatStates)states).Run ();
	}

	public void Fly()
	{
		sounds.BatFly ();
	}

	public void AttackingScream()
	{
		sounds.BatAttack ();
	}

	public void Bite()
	{
		GameControl.gameControl.BloodyScreen ();
	}

	public GameObject EndPointLabel
	{
		get{return endLabel;}
	}
}