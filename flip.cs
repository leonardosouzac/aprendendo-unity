using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flip : MonoBehaviour
{
    public bool face = true;
    public Transform heroiT;
    public float vel = 2.5f;
    public float force = 6.5f;
    public Rigidbody2D heroiRB;
    public bool liberaPulo = false;
    void Start()
    {
        heroiT = GetComponent<Transform> ();
        heroiRB = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    { if (Input.GetKey(KeyCode.RightArrow) && !face) {
        Flip ();
    }  else if (Input.GetKey(KeyCode.LeftArrow) && face) {
        Flip ();
    }
    float h = vel * Input.GetAxis ("Horizontal");
    float v = vel * Input.GetAxis ("Vertical");

    transform.Translate (new Vector3 (h*Time.deltaTime, v*Time.deltaTime, 0));
    }

    void Flip () {
        face = !face;

        Vector3 scala = heroiT.localScale;
        scala.x *= -1;
        heroiT.localScale = scala;


    }
    
}

