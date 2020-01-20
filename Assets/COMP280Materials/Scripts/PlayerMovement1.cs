using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    float x;
    float y;
    Rigidbody rb;
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        //Access rigidbody and set start position to player's begining position
        rb = GetComponent<Rigidbody>();
        y = -rb.mass;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Change the objects velocity based on the player's input 
        rb.velocity = new Vector3(0, y, Input.GetAxis("Horizontal") * speed);

        //Start coroutine when space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(Jump());
    }

    //Increase the player's velocity on the y axis
    public IEnumerator Jump()
    {
        y = jumpForce;
        yield return new WaitForSeconds(1);
        y = -rb.mass;
    }

    //If the player collides with a magmaball reset its position
    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log(other.tag);
        if (other.tag.Contains("Danger"))
            transform.position = startPos;
    }
}
