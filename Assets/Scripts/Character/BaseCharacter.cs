using UnityEngine;

namespace GGJ.Characters
{
    public class BaseCharacter : MonoBehaviour
    {
        //[Header("Setting"), SerializeField] LayerMask interactiveLayer;

        protected virtual void Awake()
        {
            Initialize();
        }

        protected virtual void Update()
        {
            PlayAnimation();
        }

        protected virtual void FixedUpdate()
        {

        }

        protected virtual void Initialize()
        {

        }

        protected virtual void PlayAnimation()
        {

        }

        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {

        }

        protected virtual void OnTriggerExit2D(Collider2D collision)
        {

        }
    }
}
