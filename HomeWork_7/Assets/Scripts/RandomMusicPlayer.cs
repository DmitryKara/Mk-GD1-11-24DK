using System.Collections;
using UnityEngine;

public class RandomMusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource1;
    [SerializeField] private AudioSource audioSource2;
    [SerializeField] private AudioClip[] musicClips;
    [SerializeField] private float crossfadeDuration = 2.0f;

    private int currentClipIndex = -1;
    private bool isPlayingSource1 = true;

    private void Start()
    {
        if (musicClips.Length > 0)
        {
            PlayRandomClip();
        }
    }

    private void PlayRandomClip()
    {
        int nextClipIndex;

        do
        {
            nextClipIndex = Random.Range(0, musicClips.Length);
        }
        while (nextClipIndex == currentClipIndex);

        currentClipIndex = nextClipIndex;
        AudioClip nextClip = musicClips[currentClipIndex];

        StartCoroutine(Crossfade(nextClip));
    }

    private IEnumerator Crossfade(AudioClip nextClip)
    {
        AudioSource activeSource = isPlayingSource1 ? audioSource1 : audioSource2;
        AudioSource newSource = isPlayingSource1 ? audioSource2 : audioSource1;

        newSource.clip = nextClip;
        newSource.Play();

        float timeCrossfade = 0.0f;

        while (timeCrossfade < crossfadeDuration)
        {
            timeCrossfade += Time.deltaTime;
            activeSource.volume = Mathf.Lerp(1.0f, 0.0f, timeCrossfade / crossfadeDuration);
            newSource.volume = Mathf.Lerp(0.0f, 1.0f, timeCrossfade / crossfadeDuration);
            yield return null;
        }

        activeSource.Stop();
        isPlayingSource1 = !isPlayingSource1;
    }

    public void TriggerMusicChange()
    {
        PlayRandomClip();
    }
}
