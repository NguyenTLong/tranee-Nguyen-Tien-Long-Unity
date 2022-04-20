using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject obj;
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    

    public float jumpForce = 10;
    private bool isGround = true;

    public bool gameOver = false;
    public float gravityModifier = 1;



    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        playerRb = obj.GetComponent<Rigidbody>();
        playerAnim = obj.GetComponent<Animator>();
        playerAudio = obj.GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround && !gameOver)
        {
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound);
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); ;
            isGround = false;
            playerAnim.SetTrigger("Jump_trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            dirtParticle.Play();
            isGround = true;
        }
        Debug.Log("is Touched");
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound);
            gameOver = true;
            Debug.Log("Game over !! T.T");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game over !! T.T");
        }
    }
}
