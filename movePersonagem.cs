using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePersonagem : MonoBehaviour
{
    private float vel;
    private Vector2 direcao;

    public Animator anim;
    private Rigidbody2D heroiRB;

    // Start is called before the first frame update
    void Start()
    {
        vel = 3;
        direcao = Vector2.zero;
        heroiRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        InputPersonagem();


        if (direcao.x != 0 || direcao.y != 0)
        {
            Animacao(direcao);
        }
        else
        {
            anim.SetLayerWeight(1, 0);
        }
    }
    private void FixedUpdate()
    {
        heroiRB.MovePosition(heroiRB.position + direcao * vel * Time.deltaTime);
    }
    void InputPersonagem()
    {
        direcao = Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            direcao += Vector2.up;

        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            direcao += Vector2.down;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direcao += Vector2.left;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            direcao += Vector2.right;
        }
    }

    void Animacao(Vector2 dir)
    {
        anim.SetLayerWeight(1, 1);

        anim.SetFloat("x", dir.x);
        anim.SetFloat("y", dir.y);

    }
}


