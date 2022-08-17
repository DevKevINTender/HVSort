using UnityEngine;

namespace Components
{
    public class AudioCom : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        public void InitComponent(AudioClip clip)
        {
            audioSource.clip = clip;
            audioSource.Play();
            Destroy(gameObject,clip.length);
        }
    }
}