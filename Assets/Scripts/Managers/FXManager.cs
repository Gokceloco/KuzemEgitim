using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour
{
    public GameDirector gameDirector;
    public ParticleSystem coinCollectPSPrefab;

    public void PlayCoinCollectParticles(Vector3 pos)
    {
        var newPS = Instantiate(coinCollectPSPrefab);
        newPS.transform.position = pos;
        newPS.Play();
    }
}
