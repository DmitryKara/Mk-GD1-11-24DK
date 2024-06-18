using UnityEngine;

public class FootStepAudio : MonoBehaviour
{
    [SerializeField] private AudioSource footstepAudioSource;
    [SerializeField] private AudioClip footstepClip;
    [SerializeField] private float footstepVolume = 1.0f;

    private void Start()
    {
        footstepAudioSource.clip = footstepClip;
        footstepAudioSource.loop = true;
        footstepAudioSource.volume = footstepVolume;
    }

    public void PlayFootstep()
    {
        if (!footstepAudioSource.isPlaying)
        {
            footstepAudioSource.volume = footstepVolume;
            footstepAudioSource.Play();
        }
    }

    public void StopFootstep()
    {
        if (footstepAudioSource.isPlaying)
        {
            footstepAudioSource.Stop();
        }
    }
}
