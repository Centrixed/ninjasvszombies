using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public GameObject projectilePrefab;
    public BoxCollider2D enemyCollide;
    private BoxCollider2D projCollide;
    public float speed = 0f;
    private Rigidbody2D playerRigid;
    private Rigidbody2D cloneRigid;
    private GameObject clone;
    private MovementScript playerMove;
    private SpriteRenderer playerSprite;
    private Vector2 projectileSpeed;
    private Vector2 faceAdjust;
    private bool shot = false;

	void Start () {
        playerRigid = GetComponent<Rigidbody2D>();
        playerMove = GetComponent<MovementScript>();
        playerSprite = GetComponent<SpriteRenderer>();
    }
	
	void Update () {

        //If Player is facing right, adjust projectile direction on x axis.
        if (!playerSprite.flipX) {
            projectileSpeed = new Vector2(1 * speed, 0);
            faceAdjust = new Vector2(1 , 0);
        }
        //If Player is facing left, reverse projectile direction on x axis.
        else if (playerSprite.flipX){
            projectileSpeed = new Vector2(-1 * speed, 0);
            faceAdjust = new Vector2(-1 , 0);
        }

        //Calls the isThrowing bool from another script, which mediates cooldown time between throws.
        if (playerMove.isThrowing) {
            if (!shot) {
                shoot();
                shot = true;
            }
        }
        else if (!playerMove.isThrowing) {
            shot = false;
        }
	}


    //Instantiates the object using the projectile prefab, then rotates/scales it accordingly and projects it outwards.
    void shoot() {
        //Instantiates the projectile, and gets components of the clone to work with.
        clone = (GameObject)Instantiate(projectilePrefab, playerRigid.position + faceAdjust, Quaternion.identity);
        cloneRigid = clone.GetComponent<Rigidbody2D>();
        Transform cloneTrans = clone.GetComponent<Transform>();

        //Rotates the sprite so it visually flies in the correct direction
        if (playerMove.faceDirection) {
            cloneTrans.Rotate(0, 0, 270);
        }
        else {
            cloneTrans.Rotate(0, 0, 90);
        }
        //Scales the sprite to a feasable size
        cloneTrans.localScale = new Vector3(20, 17, 1);

        //Applies velocity and destroy clone after 3.5 seconds
        cloneRigid.velocity = projectileSpeed;

        Destroy(clone, 3.5f);
    }
}
