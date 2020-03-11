using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 25.0f;
    public float rotationSpeed = 90;
    public float force = 100f;

    public GameObject Cannon;
    public GameObject Bullet;

    Rigidbody rb;
    Transform t;

    //Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        t = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        { rb.velocity += this.transform.forward * speed * Time.deltaTime; }
        else if (Input.GetKey(KeyCode.S))
        { rb.velocity -= this.transform.forward * speed * Time.deltaTime; }

        if (Input.GetKey(KeyCode.D))
        { rb.rotation *= Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0); }
        else if (Input.GetKey(KeyCode.A))
        { rb.rotation *= Quaternion.Euler(0, -rotationSpeed * Time.deltaTime, 0); }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{ rb.AddForce(t.up * 400); }

        if (Input.GetKeyDown(KeyCode.X))
        {
            GameObject newBullet = GameObject.Instantiate(Bullet, Cannon.transform.position, Cannon.transform.rotation) as GameObject;
            newBullet.GetComponent<Rigidbody>().velocity += Vector3.up * 5;
            newBullet.GetComponent<Rigidbody>().AddForce(newBullet.transform.forward * 150);
        }
    }
}