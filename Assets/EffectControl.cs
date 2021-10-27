using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectControl : MonoBehaviour
{
    public ParticleSystem ps;
    void Start()
    {
        ps.Stop();
        var main = ps.main;
        main.simulationSpeed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (ps.time == 3f)
        {
            ps.Stop();
        }
    }

    public void genEffect()
    {
        ps.time = 0;
        ps.Play();
    }
}
