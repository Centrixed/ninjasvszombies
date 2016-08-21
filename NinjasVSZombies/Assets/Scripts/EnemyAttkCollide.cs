using UnityEngine;
using System.Collections;

public class EnemyAttkCollide : MonoBehaviour {

    private GameObject player;
    private BoxCollider2D playerCollide;
    private PlayerStatus playerStat;
    private CircleCollider2D radiusCollide;
    private Animator enemyAni;
    private bool stopRepeat = false;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("MainChar");
        playerCollide = player.GetComponent<BoxCollider2D>();
        playerStat = player.GetComponent<PlayerStatus>();
        radiusCollide = gameObject.GetComponent<CircleCollider2D>();
        enemyAni = gameObject.GetComponentInParent<Animator>();
    }

    void Update() {
        if (radiusCollide.IsTouching(playerCollide)) {
            if (!stopRepeat && !playerStat.dead) {
                enemyAni.SetBool("Attack", true);
                stopRepeat = true;
                StartCoroutine("attackSeq");
            }
        }
        else if (!radiusCollide.IsTouching(playerCollide)) {
            enemyAni.SetBool("Attack", false);
            stopRepeat = false;
        }
    }

    //handles the attacking & damage and pausing between each attack
    IEnumerator attackSeq() {
        yield return new WaitForSeconds(0.55f);
        if (radiusCollide.IsTouching(playerCollide)) {
            playerStat.health -= 10;
            stopRepeat = false;
        }
    }
}
