using UnityEngine;
using System.Collections;

public class HeavyAttkCollide : MonoBehaviour {

    public GameObject player, chargeAnchor, parent;
    private BoxCollider2D playerCollide;
    private BoxCollider2D enemyCollide;
    private Transform playerTrans;
    private PlayerStatus playerStat;
    private CircleCollider2D radiusCollide;
    private EnemyStatus enemyStat;
    private Rigidbody2D enemyRigid;
    private Rigidbody2D playerRigid;
    private Animator enemyAni;
    private Animator playerAni;
    private RigidbodyConstraints2D freezePos, defaultPos;
    private bool stopRepeat = false;
    private bool onCooldown = false;
    private bool dmgcd = false;
    private bool meleecd = false;
    private bool poscd = false;
    private bool stunCD = false;
    private Vector3 barScalar;
    public bool activateCharge = false;
    public bool chargeCD = false;
    public Vector2 playerPos;
    public float chargeTimer = 0;
    public int cdTime = 4;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("MainChar");
        playerCollide = player.GetComponent<BoxCollider2D>();
        playerStat = player.GetComponent<PlayerStatus>();
        playerTrans = player.GetComponent<Transform>();
        playerRigid = player.GetComponent<Rigidbody2D>();
        playerAni = player.GetComponent<Animator>();
        radiusCollide = gameObject.GetComponent<CircleCollider2D>();
        enemyStat = gameObject.GetComponentInParent<EnemyStatus>();
        enemyCollide = GetComponent<BoxCollider2D>();
        enemyRigid = gameObject.GetComponentInParent<Rigidbody2D>();
        enemyAni = gameObject.GetComponentInParent<Animator>();
        parent = transform.parent.gameObject;
        chargeAnchor = parent.transform.Find("ChargeAnchor").gameObject;
        freezePos = RigidbodyConstraints2D.FreezeAll;
        defaultPos = RigidbodyConstraints2D.FreezeRotation;
        barScalar.y = 1;
        barScalar.z = 1;
    }

    void Update() {
        //If charge radius touches player, freeze enemy and play charge animation while running attackSeq to charge the bar.
        if (!enemyStat.dead && radiusCollide.IsTouching(playerCollide)) {
            if (!stopRepeat && !onCooldown && !playerStat.dead) {
                enemyAni.SetBool("Charging", true);
                StartCoroutine("attackSeq");
                stopRepeat = true;
            }
        }

        //If enemy is ready to charge, then freeze it's position and activate charge bool (toggles heavymovementscript function)
        if (!enemyStat.dead && chargeTimer >= 100 && !chargeCD) {
            if (!poscd) {
                playerPos = playerTrans.position;
                poscd = true;
            }
            enemyAni.SetBool("Charging", false);
            enemyAni.SetBool("Sprint", true);
            enemyRigid.constraints = defaultPos;
            activateCharge = true;
        }

        //Toggled by heavymovementscript function, resets all values and starts cooldown coroutine
        if (chargeCD) {
            enemyAni.SetBool("Sprint", false);
            activateCharge = false;
            chargeTimer = 0;
            barScalar.x = chargeTimer / 100;
            chargeAnchor.transform.localScale = barScalar;
            StartCoroutine("chargePause");
            StartCoroutine("cooldown");
            chargeCD = false;
        }

        if (enemyCollide.IsTouching(playerCollide)) {
            if (activateCharge && !dmgcd && !stunCD) {
                activateCharge = false;
                stunCD = true;
                playerRigid.constraints = freezePos;
                playerAni.SetBool("Stun", true);
                dmgcd = true;
                StartCoroutine("stun");
            }
            else if (!activateCharge && !meleecd) {
                enemyAni.SetBool("Attack", true);
                meleecd = true;
                StartCoroutine("meleeSeq");
            }
        }
        else if (!enemyCollide.IsTouching(playerCollide)) {
            if (enemyAni.GetBool("Attack")) {
                enemyAni.SetBool("Attack", false);
            }
            meleecd = false;
            stunCD = false;
        }
    }

    IEnumerator stun() {
        yield return new WaitForSeconds(1f);
        playerRigid.constraints = defaultPos;
        playerAni.SetBool("Stun", false);
        dmgcd = false;
    }

    //handles the melee attacking & damage and pausing between each attack
    IEnumerator meleeSeq() {
        yield return new WaitForSeconds(0.55f);
        if (enemyCollide.IsTouching(playerCollide)) {
            playerStat.health -= 10;
            meleecd = false;
        }
    }

    //Pauses enemy after the charge sequence is finished
    IEnumerator chargePause() {
        enemyRigid.constraints = freezePos;
        yield return new WaitForSeconds(0.75f);
        enemyRigid.constraints = defaultPos;
    }

    //Loops a cooldown timer for the enemy charge
    IEnumerator cooldown() {
        onCooldown = true;
        for(cdTime = 4;  cdTime > 0; --cdTime) {
            yield return new WaitForSeconds(1f);
        }
        onCooldown = false;
        stopRepeat = false;
        poscd = false;
        cdTime = 4;
    }

    //charges the bar and scales the ui bar as well.
    IEnumerator attackSeq() {
        while (chargeTimer < 100) {
            enemyRigid.constraints = freezePos;
            yield return new WaitForSeconds(0.025f);
            chargeTimer += 4;
            barScalar.x = chargeTimer / 100;
            chargeAnchor.transform.localScale = barScalar;
        }
    }
}
