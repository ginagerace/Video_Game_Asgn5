using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour 
{
    double speed = 0.25;
    public Camera cam;
    public AudioClip mySound;
    public float amount = 50f;

    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = mySound;
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal") * (float) speed * 5;
        var z = Input.GetAxis("Vertical") * (float) speed;
        this.transform.Translate(z, 0, 0);
        this.transform.Rotate(0, x, 0 );
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal") * amount * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * amount * Time.deltaTime;
        GetComponent<Rigidbody>().AddTorque(transform.up * h, ForceMode.VelocityChange);
        GetComponent<Rigidbody>().AddTorque(transform.forward * z); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            GetComponent<AudioSource>().Play();
        }
        if (collision.gameObject.tag == "Wall")
        {
            var x = Input.GetAxis("Horizontal") * (float)speed * 5;
            var z = Input.GetAxis("Vertical") * (float)speed;
            this.transform.Translate(-z, 0, 0);
            this.transform.Rotate(0, -x, 0);
        }
    }

    public void SpeedUp()
    {
        speed += 0.1;
        Debug.Log("speed is " + speed);
    }
}
