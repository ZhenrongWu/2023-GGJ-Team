using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Bird : Platform_Base
{
	[SerializeField] private float mWaitDownTime;
	[SerializeField] private float mFallDownSpeed;

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