using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Bird : MonoBehaviour
{
	[SerializeField] private float mWaitDownTime;
	[SerializeField] private float mFallDownSpeed;
	private Rigidbody2D mPlatform;
	
	private void Awake()
	{
		mPlatform = GetComponent<Rigidbody2D>() == null ? gameObject.AddComponent<Rigidbody2D>() : GetComponent<Rigidbody2D>();
	}

	IEnumerator FallDown () //On Trigger Todo it
	{
		yield return new WaitForSeconds(mWaitDownTime);
		mPlatform.gravityScale += mFallDownSpeed;
	}

	private void Start()
	{
		//test trigger
		StartCoroutine(FallDown());
	}
}