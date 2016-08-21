using UnityEngine;
using System.Collections;

public class TreeLayerScript : MonoBehaviour {

    public SpriteRenderer layerControl;
    public BoxCollider2D charCollider;
    public BoxCollider2D stumpTrigger;
    public CircleCollider2D treeTrigger;
    public int StumpOrder = 0;
    public int TreeOrder = 0;

	// Use this for initialization
	void Start () {
        layerControl = GameObject.Find("MainChar").GetComponent<SpriteRenderer>();
        charCollider = GameObject.Find("MainChar").GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (stumpTrigger.IsTouching(charCollider) && treeTrigger.IsTouching(charCollider))
        {
            layerControl.sortingOrder = TreeOrder;
        }
        else if(stumpTrigger.IsTouching(charCollider))
        {
            layerControl.sortingOrder = StumpOrder;
        }
        else if(treeTrigger.IsTouching(charCollider))
        {
            layerControl.sortingOrder = TreeOrder;
        }
        else
        {
            layerControl.sortingOrder = 0;
        }
	}
}
