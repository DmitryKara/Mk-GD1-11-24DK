using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusic : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private AudioSource audioSource;

    public void SwitchSound()
    {
        if (audioSource == null || audioClips.Length == 0)
        {
            Debug.LogWarning("AudioSource or AudioClip array is not assigned.");
            return;
        }

        AudioClip randomClip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.clip = randomClip;

        audioSource.Play();
    }
}
