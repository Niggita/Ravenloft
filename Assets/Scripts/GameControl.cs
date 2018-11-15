using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.LowLevel;
using System.Security.Cryptography.X509Certificates;

public class GameControl : MonoBehaviour {

	private BatGenerator enemyGenerator;
	private Player player;
	private Camera mainCamera;
	private List<Bat> bats;

	public RedScreenEffect redScreenEffect;

	private EnemyBoundaries batBoundaries = new EnemyBoundaries
	{
		EnemyCount = 100,
		InnerRadius = 2f,
		OuterRadius = 5f,
		MaxHeight = 2f,
		MinHeight = 0f,
		MinStartTime = 0.5f,
		MaxStartTime = 5f
	};

	public static GameControl gameControl;

	private void Awake()
	{
		if (gameControl == null)
			gameControl = this;
		else if (gameControl == this)
			Destroy (gameObject);
		DontDestroyOnLoad (gameObject);
	}

	private void Start()
	{
		bats = enemyGenerator.CreateObjectsRandomly (
			mainCamera.transform.position,
			batBoundaries);

		bats.ForEach (bat => bat.AttackTarget = player);

		player.BindCamera (mainCamera);
	}

	public BatGenerator EnemyGenerator
	{
		get{ return enemyGenerator;}
		set{ enemyGenerator = value;}
	}

	public Player PlayerInstance
	{
		get{ return player;}
		set{ player = value;}
	}

	public Camera MainCamera
	{
		get{return mainCamera;}
		set{ mainCamera = value;}
	}

	public EnemyBoundaries BatBoundaries
	{
		get{ return batBoundaries;}
	}

	public void BloodyScreen()
	{
		redScreenEffect.StartEffect ();
	}
}
