using GGJ.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Bird : Platform_Base
{
	[SerializeField] private float mWaitDownTime;
	[SerializeField] private float mFallDownSpeed;
	public Animation mAni;

	private void Awake()
	{
		mAni = GetComponent<Animation>() ==null ? gameObject.AddComponent<Animation>() :GetComponent<Animation>();
		mAni.Stop();
		mPlatform.bodyType = RigidbodyType2D.Kinematic;
	}
	IEnumerator FallDown () //On Trigger Todo it
	{
		yield return new WaitForSeconds(mWaitDownTime);
		mPlatform.bodyType = RigidbodyType2D.Dynamic;
		mAni.Play();
		mPlatform.gravityScale = 1; 
		Destroy(gameObject,1);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.GetComponent<Character>())
		{
			StartCoroutine(FallDown());
		}

        var Woodpecker = GetComponentInChildren<BaseCharacter>();
        if (Woodpecker != null)
        {
            Woodpecker.transform.SetParent(transform.parent);
        }
    }
}