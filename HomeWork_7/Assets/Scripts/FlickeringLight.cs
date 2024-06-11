using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    [SerializeField] private Light flickeringLight;
    [SerializeField] private float minIntensity = 0.5f;
    [SerializeField] private float maxIntensity = 2.0f;
    [SerializeField] private float minFlickerSpeed = 0.05f;
    [SerializeField] private float maxFlickerSpeed = 0.2f;
    [SerializeField] private Color[] colors;

    private void Start()
    {
        if (flickeringLight == null)
        {
            flickeringLight = GetComponent<Light>();
        }

        StartCoroutine(Flicker());
    }

    private IEnumerator Flicker()
    {
        while (true)
        {
            flickeringLight.intensity = Random.Range(minIntensity, maxIntensity);
            yield return new WaitForSeconds(Random.Range(minFlickerSpeed, maxFlickerSpeed));
        }
    }

    public void ChangeColor()
    {
        if (colors.Length > 0)
        {
            Color newColor = colors[Random.Range(0, colors.Length)];
            flickeringLight.color = newColor;
        }
    }
}
