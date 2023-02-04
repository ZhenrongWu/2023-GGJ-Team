using GGJ;
using GGJ.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Base : MonoBehaviour
{
	public Rigidbody2D    mPlatform    ;
	[HideInInspector] public SpriteRenderer mRender      ;
	[HideInInspector] public GameObject     mTreeLink    ;
	[SerializeField]  private string         Name_TreeLink = "TreeLink";
	[SerializeField]  private AudioClip?	mCollisionSE;

	private void Awake()
	{
		//mPlatform = GetComponent<Rigidbody2D>() == null ? gameObject.AddComponent<Rigidbody2D>() : GetComponent<Rigidbody2D>();
		mTreeLink = mTreeLink==null? transform.Find(Name_TreeLink).gameObject : mTreeLink;
	}

	public void FindTrunk()
	{
		mKnifeList = new List<float>();
		mKnifeMap = new Dictionary<float, GameObject>();

		GameObject[] aTrunks = GameObject.FindGameObjectsWithTag("Trunk");
		for(int aIndex = 0; aIndex< aTrunks.Length; aIndex++)
		{
			float aDis = Vector3.Distance(aTrunks[aIndex].transform.localPosition, transform.localPosition);
			mKnifeMap.Add(aDis, aTrunks[aIndex].gameObject);
			if(!mKnifeList.Contains(aDis))
			{
				mKnifeList.Add(aDis);
			}
		}
		mKnifeList.Sort();
		GameObject aTarget;
		mKnifeMap.TryGetValue(mKnifeList[0], out aTarget);
		//mTreeLink.gameObject.transform.position = new Vector2(aTarget.transform.position.x, mTreeLink.gameObject.transform.position.y);
	}

	private List<float> mKnifeList;
	private Dictionary<float, GameObject> mKnifeMap;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Character>())
        {
			if (mCollisionSE)
				SoundManager.Instance?.PlayOneShot(mCollisionSE);
        }
    }
}