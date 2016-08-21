using CnControls;
using UnityEngine;
using System.Collections;

public class JoystickBarrier : MonoBehaviour {

    public CircleCollider2D joyCollide;
    public SimpleJoystick joyStick;
	
	// Update is called once per frame
	void Update () {
        if (joyCollide.IsTouching(gameObject.GetComponent<BoxCollider2D>())) {
            Debug.Log("Out of range");
            joyStick.SnapsToFinger = false;
        }
        joyStick.SnapsToFinger = true;
	}
}
