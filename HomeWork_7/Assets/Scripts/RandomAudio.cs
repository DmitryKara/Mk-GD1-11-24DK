using System.Collections.Generic;
using UnityEngine;

public class RandomAudio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<AudioClip> audioClips;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        PlayRandomClip();
    }

    public void PlayRandomClip()
    {
        if (audioClips.Count > 0)
        {
            int randomIndex = Random.Range(0, audioClips.Count);
            audioSource.clip = audioClips[randomIndex];
            audioSource.loop = true;
            audioSource.Play();
        }
    }
}
