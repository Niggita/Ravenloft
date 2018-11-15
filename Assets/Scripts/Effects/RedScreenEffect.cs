using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class RedScreenEffect : MonoBehaviour 
{
	private Material material;
	private bool coroutineRunning;
	private float intensity;

	private float effectSpeed = 0.05f;
	private Coroutine effectCoroutine;

	void Awake ()
	{
		material = new Material( Shader.Find("Hidden/RedEffect") );
	}

	public void StartEffect()
	{
		if (coroutineRunning)
		{
			StopCoroutine (effectCoroutine);
			effectCoroutine = StartCoroutine (redBlink ());
		}
		else
			effectCoroutine = StartCoroutine (redBlink ());
	}

	private IEnumerator redBlink()
	{
		coroutineRunning = true;
		while (intensity < 1) 
		{
			intensity += effectSpeed;
			yield return null;
		}
		while (intensity > 0) 
		{
			intensity -= effectSpeed;
			yield return null;
		}
		coroutineRunning = false;
	}

	void OnRenderImage (RenderTexture source, RenderTexture destination)
	{
		material.SetFloat("_bwBlend", intensity);
		Graphics.Blit (source, destination, material);
	}

	public float EffectSpeed
	{
		get{ return effectSpeed;}
		set{ effectSpeed = value;}
	}
}