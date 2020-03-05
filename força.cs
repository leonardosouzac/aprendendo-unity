﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class força : MonoBehaviour
{
    private Rigidbody2D bola;
    private float force = 0f;
    private rotação rot;
    public Image seta2Img;
    void Start()
    {
        bola = GetComponent<Rigidbody2D>();
        rot = GetComponent<rotação>();

    }

    // Update is called once per frame
    void Update()
    {
        AplicaForca();
        ControlaForca();
    }

    void AplicaForca()
    {
        float x =  force * Mathf.Cos(rot.zRotate * Mathf.Deg2Rad);
        float y =  force * Mathf.Sin(rot.zRotate * Mathf.Deg2Rad);

        if (rot.liberaTiro == true)
        {
            bola.AddForce(new Vector2(x, y));
            rot.liberaTiro = false;
        }
    }

    void ControlaForca ()
    {
        if (rot.liberaRot == true)
        {
            float moveX = Input.GetAxis("Mouse X");

            if (moveX < 0)
            {
                seta2Img.fillAmount += 1 * Time.deltaTime;
                force = seta2Img.fillAmount * 1000;
            }
            if (moveX > 0)
            {
                seta2Img.fillAmount -= 1 * Time.deltaTime;
                force = seta2Img.fillAmount * 1000;
            }
        }
    }
}
