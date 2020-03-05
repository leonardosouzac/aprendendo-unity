using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pulo : MonoBehaviour
{
    public float força = 500f;
    public Rigidbody2D bola;
    public int duplo = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (duplo > 0) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                bola.AddForce (new Vector2 (0, força * Time.deltaTime), ForceMode2D.Impulse);
                duplo --;
            }
        }
    }

    void OnCollisionEnter2D (Collision2D outro) {
        if (outro.gameObject.CompareTag("chao")) {
            duplo = 2;
        }
    }
}
