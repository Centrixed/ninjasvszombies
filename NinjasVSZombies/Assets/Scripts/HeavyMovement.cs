using UnityEngine;
using System.Collections;

public class HeavyMovement : MonoBehaviour {

    private PlayerStatus playerStat;
    private Rigidbody2D enemyRigid;
    private Rigidbody2D playerRigid;
    private Transform enemyTrans;
    private GameObject player;
    private BoxCollider2D enemyCollide;
    private BoxCollider2D playerCollide;
    private HeavyAttkCollide heavyAC;
    public float speed;
    public float chargeSpeed;
    private float movex, movey;
    private Vector2 startPos;
    private bool follow = true;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("MainChar");
        playerStat = player.GetComponent<PlayerStatus>();
        playerRigid = player.GetComponent<Rigidbody2D>();
        playerCollide = player.GetComponent<BoxCollider2D>();
        enemyRigid = GetComponent<Rigidbody2D>();
        enemyTrans = GetComponent<Transform>();
        enemyCollide = GetComponent<BoxCollider2D>();
        heavyAC = GetComponentInChildren<HeavyAttkCollide>();
        startPos = enemyRigid.position;
	}

    //Allows the AI to track the players position and move towards them.
    void followPlayer() {
        if (follow) {
            Vector2 playerPos, enemyPos;
            float xdiff, ydiff;
            playerPos = playerRigid.position;
            enemyPos = enemyRigid.position;
            xdiff = playerPos.x - enemyPos.x;
            ydiff = playerPos.y - enemyPos.y;

            if ((xdiff < 25 && xdiff > -25) && playerPos.y > enemyPos.y) {
                enemyRigid.velocity = new Vector2(0 * speed, 1 * speed);
            }
            else if ((xdiff < 25 && xdiff > -25) && playerPos.y < enemyPos.y) {
                enemyRigid.velocity = new Vector2(0 * speed, -1 * speed);
            }
            else if (playerPos.x > enemyPos.x && (ydiff < 25 && ydiff > -25)) {
                enemyRigid.velocity = new Vector2(1 * speed, 0 * speed);
            }
            else if (playerPos.x < enemyPos.x && (ydiff < 25 && ydiff > -25)) {
                enemyRigid.velocity = new Vector2(-1 * speed, 0 * speed);
            }
            else if (playerPos.x > enemyPos.x && playerPos.y > enemyPos.y) {
                enemyRigid.velocity = new Vector2(1 * speed, 1 * speed);
            }
            else if (playerPos.x > enemyPos.x && playerPos.y < enemyPos.y) {
                enemyRigid.velocity = new Vector2(1 * speed, -1 * speed);
            }
            else if (playerPos.x < enemyPos.x && playerPos.y > enemyPos.y) {
                enemyRigid.velocity = new Vector2(-1 * speed, 1 * speed);
            }
            else if (playerPos.x < enemyPos.x && playerPos.y < enemyPos.y) {
                enemyRigid.velocity = new Vector2(-1 * speed, -1 * speed);
            }
        }
    }

    //Returns AI home if player dies
    void returnHome() {
        if (playerStat.dead) {
            follow = false;
            Vector2 enemyPos;
            float xdiff, ydiff;
            enemyPos = enemyRigid.position;
            xdiff = startPos.x - enemyPos.x;
            ydiff = startPos.y - enemyPos.y;

            if ((xdiff < 25 && xdiff > -25) && startPos.y > enemyPos.y) {
                enemyRigid.velocity = new Vector2(0 * speed, 1 * speed);
            }
            else if ((xdiff < 25 && xdiff > -25) && startPos.y < enemyPos.y) {
                enemyRigid.velocity = new Vector2(0 * speed, -1 * speed);
            }
            else if (startPos.x > enemyPos.x && (ydiff < 25 && ydiff > -25)) {
                enemyRigid.velocity = new Vector2(1 * speed, 0 * speed);
            }
            else if (startPos.x < enemyPos.x && (ydiff < 25 && ydiff > -25)) {
                enemyRigid.velocity = new Vector2(-1 * speed, 0 * speed);
            }
            else if (startPos.x > enemyPos.x && startPos.y > enemyPos.y) {
                enemyRigid.velocity = new Vector2(1 * speed, 1 * speed);
            }
            else if (startPos.x > enemyPos.x && startPos.y < enemyPos.y) {
                enemyRigid.velocity = new Vector2(1 * speed, -1 * speed);
            }
            else if (startPos.x < enemyPos.x && startPos.y > enemyPos.y) {
                enemyRigid.velocity = new Vector2(-1 * speed, 1 * speed);
            }
            else if (startPos.x < enemyPos.x && startPos.y < enemyPos.y) {
                enemyRigid.velocity = new Vector2(-1 * speed, -1 * speed);
            }
        }
    }

    //If HeavyAttkCollide bool is true, activate charge move sequence.
    void chargePlayer() {
        if (heavyAC.activateCharge) {
            Vector2 playerPos = heavyAC.playerPos;
            Vector2 enemyPos = enemyTrans.position;
            follow = false;
            float xdiff, ydiff;
            xdiff = playerPos.x - enemyPos.x;
            ydiff = playerPos.y - enemyPos.y;

            if ((xdiff < 45 && xdiff > -45) && (ydiff < 45 && ydiff > -45)) {
                heavyAC.chargeCD = true;
                follow = true;
            }
            else if (enemyCollide.IsTouching(playerCollide)) {
                heavyAC.chargeCD = true;
                follow = true;
            }

            enemyRigid.velocity = new Vector2((xdiff/10) * chargeSpeed, (ydiff/10) * chargeSpeed);
        }
    }

	// Update is called once per frame
	void Update () {
        followPlayer();
        returnHome();
        chargePlayer();
    }
}
