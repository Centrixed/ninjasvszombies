using UnityEngine;
using System.Collections;

public class EnemyStatus : MonoBehaviour {

    public float health = 100;
    public int deathValue = 50;
    public bool dead = false;
    public GameObject AIHpAnchor;
    private float startHP;
    private GameObject player;
    private PlayerStatus playerStat;
    private MovementScript playerMove;
    private Transform AIScale;
    private Rigidbody2D physics;
    private BoxCollider2D enemyCollide;
    private Vector2 deathLocation;
    private RigidbodyConstraints2D pos;

	// Use this for initialization
	void Start () {
        startHP = health;
        player = GameObject.Find("MainChar");
        playerMove = player.GetComponent<MovementScript>();
        playerStat = player.GetComponent<PlayerStatus>();
        AIScale = AIHpAnchor.GetComponent<Transform>();
        physics = GetComponent<Rigidbody2D>();
        enemyCollide = GetComponent<BoxCollider2D>();
        pos = RigidbodyConstraints2D.FreezeAll;
	}
    
    public void isHit() {
        health -= playerMove.ThrowDamage;
    }

    void Death() {
        if (health <= 0) {
            if (dead) {
                health = 0;
                physics.position = deathLocation;
            }
            else {
                deathLocation = physics.position;
                physics.position = deathLocation;
                physics.constraints = pos;
                enemyCollide.enabled = false;
                playerStat.kills += 1;
                playerStat.score += deathValue;
                dead = true;
                health = 0;
                Destroy(gameObject, 0.75f);
            }
        }
    }

    // Update is called once per frame
    void Update () {
        Death();
        Vector2 hpHold = AIScale.localScale;
        hpHold.x = health / startHP;
        AIScale.localScale = hpHold;
	}
}
