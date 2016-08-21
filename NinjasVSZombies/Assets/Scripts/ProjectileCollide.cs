using UnityEngine;
using System.Collections;

public class ProjectileCollide : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Radius") {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), coll.gameObject.GetComponent<Collider2D>(), true);
        }
        else if (coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "HeavyEnemy") {
            Destroy(gameObject, 0.02f);
        }
        else if (coll.gameObject.tag == "Wall") {
            Destroy(gameObject);
        }
    }

    void OnCollisionStay2D(Collision2D coll) {
        if (coll.gameObject.tag == "Radius") {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), coll.gameObject.GetComponent<Collider2D>(), true);
        }
        else if (coll.gameObject.tag == "Wall") {
            Destroy(gameObject);
        }
    }
}
