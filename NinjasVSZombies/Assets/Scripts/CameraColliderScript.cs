using UnityEngine;
using System.Collections;

public class CameraColliderScript : MonoBehaviour {

    public BoxCollider2D cameraCollide;
    public Transform cameraPosComp;
    private Transform charPosComp;
    private Vector2 cameraPos;
    private Vector2 charPos;
    public bool isHolding = false;
    public bool isDouble = false;
    private Vector2 holdPos;

    public BoxCollider2D topCollide;
    public BoxCollider2D leftCollide;
    public BoxCollider2D rightCollide;
    public BoxCollider2D bottomCollide;


    void Start () {
        cameraCollide = GameObject.Find("CharCamera").GetComponent<BoxCollider2D>();
        cameraPosComp = GameObject.Find("CharCamera").GetComponent<Transform>();
        charPosComp = GameObject.Find("MainChar").GetComponent<Transform>();
    }
	
	void Update () {
        cameraPos = cameraPosComp.position;
        charPos = charPosComp.position;
        if (cameraCollide.IsTouching(bottomCollide) && cameraCollide.IsTouching(rightCollide))
        {
            if (!isHolding)
            {
                holdPos = cameraPos;
                isHolding = true;
            }
            else if (isHolding)
            {
                isDouble = true;
                holdPos = cameraPos;
            }

            if (charPos.y > cameraPos.y && charPos.x < cameraPos.x)
            {
                cameraPosComp.position = charPos;
                isHolding = false;
            }
            else if (charPos.y > cameraPos.y && charPos.x > cameraPos.x)
            {
                cameraPosComp.position = new Vector2(holdPos.x, charPos.y);
            }
            else if (charPos.y < cameraPos.y && charPos.x < cameraPos.x)
            {
                cameraPosComp.position = new Vector2(charPos.x, holdPos.y);
            }
            else
            {
                cameraPosComp.position = new Vector2(holdPos.x, holdPos.y);
            }
        }
        else if (cameraCollide.IsTouching(bottomCollide) && cameraCollide.IsTouching(leftCollide))
        {
            if (!isHolding)
            {
                holdPos = cameraPos;
                isHolding = true;
            }
            else if (isHolding)
            {
                isDouble = true;
                holdPos = cameraPos;
            }

            if (charPos.y > cameraPos.y && charPos.x > cameraPos.x)
            {
                cameraPosComp.position = charPos;
                isHolding = false;
            }
            else if(charPos.y > cameraPos.y && charPos.x < cameraPos.x)
            {
                cameraPosComp.position = new Vector2(holdPos.x, charPos.y);
            }
            else if(charPos.y < cameraPos.y && charPos.x > cameraPos.x)
            {
                cameraPosComp.position = new Vector2(charPos.x, holdPos.y);
            }
            else
            {
                cameraPosComp.position = new Vector2(holdPos.x, holdPos.y);
            }
        }
        else if (cameraCollide.IsTouching(topCollide) && cameraCollide.IsTouching(rightCollide))
        {
            if (!isHolding)
            {
                holdPos = cameraPos;
                isHolding = true;
            }
            else if (isHolding)
            {
                isDouble = true;
                holdPos = cameraPos;
            }

            if (charPos.y < cameraPos.y && charPos.x < cameraPos.x)
            {
                cameraPosComp.position = charPos;
                isHolding = false;
            }
            else if (charPos.y < cameraPos.y && charPos.x > cameraPos.x)
            {
                cameraPosComp.position = new Vector2(holdPos.x, charPos.y);
            }
            else if (charPos.y > cameraPos.y && charPos.x < cameraPos.x)
            {
                cameraPosComp.position = new Vector2(charPos.x, holdPos.y);
            }
            else
            {
                cameraPosComp.position = new Vector2(holdPos.x, holdPos.y);
            }
        }
        else if (cameraCollide.IsTouching(topCollide) && cameraCollide.IsTouching(leftCollide))
        {
            if (!isHolding)
            {
                holdPos = cameraPos;
                isHolding = true;
            }
            else if (isHolding)
            {
                isDouble = true;
                holdPos = cameraPos;
            }

            if (charPos.y < cameraPos.y && charPos.x > cameraPos.x)
            {
                cameraPosComp.position = charPos;
                isHolding = false;
            }
            else if (charPos.y < cameraPos.y && charPos.x < cameraPos.x)
            {
                cameraPosComp.position = new Vector2(holdPos.x, charPos.y);
            }
            else if (charPos.y > cameraPos.y && charPos.x > cameraPos.x)
            {
                cameraPosComp.position = new Vector2(charPos.x, holdPos.y);
            }
            else
            {
                cameraPosComp.position = new Vector2(holdPos.x, holdPos.y);
            }
        }
        else if (cameraCollide.IsTouching(topCollide))
        {
            isDouble = false;
            if (!isHolding) {
                holdPos = cameraPos;
                isHolding = true;
            }

            if (charPos.y < cameraPos.y)
            {
                cameraPosComp.position = charPos;
            }
            else
            {
                cameraPosComp.position = new Vector2(charPos.x, holdPos.y);
            }
        }
        else if (cameraCollide.IsTouching(bottomCollide))
        {
            isDouble = false;
            if (!isHolding)
            {
                holdPos = cameraPos;
                isHolding = true;
            }
            if (charPos.y > cameraPos.y)
            {
                cameraPosComp.position = charPos;
            }
            else
            {
                cameraPosComp.position = new Vector2(charPos.x, holdPos.y);
            }
        }
        else if (cameraCollide.IsTouching(leftCollide))
        {
            isDouble = false;
            if (!isHolding)
            {
                holdPos = cameraPos;
                isHolding = true;
            }
            if (charPos.x > cameraPos.x)
            {
                cameraPosComp.position = charPos;
            }
            else
            {
                cameraPosComp.position = new Vector2(holdPos.x, charPos.y);
            }
        }
        else if (cameraCollide.IsTouching(rightCollide))
        {
            isDouble = false;
            if (!isHolding)
            {
                holdPos = cameraPos;
                isHolding = true;
            }
            if (charPos.x < cameraPos.x)
            {
                cameraPosComp.position = charPos;
            }
            else
            {
                cameraPosComp.position = new Vector2(holdPos.x, charPos.y);
            }
        }
        else
        {
            isDouble = false;
            isHolding = false;
            cameraPosComp.position = charPos;
        }
	}
}
