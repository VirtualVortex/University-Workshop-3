using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private float delay;

    [Header("Direction")]

    [SerializeField]
    float x;
    [SerializeField]
    float y;
    [SerializeField]
    float z;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("FireObject");
    }

    //Continuasly run code in coroutine
    public IEnumerator FireObject() 
    {
        while (true) 
        {
            yield return new WaitForSeconds(delay);
            Launch();
        }
    }

    //Spawn fireball, apply force to object and then destroy it after 10 seconds
    void Launch() 
    {
        GameObject magma = Instantiate(projectile, transform.position, Quaternion.identity);
        magma.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-x, x), y, Random.Range(-z, z)), ForceMode.Impulse);
        Destroy(magma, 10);
    }
}
