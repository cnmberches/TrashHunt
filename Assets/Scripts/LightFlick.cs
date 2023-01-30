using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFlick : MonoBehaviour
{
    public float intensitySpeed;
    private Light2D lighttrash;
    private float intensityLight;
    private bool isGoingUp = false;
    private float cooldown = 1;
    private void Awake()
    {
        lighttrash= GetComponent<Light2D>();
        intensityLight = lighttrash.intensity;
    }

    void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime * intensitySpeed;
        }
        else if (cooldown <= 0)
        {
            cooldown = 1f;
            StartCoroutine(Shine());
        }
    }

    IEnumerator Shine()
    {
        if (lighttrash.intensity >= intensityLight)
        {
            isGoingUp = false;
        }
        else if (lighttrash.intensity <= 0f)
        {
            isGoingUp = true;
        }

        if (isGoingUp)
        {
            lighttrash.intensity += 0.1f;
            lighttrash.pointLightOuterRadius = 0f;
            yield return null;
        }
        else
        {
            lighttrash.intensity -= 0.1f;
            lighttrash.pointLightOuterRadius += 0.1f;
            yield return null;
        }
    }
}
