using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem Boom;
    [SerializeField] private ParticleSystem BoomShot;
    public Transform parent;

    public void Explosion(Vector3 position)
    {
        instantiate(Boom, position, 5, 0, 0, 0, parent); 
    }

    public void ExplosionMini(Vector3 position)
    {
        if (BoomShot != null) instantiate(BoomShot, position, 4, 0, 0, 0, parent);
    }

    private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position, int time, float rotationx = 0f, float rotationy = 0f, float rotationz = 0f, Transform parent = null)
    {
        ParticleSystem newparticleSystem = Instantiate(prefab, position, Quaternion.identity) as ParticleSystem;
        newparticleSystem.transform.rotation = Quaternion.Euler(rotationx, rotationy, rotationz);
        if (parent != null)
        {
            var main = newparticleSystem.main;
            main.simulationSpace = ParticleSystemSimulationSpace.Custom;
            main.customSimulationSpace = parent;
        } 
        Destroy(newparticleSystem.gameObject, time);
        return newparticleSystem;
    }
}
