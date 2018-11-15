using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using CompilerGenerated;

public class EntryPoint : MonoBehaviour 
{
	[SerializeField] private Camera mainCamera;
	[SerializeField] private Canvas mainCanvas;

	[SerializeField] private GameObject gameControlPrefab;
	[SerializeField] private GameObject generatorPrefab;
	[SerializeField] private GameObject playerPrefab;

	private GameControl gameControl;
	private BatGenerator generator;
	private Player player;

	private void Start()
	{
		gameControl = Instantiate (gameControlPrefab).GetComponent<GameControl> ();
		generator = Instantiate (generatorPrefab).GetComponent<BatGenerator> ();
		player = Instantiate (playerPrefab).GetComponent<Player> ();

		gameControl.EnemyGenerator = generator;
		gameControl.PlayerInstance = player;
		gameControl.MainCamera = mainCamera;

		gameControl.redScreenEffect = mainCamera.gameObject.AddComponent <RedScreenEffect>();
	}
}
