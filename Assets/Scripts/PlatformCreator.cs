using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCreator : MonoBehaviour
{
	#region UIs
	[SerializeField] private Transform mPlatformParent;
	
	#endregion

	#region Parameter
	//public
	[SerializeField] private Vector2 mXposOutLimit;
	[SerializeField] private Vector2 mXposInLimit ;
	[SerializeField] private Vector2 mYposLimit   ;
	[SerializeField] private float   mYposRang    = 1;
	[SerializeField] private int mPlatformPoolLimit = 10;
	[SerializeField] private float mInstantiateIntervals = 1.0f;

	//private
	private List<Platform_Base> mPlatformList;
	[SerializeField]private List<Platform_Base> mPlatformPool;

	#endregion


	private void Start()
	{
		for(int aIndex = (int)mYposLimit.x; aIndex<=(int)mYposLimit.y; aIndex++)
		{
			InstantiatePlatform();
		}
	}

	private void Awake()
	{
		mPlatformList = new List<Platform_Base>();
		mPlatformPool = new List<Platform_Base>();
		mPlatformParent = mPlatformParent == null ? this.gameObject.transform : mPlatformParent;
		GetAllPlatform();
	}

	private void GetAllPlatform()
	{
		var aPlatform = Resources.LoadAll<Platform_Base>("PlatformPrefab");
		foreach (var aitem in aPlatform)
		{
			mPlatformList.Add(aitem);
		}
	}
	private void InstantiatePlatform()
	{
		if(RanBool())
		{
			var iRanPos = RandomInstantiatePos(mXposOutLimit)[RanBool()?0:1];
			Vector2 aNewV2 = new Vector2(iRanPos, mYposLimit.x+mYpos);
			var iRanCount = Random.Range(0, mPlatformList.Count);
			Platform_Base aPlatform = Instantiate(mPlatformList[iRanCount], aNewV2, Quaternion.identity, mPlatformParent);
			if (aPlatform.transform.position.x > 0)
			{
				SpriteFlip(aPlatform);
			}
			aPlatform.FindTrunk();
			mPlatformPool.Add(aPlatform);
		}
		else
		{
			foreach (var aPos in RandomInstantiatePos(mXposOutLimit))
			{
				Vector2 aNewV2 = new Vector2(aPos, mYposLimit.x+ mYpos);
				var iRanCount = Random.Range(0, mPlatformList.Count);
				Platform_Base aPlatform = Instantiate(mPlatformList[iRanCount], aNewV2, Quaternion.identity, mPlatformParent);
				if (aPlatform.transform.position.x > 0)
				{
					SpriteFlip(aPlatform);
				}
				aPlatform.FindTrunk();
				mPlatformPool.Add(aPlatform);
			}
		}
		mYpos++;
		//PoolUpdate();
	}

	private void PoolUpdate()
	{
		for (int iIndex = 0; iIndex < mPlatformPool.Count - mPlatformPoolLimit; iIndex++)
		{
			if (mPlatformPool.Count > mPlatformPoolLimit)
			{
				Destroy(mPlatformPool[0].gameObject);
				mPlatformPool.RemoveAt(0);
			}
		}
	}

	private List<float> RandomInstantiatePos(Vector2 iOutLimit)
	{
		List<float> aList = new List<float>();
		if(iOutLimit.x > iOutLimit.y)
		{
			aList.Add((Random.Range(mXposInLimit.y, iOutLimit.x)));
			aList.Add((Random.Range(mXposInLimit.x,iOutLimit.y)));
		}
		else
		{
			aList.Add((Random.Range(mXposInLimit.x, iOutLimit.x)));
			aList.Add((Random.Range(mXposInLimit.y, iOutLimit.y)));
		}
		return aList;
	}

	private void SpriteFlip( Platform_Base iPlatform)
	{
		var aScale = iPlatform.transform.localScale;
		iPlatform.transform.localScale =new Vector3 (-aScale.x, aScale.y, aScale.z);
	}

	private bool RanBool()
	{
		return Random.Range(0, 2) == 1 ? false : true;
	}

	private float mYpos;
}