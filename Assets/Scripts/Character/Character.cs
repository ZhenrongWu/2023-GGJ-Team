#nullable enable
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ.Characters
{
    public class Character : BaseCharacter
    {
        [SerializeField]         GameObject? model;
        [SerializeField] private Transform[] spawnPoints;

        [Space(15)]
        [SerializeField] float speed = 1f;

        [SerializeField] float     minMoveThreshold = -.1f;
        [SerializeField] float     maxMoveThreshold = .1f;
        [SerializeField] LayerMask groundLayer;

        Vector2      movement;
        Rigidbody2D? _rigidbody2D;
        Animator?    _animator;

        private readonly int MoveSpeed = Animator.StringToHash("MoveSpeed");
        private readonly int Fall      = Animator.StringToHash("Fall");

        protected override void Initialize()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _animator    = model?.GetComponent<Animator>();

            int randomNumber = Random.Range(0, 2);
            if (randomNumber == 0)
            {
                model!.transform.localScale = new Vector3(-.05f, .05f, 1); 
                transform.position         = spawnPoints[0].position;
            }
            else
            {
                model!.transform.localScale = new Vector3(.05f, .05f, 1); 
                transform.position         = spawnPoints[1].position;
            }
        }

        protected override void FixedUpdate()
        {
#if UNITY_EDITOR
            DebugMove();
#endif
            Move();
            FlipCharacter();
        }

#if UNITY_EDITOR
        public void DebugMove()
        {
            float horizontal = Input.GetAxis("Horizontal");
            if (horizontal != 0f)
            {
                AppendVelocityX(horizontal);
            }
        }
#endif

        public void Move()
        {
            if (_rigidbody2D == null)
                return;

            if (maxMoveThreshold > movement.x && movement.x > minMoveThreshold)
                return;

            _rigidbody2D.velocity = new Vector2(movement.x * speed, _rigidbody2D.velocity.y);
        }

        public void AppendVelocityX(float value)
        {
            if (!IsGround())
                return;
            movement.x = value;
        }

        public void AddForce(Vector2 force)
        {
            if (_rigidbody2D == null)
                return;
            _rigidbody2D.AddForce(force);
        }

        public void SetSpeed(float value)
        {
            speed = value;
        }

        public void ResetVelocity()
        {
            if (_rigidbody2D == null)
                return;
            movement              = Vector2.zero;
            _rigidbody2D.velocity = Vector2.zero;
        }

        public void FlipCharacter()
        {
            if (model == null || _rigidbody2D == null)
                return;

            Vector2 localScale = model.transform.localScale;
            localScale.x               = movement.x > 0f ? Mathf.Abs(localScale.x) : -Mathf.Abs(localScale.x);
            model.transform.localScale = localScale;
        }

        public bool HasMove()
            => !(maxMoveThreshold > movement.x && movement.x > minMoveThreshold);

        public bool IsGround()
            => Physics2D.Raycast(transform.position, Vector2.down, .1f, groundLayer).collider != null;

        protected override void PlayAnimation()
        {
            if (_animator == null)
                return;

            _animator.SetFloat(MoveSpeed, HasMove() ? Mathf.Abs(movement.x) : 0f);
            _animator.SetBool(Fall, !IsGround());
        }
    }
}