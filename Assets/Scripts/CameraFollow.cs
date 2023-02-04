using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ.Characters
{
	public class CameraFollow : MonoBehaviour
	{
		[SerializeField] private Character mCharacter;
		[SerializeField] private Vector2 mOffsetPos;
		private Camera mCamera;
		public float mSmoothSpeed = 0.25f;

		private void Awake()
		{
			mCharacter = FindAnyObjectByType<Character>();
			mCamera = Camera.main;
		}

		private void FixedUpdate()
		{
			Vector2 aDesiredPosition = new Vector2(mCamera.gameObject.transform.position.x, mCharacter.gameObject.transform.position.y) + mOffsetPos;
			Vector2 aSmoothPosition = Vector2.Lerp(mCamera.transform.position , aDesiredPosition , mSmoothSpeed);
			mCamera.transform.position = new Vector3( aSmoothPosition.x, aSmoothPosition.y,-10);
		}
	}
}