using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField]
    float height;
    [SerializeField]
    float maxEmissionIntensity;

    float emissionIntensity;
    float t;
    Renderer renderer;
    bool inLava;

    Rigidbody rb;
    float z;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Launch game object upwards and reset emission value when it's below -2 on the y axis
        if (transform.position.y <= -2)
        {
            rb.AddForce(new Vector3(0, height, 0), ForceMode.Impulse);
            rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            emissionIntensity = 0;
            t = 0;
            inLava = true;
        }

        //When in the lava call IncraseEmission
        if(inLava)
        {
            if (emissionIntensity <= maxEmissionIntensity)
            {
                IncreaseEmission();
            }
            else
                inLava = false;
        }
            
        //Access emission intensity value in the shader material
        renderer.material.SetFloat("_EmissionIntensity", emissionIntensity);
    }

    //Increase the emission intensity over time
    void IncreaseEmission() 
    {
        emissionIntensity = Mathf.Lerp(emissionIntensity, maxEmissionIntensity, t);
        t += 0.1f * Time.deltaTime;
    }

}
