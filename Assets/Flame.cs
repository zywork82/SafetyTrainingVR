using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)] private float currentIntensity = 1.0f;
    private float[] startIntensities = new float[0];

    [SerializeField] private ParticleSystem[] flameParticleSystems = new ParticleSystem[0];

    private void Start() 
    {
        // Initialise each starting intensity
        startIntensities = new float[flameParticleSystems.Length];
        for (int i = 0; i < flameParticleSystems.Length; i++) {
            startIntensities[i] = flameParticleSystems[i].emission.rateOverTime.constant;
        }
    }

    private void Update()
    {
        ChangeIntensity();
    }

    private void ChangeIntensity()
    {
        for (int i = 0; i < flameParticleSystems.Length; i++) {
            var emission = flameParticleSystems[i].emission;
            emission.rateOverTime = currentIntensity * startIntensities[i];
        }
    }
}
