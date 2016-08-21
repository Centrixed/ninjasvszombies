using CnControls;
using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

    public float Speed = 0f;
    public float SlideSpeed = 0f;
    public float SlideDamage = 0f;
    public float SlideCost = 0f;
    public float ThrowDelay = 0f;
    public float ThrowRate = 0f;
    public float ThrowDamage = 0f;
    public float ThrowCost = 0f;
    public float contactDamage = 0f;
    public bool isSliding = false;
    public bool isThrowing = false;
    public Rigidbody2D physics;
    public Animator animate;
    public bool faceDirection = true;
    private PlayerStatus playerStat;
    private EnemyStatus enemyStat;
    private SpriteRenderer playerSprite;
    private Rigidbody2D playerRigid;
    private RigidbodyConstraints2D freezeAll, freezeRot;
    private bool slideCD = false;


    void Start () {
        physics = GetComponent<Rigidbody2D>();
		animate = GetComponent<Animator>();
        playerStat = GetComponent<PlayerStatus>();
        playerSprite = GetComponent<SpriteRenderer>();
        playerRigid = GetComponent<Rigidbody2D>();
        freezeAll = RigidbodyConstraints2D.FreezeAll;
        freezeRot = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update() {
        //If button is hit, start function
        if(Input.GetKeyDown("left shift") || CnInputManager.GetButton("TouchSlide")) {
            StartCoroutine("slideCheck");
        }
        if (Input.GetKeyDown("space") || CnInputManager.GetButtonDown("TouchAttk")) {
            StartCoroutine("throwCheck");
        }

        //Sets character look direction bools, as well as flipping the sprite
        if (Input.GetKey("a") && Input.GetKey("d")) {
            //Fixes the "moonwalk" bug.
        }
        else if (Input.GetKey("d") || CnInputManager.GetAxis("Horizontal") > 0) {
            playerSprite.flipX = false;
            animate.SetBool("LookDirection", true);
            animate.SetBool("RunLeft", false);
            animate.SetBool("RunRight", true);
            animate.SetBool("isIdle", false);
            faceDirection = true;
        }
        else if (Input.GetKey("a") || CnInputManager.GetAxis("Horizontal") < 0) {
            playerSprite.flipX = true;
            animate.SetBool("LookDirection", false);
            animate.SetBool("RunRight", false);
            animate.SetBool("RunLeft", true);
            animate.SetBool("isIdle", false);
            faceDirection = false;
        }
        else if (Input.GetKey("w") || CnInputManager.GetAxis("Vertical") > 0) {
            animate.SetBool("isIdle", false);
            if (!playerSprite.flipX) {
                animate.SetBool("RunRight", true);
                animate.SetBool("RunLeft", false);
            }
            else if (playerSprite.flipX) {
                animate.SetBool("RunLeft", true);
                animate.SetBool("RunRight", false);
            }
        }
        else if (Input.GetKey("s") || CnInputManager.GetAxis("Vertical") < 0) {
            animate.SetBool("isIdle", false);
            if (!playerSprite.flipX) {
                animate.SetBool("RunRight", true);
                animate.SetBool("RunLeft", false);
            }
            else if (playerSprite.flipX) {
                animate.SetBool("RunLeft", true);
                animate.SetBool("RunRight", false);
            }
        }
        else {
            animate.SetBool("RunRight", false);
            animate.SetBool("RunLeft", false);
            animate.SetBool("isIdle", true);
        }
    }

    //Allows the player to slide through the enemy collider, also handles slide damage
    void OnCollisionEnter2D(Collision2D other) {
        if (isSliding && other.gameObject.tag == "Enemy") {
            enemyStat = other.gameObject.GetComponent<EnemyStatus>();
            enemyStat.health -= SlideDamage;
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), other.gameObject.GetComponent<Collider2D>(), true);
        }
        else if(!isSliding && other.gameObject.tag == "Enemy") {
            //playerStat.health -= contactDamage;
        }
    }
    void OnCollisionStay2D(Collision2D other) {
        if (!isSliding && other.gameObject.tag == "Enemy") {
            //playerStat.health -= contactDamage;
        }
    }
    void OnCollisionExit2D(Collision2D other) {
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), other.gameObject.GetComponent<Collider2D>(), false);
    }

    IEnumerator ThrowPause() {
        playerRigid.constraints = freezeAll;
        yield return new WaitForSeconds(ThrowDelay);
        playerRigid.constraints = freezeRot;
    }

    IEnumerator slideCheck() {
        //If shift is pressed and the character is running, slide.
        if (Input.GetKey("left shift") || CnInputManager.GetButton("TouchSlide")) {
            if (!slideCD && !isSliding && playerStat.energy >= SlideCost && !animate.GetBool("isIdle")) {
                animate.SetBool("Slide", true);
                isSliding = true;
                slideCD = true;
                playerStat.energy -= SlideCost;
                yield return new WaitForSeconds(0.35f);
                isSliding = false;
                animate.SetBool("Slide", false);
                StartCoroutine("slideCoolDown");
            }
        }
    }

    IEnumerator slideCoolDown() {
        yield return new WaitForSeconds(0.3f);
        slideCD = false;
    }

    IEnumerator throwCheck() {
        if (Input.GetKey("space") || CnInputManager.GetButtonDown("TouchAttk")) {
            if (!isThrowing && !playerStat.dead && playerStat.energy >= ThrowCost) {
                isThrowing = true;
                animate.SetTrigger("Throw");
                playerStat.energy -= ThrowCost;
                StartCoroutine("ThrowPause");
                yield return new WaitForSeconds(ThrowRate);
                animate.ResetTrigger("Throw");
                isThrowing = false;
            }
        }
    }

    void FixedUpdate()
    {
        if (!playerStat.dead) {
            //Checks for movement input, then adjusts character speed/direction accordingly using velocity.
            if (!isSliding) {
                //Joystick Movement
                physics.velocity = new Vector2(CnInputManager.GetAxis("Horizontal") * Speed, CnInputManager.GetAxis("Vertical") * Speed);
                //Keyboard Movement
                //physics.velocity = new Vector2(movex * Speed, movey * Speed);
            }
            //If sliding is true (input down), then move the character accordingly.
            if(isSliding) {
                float xhold = 0, yhold = 0;
                xhold = CnInputManager.GetAxis("Horizontal");
                yhold = CnInputManager.GetAxis("Vertical");

                if (playerSprite.flipX) {
                    //physics.velocity = new Vector2(movex * (Speed + SlideSpeed), movey * Speed);
                    physics.velocity = new Vector2(xhold * (Speed + SlideSpeed), yhold * (Speed + SlideSpeed));
                }
                else if (!playerSprite.flipX) {
                    //physics.velocity = new Vector2(movex * (Speed + SlideSpeed), movey * Speed);
                    physics.velocity = new Vector2(xhold * (Speed + SlideSpeed), yhold * (Speed + SlideSpeed));
                }
            }
        }
    }
}
