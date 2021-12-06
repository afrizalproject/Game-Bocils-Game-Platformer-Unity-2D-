using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController singleton;

    public float speedMovement, jumpForce;
    public bool isFacingRight,isJumping;

    Rigidbody2D rb;

    public float radius;
    public Transform groundChecker;
    public LayerMask whatIsGround;

    public Animator anim;
    string idle = "idle";
    string walk = "walk";
    string jump = "jump";
    string landing = "land";

    //UI SCORE
    public Text scoreUI;
    public Transform warningMusuh;
    public GameObject UIWinner;

    private void Awake()
    {
        singleton = this;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        scoreUI.text = ": "+"0" + "/28";
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        movement();
    }

    public void movement()
    {
        float move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(speedMovement*move,rb.velocity.y);

        if(move != 0)
        {
            anim.SetTrigger(walk);
        }
        else
        {
            anim.SetTrigger(idle);
        }

        if(move>0 && !isFacingRight)
        {
            warningMusuh.localEulerAngles= Vector2.zero;
            transform.eulerAngles = Vector2.zero;
            isFacingRight = true;
        }
        else if(move<0 && isFacingRight)
        {
            warningMusuh.localEulerAngles = Vector2.up * 180;
            transform.eulerAngles = Vector2.up*180;
            isFacingRight = false;
        }
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            sfxmanager.singleton.playSound(0);
            rb.velocity = Vector2.up * jumpForce;
        }

        if(!isGrounded() && !isJumping)
        {
            anim.SetTrigger(jump);
            isJumping = true;
        }
        else if(isGrounded() && isJumping )
        {
            anim.SetTrigger(landing);
            isJumping = false;
        }
    }

    bool isGrounded()
    {
        //membuat lingkaran dan return true jika bersentuhan dengan ground
        return Physics2D.OverlapCircle(groundChecker.position, radius, whatIsGround);
    }

    //gambar lingkaran
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundChecker.position, radius);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("huruf"))
        {
            sfxmanager.singleton.playSound(2);
            GoalManager.singleton.CollectHuruf();
            scoreUI.text = ": "+GoalManager.singleton.hurufCollected.ToString()+"/28";
            Destroy(collision.gameObject);
        }else if (collision.CompareTag("goal"))
        {
            if (GoalManager.singleton.canEnterFinish)
            {
                backsoungGamePlay.singleton.audioMute = true;
                backsoundWinner.singleton.audioMute = false;
                Time.timeScale = 0;
                UIWinner.SetActive(true);
            }
            else if(GoalManager.singleton.canEnterFinish==false)
            {
                GoalManager.singleton.warningScore.SetActive(true);
                GoalManager.singleton.runCoroutine();
            }
        }
    }
}
