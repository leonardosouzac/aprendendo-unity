using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teste : MonoBehaviour
{
    public float forca = 500f;
    public Rigidbody2D bola;
    public float h = 2.5f;
    public float v = 2.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetKey(KeyCode.RightArrow)) {
            transform.Translate(new Vector3 (vel * Time.deltaTime,0,0));
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.Translate(new Vector3 (-vel * Time.deltaTime,0,0));
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            transform.Translate(new Vector3 (0,vel * Time.deltaTime,0));
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            transform.Translate(new Vector3 (0,-vel * Time.deltaTime,0));
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Translate (new Vector3 (h * Time.deltaTime, v * Time.deltaTime,0));
        */
        if (this.gameObject.CompareTag("bola")) {
            if (Input.GetKeyDown(KeyCode.Space)){
                bola.AddForce (new Vector2 (0, forca * Time.deltaTime), ForceMode2D.Impulse);
            }
        }    
    }
}
