using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatSounds
{
	private Bat thisBat;

	public BatSounds(Bat bat)
	{
		thisBat = bat;
	}

	public void BatAttack()
	{
		thisBat.batAudioSource.PlayOneShot 
		(
			thisBat.attackSounds[Random.Range (0, thisBat.attackSounds.Count)]
		);
	}

	public void BatFly()
	{
		thisBat.batAudioSource.clip = thisBat.moveSounds [Random.Range (0, thisBat.moveSounds.Count)];
		thisBat.batAudioSource.Play();		
	}
}