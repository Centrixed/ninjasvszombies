using UnityEngine;
using System.Collections;

public class EnemyCollide : MonoBehaviour {

    private EnemyStatus enemyStat;
    private Transform enemyTrans;
    private Transform collTrans;
    private SpriteRenderer enemySprite;
    private SpriteRenderer collSprite;

    void Start() {
        enemyStat = gameObject.GetComponent<EnemyStatus>();
        enemyTrans = gameObject.GetComponent<Transform>();
        enemySprite = gameObject.GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D coll) {
        collSprite = coll.gameObject.GetComponent<SpriteRenderer>();
        collTrans = coll.gameObject.GetComponent<Transform>();
        if (coll.gameObject.tag == "Projectile") {
            enemyStat.isHit();
        }
        else if (coll.gameObject.tag == "Enemy") {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), coll.gameObject.GetComponent<Collider2D>(), true);
            enemySprite.sortingOrder = ((int)enemyTrans.position.y * -1);
            collSprite.sortingOrder = ((int)collTrans.position.y * -1);

        }
        else if (coll.gameObject.tag == "MainChar") {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), coll.gameObject.GetComponent<Collider2D>(), true);
            enemySprite.sortingOrder = ((int)enemyTrans.position.y * -1);
            collSprite.sortingOrder = ((int)collTrans.position.y * -1);
        }
    }

    void OnCollisionStay2D(Collision2D coll) {
        collSprite = coll.gameObject.GetComponent<SpriteRenderer>();
        collTrans = coll.gameObject.GetComponent<Transform>();
        if (coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "HeavyEnemy") {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), coll.gameObject.GetComponent<Collider2D>(), true);
            enemySprite.sortingOrder = ((int)enemyTrans.position.y * -1);
            collSprite.sortingOrder = ((int)collTrans.position.y * -1);
        }
        else if (coll.gameObject.tag == "MainChar") {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), coll.gameObject.GetComponent<Collider2D>(), true);
            enemySprite.sortingOrder = ((int)enemyTrans.position.y * -1);
            collSprite.sortingOrder = ((int)collTrans.position.y * -1);
        }
    }
}
