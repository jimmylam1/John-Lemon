using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesLerp : MonoBehaviour
{
    public GameObject player;

    ParticleSystem ps;
    private float r;
    private float g;
    private float b;
    private float a;
    private float maxDist;

    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
        r = 1.0f;
        g = 1.0f;
        b = 0.0f;
        a = 1.0f;

        maxDist = 7.5f;

    }

    void Update()
    {
        // lerp from red to green based on distance of player from exit

        Vector3 diff = player.transform.position - transform.position;

        // normalize the difference to be between 0 and 1
        float dist = Mathf.Min(diff.magnitude, maxDist) / maxDist;

        // lerp
        r = (1.0f - dist) * 0.0f + dist * 1.0f;
        g = dist * 0.0f + (1.0f - dist) * 1.0f;

        // set the color of the particles
        var main = ps.main;
        main.startColor = new Color(r, g, b, a);
    }
}