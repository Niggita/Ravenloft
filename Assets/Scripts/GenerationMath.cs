using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GenerationMath
{
	//Возвращает позицию объекта относительно игрока с учетом определенных границ 
	public static Vector3 RandomPositionAround(Vector3 centralPosition, EnemyBoundaries enemyParams)
	{
		Vector3 position = new Vector3 ();

		var alpha = Random.Range (-Mathf.PI, Mathf.PI);

		position.x = 
			centralPosition.x + 
			Random.Range (enemyParams.InnerRadius, enemyParams.OuterRadius) *
			Mathf.Cos(alpha);

		position.z = 
			centralPosition.z + 
			Random.Range (enemyParams.InnerRadius, enemyParams.OuterRadius) *
			Mathf.Sin(alpha);

		position.y = Random.Range (enemyParams.MinHeight, enemyParams.MaxHeight);

		return position;
	}
	//Возвращает позицию объекта внутри цилиндра заданного радиуса и высотой по определенным границам
	public static Vector3 RandomPositionInCylinder(Vector3 center, float radius, EnemyBoundaries boundaries)
	{
		Vector3 position = new Vector3 ();

		var alpha = Random.Range (-Mathf.PI, Mathf.PI);

		position.x = 
			center.x + 
			Random.Range (0, radius) *
			Mathf.Cos(alpha);

		position.z = 
			center.z + 
			Random.Range (0, radius) *
			Mathf.Sin(alpha);

		position.y = Random.Range (boundaries.MinHeight, boundaries.MaxHeight);

		return position;
	}
	//Возвращает позицию объекта на поверхности цилиндра заданного радиуса и высотой по определенным границам
	public static Vector3 RandomPositionOnCylinder(Vector3 center, float radius, EnemyBoundaries boundaries)
	{
		Vector3 position = new Vector3 ();

		var alpha = Random.Range (-Mathf.PI, Mathf.PI);

		position.x = 
			center.x + 
			radius * Mathf.Cos(alpha);

		position.z = 
			center.z + 
			radius * Mathf.Sin(alpha);

		position.y = Random.Range (boundaries.MinHeight, boundaries.MaxHeight);

		return position;		
	}
}
