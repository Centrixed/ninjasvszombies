using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStatus : MonoBehaviour {

    public int score;
    public int kills = 0;
    public float health = 100;
    public float energy = 100;
    public float energyRegenRate;
    private RectTransform healthScale;
    private RectTransform energyScale;
    private A1L1Script levelScript;
    private Animator animate;
    private Animator deathAnimate;
    private Rigidbody2D physics;
    private Vector2 deathLocation;
    public bool dead = false;

	// Use this for initialization
	void Start () {
        healthScale = GameObject.Find("HealthAnchor").GetComponent<RectTransform>();
        energyScale = GameObject.Find("EnergyAnchor").GetComponent<RectTransform>();
        deathAnimate = GameObject.Find("DeathScreen").GetComponent<Animator>();
        levelScript = GameObject.Find("EventSystem").GetComponent<A1L1Script>();
        animate = GetComponent<Animator>();
        physics = GetComponent<Rigidbody2D>();
        score = PlayerPrefs.GetInt("Score", 0);
    }
	
    void Death() {
        if(health <= 0) {
            if (dead) {
                health = 0;
                physics.MovePosition(deathLocation);
            }
            else {
                deathLocation = physics.position;
                animate.SetBool("isDead", true);
                physics.MovePosition(deathLocation);
                StartCoroutine("deathScreen");
                dead = true;
                health = 0;
            }
        }
    }

    IEnumerator deathScreen() {
        yield return new WaitForSeconds(1.5f);
        deathAnimate.SetTrigger("death");
    }

	// Update is called once per frame
	void Update () {
        Death();
        Vector2 hpHold = healthScale.localScale;
        Vector2 enHold = energyScale.localScale;
        hpHold.x = health / 100;
        enHold.x = energy / 100;
        healthScale.localScale = hpHold;
        energyScale.localScale = enHold;

        if (levelScript.levelOver) {
            Destroy(gameObject, 0.5f);
        }
	}

    void FixedUpdate() {
        if (energy < 100) {
            energy += energyRegenRate;
        }
    }
}
