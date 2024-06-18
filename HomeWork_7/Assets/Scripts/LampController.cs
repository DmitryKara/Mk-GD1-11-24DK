using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampController : MonoBehaviour
{
    [SerializeField] private List<Light> lamps;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private Color[] possibleColors;
    [SerializeField] private float minFlickerSpeed = 0.05f;
    [SerializeField] private float maxFlickerSpeed = 0.2f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ActivateRandomLamps()
    {
        StopAllCoroutines();
        audioSource.Stop();

        foreach (Light lamp in lamps)
        {
            lamp.enabled = false;
        }

        int numberOfLampsToActivate = Random.Range(1, lamps.Count + 1);

        List<int> lampIndices = new List<int>();
        for (int i = 0; i < lamps.Count; i++)
        {
            lampIndices.Add(i);
        }

        for (int i = 0; i < numberOfLampsToActivate; i++)
        {
            int randomLampIndex = lampIndices[i];
            Light randomLamp = lamps[randomLampIndex];
            randomLamp.enabled = true;
            randomLamp.color = possibleColors[Random.Range(0, possibleColors.Length)];
            StartCoroutine(Flicker(randomLamp));

            int randomAudioIndex = Random.Range(0, audioClips.Length);
            audioSource.clip = audioClips[randomAudioIndex];
            audioSource.Play();
        }
    }

    private IEnumerator Flicker(Light lamp)
    {
        while (lamp.enabled)
        {
            lamp.intensity = Random.Range(0.5f, 2.0f);
            yield return new WaitForSeconds(Random.Range(minFlickerSpeed, maxFlickerSpeed));
        }
    }
}
