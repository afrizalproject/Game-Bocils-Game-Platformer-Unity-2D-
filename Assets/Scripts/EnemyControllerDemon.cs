using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerDemon : MonoBehaviour
{
    public static EnemyControllerDemon singleton; 
    public Animator animDemon;
    public bool tesanim;

    private void Awake()
    {
        singleton = this;
        animDemon = GetComponent<Animator>();
    }


    //movement
    public float movementSeed;
    public bool isFacingRight;

    //checker
    public Transform groundChecker;
    public float groundCheckerRadius;
    public LayerMask whatIsGround;

    //UI BAR
    public Transform enemyHUD;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * movementSeed * Time.deltaTime);
        if (!thereIsGround())
        {
            if (isFacingRight)
            {
                enemyHUD.localEulerAngles = Vector2.up * 180;
                transform.eulerAngles = Vector2.up * 180;
                isFacingRight = false;
            }
            else
            {
                enemyHUD.localEulerAngles = Vector2.zero;
                transform.eulerAngles = Vector2.zero;
                isFacingRight = true;
            }
        }
        if (tesanim)
        {
            animDemon.SetTrigger("demon-attack");
        }
        else
        {
            animDemon.SetTrigger("demon-idle");
        }

    }

    bool thereIsGround()
    {
        return Physics2D.OverlapCircle(groundChecker.position, groundCheckerRadius, whatIsGround);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundChecker.position, groundCheckerRadius);
    }



}
