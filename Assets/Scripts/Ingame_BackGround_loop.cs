using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingame_BackGround_loop : MonoBehaviour
{
	public float mRollSpeed;
	private GameObject mRollObj;
	private Renderer mRollTexture;
	private void Awake()
	{
		mRollTexture = GetComponent<Renderer>() == null ? this.gameObject.AddComponent<Renderer>() : GetComponent<Renderer>();
	}
	private void FixedUpdate()
	{
		mRollTexture.material.mainTextureOffset = new Vector2(0, Time.time * mRollSpeed);
	}
}