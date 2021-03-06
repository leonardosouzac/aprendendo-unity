﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    public float speed;
    public int jumpForce;
    public int health;
    public Transform groundCheck;
    
    private bool invunerable = false;
    private bool grounded = false;
    private bool jumping = false;
    private bool facingRight = true;
    
    private SpriteRenderer sprite;
    private Rigidbody2D rb2d;
    private Animator anim;
  
    
    public float attackRate;
    public Transform spawnAttack;
    public GameObject AttackPrefab;
    private float nextAttack = 0f;

    private Camera cameraScript;

    
    // Start is called before the first frame update
    void Start() {
        sprite = GetComponent <SpriteRenderer> ();
        rb2d = GetComponent <Rigidbody2D> ();
        anim = GetComponent <Animator> ();

        cameraScript = GameObject.Find("Main Camera").GetComponent<Camera>();

        
    }

    // Update is called once per frame
    void Update() {
    
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        
        if (Input.GetButtonDown("Jump") && grounded){
            jumping = true;
            
        }
        
        SetAnimations ();
        
        if (Input.GetButton("Fire1") && grounded && Time.time > nextAttack) {

            Attack();
            
        }
        
    }
    
    void FixedUpdate () {
    
        float move = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2 (move * speed, rb2d.velocity.y);
        
        if ((move < 0f && facingRight) || (move >0f && !facingRight)) {
            Flip ();
            
        }
            
        if (jumping) {
            rb2d.AddForce(new Vector2 (0f, jumpForce));
            jumping = false;
            
            
        }    
            
    }
        
        void Flip() {
            facingRight = !facingRight;
            transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        
            
            
        }
      
        void SetAnimations() {
            anim.SetFloat ("VelY", rb2d.velocity.y);
            anim.SetBool ("JumpFall", !grounded);
            anim.SetBool ("Walk", rb2d.velocity.x != 0f && grounded);
             
        }
    
        void Attack () {
            
            anim.SetTrigger("Punch");
            nextAttack = Time.time + attackRate;
            
            GameObject cloneAttack = Instantiate (AttackPrefab, spawnAttack.position, spawnAttack.rotation);

        //Virar o spawnattack junto com o boneco

        if (!facingRight)
        {
            cloneAttack.transform.eulerAngles = new Vector3(180, 0, 180);

        }
            
        }
    
    IEnumerator DamageEffect ()
    {
        //criar efeito de câmera;
        cameraScript.ShakeCamera(0.5f, 0.1f);

        for (float i = 0f; i < 1f; i += 0.1f)
        {
            sprite.enabled = false;
            yield return new WaitForSeconds(0.1f);
            sprite.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }

        invunerable = false;
    }
    
    public void DamagePlayer()
    {

        if (!invunerable)
        {
            invunerable = true;
            health--;
            StartCoroutine(DamageEffect());

            if (health < 1)
            {
                Debug.Log("Morreu");

            }
        }
    }


    }
    
