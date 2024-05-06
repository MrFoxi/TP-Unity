using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float JumpForce;
    public Animator animator;
    private Rigidbody2D rb;

    private bool isGrounded = true;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
        StartCoroutine(IncrementScore());
        // Debug.log(GameManager.Instance.AddScore());

    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space)) {

            if (isGrounded == true) {

                rb.AddForce(Vector2.up * JumpForce);
                animator.SetTrigger("Saut");
                animator.SetBool("IsGrounded", false);
                isGrounded =false;
                
            }
        }

        

    }

    IEnumerator IncrementScore()
{
    while (true)
    {
        yield return new WaitForSeconds(0.01f);
        if(GameManager.Instance != null)
        {
            GameManager.Instance.AddScore();
        }
    }
}

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("ground")) {
            if (isGrounded == false) {
                animator.SetBool("IsGrounded", true);
                isGrounded = true;
            }
        }

        if(collision.gameObject.CompareTag("obstacle")) {
            StartCoroutine(Die());
            
        }
    }

    IEnumerator Die() {
        animator.SetTrigger("Die");
        
        yield return new WaitForSeconds(0.5f);
        Respawn();
        
    }

    void Respawn() {  
        Application.LoadLevel("SampleScene");
        // GameManager.Instance.ResetScore();
    }
}
