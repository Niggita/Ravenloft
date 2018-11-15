using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BatGenerator : MonoBehaviour 
{
	[SerializeField] 
	private List<GameObject> generatedObjects;

	[SerializeField]
	private GameObject parentObject;

	public List<Bat> CreateObjectsRandomly(Vector3 centralPosition, EnemyBoundaries enemyParams)
	{
		List<Bat> createdObjects = new List<Bat>();
		for (int i = 0; i < enemyParams.EnemyCount; i++) 
		{			
			createdObjects.Add (Instantiate (
				generatedObjects [Random.Range (0, generatedObjects.Count)],
				GenerationMath.RandomPositionAround(centralPosition, enemyParams),
				parentObject.transform.rotation,
				parentObject.transform).GetComponent<Bat> ()
			);
		}
		return createdObjects;
	}
}