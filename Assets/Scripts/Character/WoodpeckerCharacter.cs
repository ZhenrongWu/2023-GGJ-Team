using UnityEngine;

namespace GGJ.Characters
{
    public class WoodpeckerCharacter : BaseCharacter
    {
        [SerializeField] private AudioClip audioClip;

        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _audioSource.PlayOneShot(audioClip);
            }
        }
    }
}