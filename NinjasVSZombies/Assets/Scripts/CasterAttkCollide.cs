using UnityEngine;
using System.Collections;

public class CasterAttkCollide : MonoBehaviour {

    public GameObject player, chargeAnchor, parent, objectPrefab;
    private BoxCollider2D playerCollide;
    private BoxCollider2D enemyCollide;
    private Transform playerTrans;
    private PlayerStatus playerStat;
    private CircleCollider2D radiusCollide;
    private Rigidbody2D enemyRigid;
    private Animator enemyAni;
    private Animator fireAni;
    private SpriteRenderer enemySprite;
    private GameObject clone;
    private RigidbodyConstraints2D freezePos, defaultPos;
    private bool stopRepeat = false;
    private bool onCooldown = false;
    private bool meleecd = false;
    private bool poscd = false;
    private Vector3 barScalar;
    public bool activateCharge = false;
    public Vector2 playerPos;
    public float chargeTimer = 0;
    public int cdTime = 3;
    private EnemyStatus enemyStat;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("MainChar");
        playerCollide = player.GetComponent<BoxCollider2D>();
        playerStat = player.GetComponent<PlayerStatus>();
        playerTrans = player.GetComponent<Transform>();
        radiusCollide = gameObject.GetComponent<CircleCollider2D>();
        enemyCollide = GetComponent<BoxCollider2D>();
        enemyRigid = gameObject.GetComponentInParent<Rigidbody2D>();
        enemyAni = gameObject.GetComponentInParent<Animator>();
        enemySprite = gameObject.GetComponentInParent<SpriteRenderer>();
        enemyStat = gameObject.GetComponentInParent<EnemyStatus>();
        parent = transform.parent.gameObject;
        chargeAnchor = parent.transform.Find("CastAnchor").gameObject;
        freezePos = RigidbodyConstraints2D.FreezeAll;
        defaultPos = RigidbodyConstraints2D.FreezeRotation;
        barScalar.y = 1;
        barScalar.z = 1;
    }

    void Update() {
        if (enemyStat.dead) {
            Destroy(clone);
        }
        
        //If charge radius touches player, freeze movement and play charge animation while running attackSeq to charge the bar.
        if (!enemyStat.dead && radiusCollide.IsTouching(playerCollide)) {
            if (!stopRepeat && !onCooldown && !playerStat.dead) {
                StartCoroutine("attackSeq");
                StartCoroutine("fireball");
                stopRepeat = true;
            }
        }

        //If enemy is ready to charge, then freeze it's position and activate charge bool (toggles heavymovementscript function)
        if (!enemyStat.dead && chargeTimer >= 100 && !activateCharge) {
            enemyAni.SetBool("Casting", true);
            enemyRigid.constraints = defaultPos;
            activateCharge = true;
            if (!poscd) {
                playerPos = playerTrans.position;
                poscd = true;
            }
        }

        //Toggled by heavymovementscript function, resets all values and starts cooldown coroutine
        if (activateCharge) {
            activateCharge = false;
            chargeTimer = 0;
            barScalar.x = chargeTimer / 100;
            chargeAnchor.transform.localScale = barScalar;
            StartCoroutine("castPause");
            StartCoroutine("cooldown");
        }

        if (enemyCollide.IsTouching(playerCollide)) {
            if (!activateCharge && !meleecd) {
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
        }
    }


    //handles the melee attacking & damage and pausing between each attack
    IEnumerator meleeSeq() {
        yield return new WaitForSeconds(0.55f);
        if (enemyCollide.IsTouching(playerCollide)) {
            playerStat.health -= 10;
            meleecd = false;
        }
    }

    IEnumerator castPause() {
        enemyRigid.constraints = freezePos;
        yield return new WaitForSeconds(0.75f);
        enemyRigid.constraints = defaultPos;
    }
    //Loops a cooldown timer for the enemy charge
    IEnumerator cooldown() {
        onCooldown = true;
        for(cdTime = 3;  cdTime > 0; --cdTime) {
            yield return new WaitForSeconds(1f);
        }
        onCooldown = false;
        stopRepeat = false;
        poscd = false;
        enemyAni.SetBool("Casting", false);
        cdTime = 3;
    }

    //charges the bar and scales the ui bar as well.
    IEnumerator attackSeq() {
        while (chargeTimer < 100) {
            enemyRigid.constraints = freezePos;
            enemyAni.SetTrigger("StartIdle");
            yield return new WaitForSeconds(0.025f);
            chargeTimer += 3;
            barScalar.x = chargeTimer / 100;
            chargeAnchor.transform.localScale = barScalar;
        }
    }

    IEnumerator fireball() {
        Vector2 faceAdjust = new Vector2(0, 0);
        Vector2 playerPos;
        Rigidbody2D cloneRigid;
        float xdiff, ydiff;

        if (!enemySprite.flipX) {
            faceAdjust.x = 50f;
        }
        else if (enemySprite.flipX) {
            faceAdjust.x = -50f;
        }

        clone = (GameObject)Instantiate(objectPrefab, enemyRigid.position + faceAdjust, Quaternion.identity);

        yield return new WaitForSeconds(1.6f);

        cloneRigid = clone.GetComponent<Rigidbody2D>();
        playerPos = playerTrans.position;
        xdiff = playerPos.x - clone.transform.position.x;
        ydiff = playerPos.y - clone.transform.position.y;

        cloneRigid.velocity = new Vector2(xdiff * 2, ydiff * 2);
        Destroy(clone, 3.0f);
    }
}
