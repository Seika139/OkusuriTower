using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DrugController : MonoBehaviour {

    private Rigidbody2D rgbd;
    public float velocity;

    // 位置座標
    private Vector3 position;
    // スクリーン座標をワールド座標に変換した位置座標
    private Vector3 screenToWorldPointPosition;


    public bool canMove;
    public bool isMoving;

    // Use this for initialization
    void Start () {
        rgbd = this.GetComponent<Rigidbody2D>();
        rgbd.bodyType = RigidbodyType2D.Static;
        canMove = true;
        isMoving = false;
        transform.position = new Vector3(0, 3, 0);
    }
	
	// Update is called once per frame
	void Update () {
        velocity = rgbd.velocity.magnitude;
        // ボタンを押した時に画面のタッチを無視したい
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButton(0) && canMove == true)
            {
                position = Input.mousePosition;
                // マウス位置座標をスクリーン座標からワールド座標に変換する
                screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(position);
                // ワールド座標に変換されたマウス座標のx座標を代入
                gameObject.transform.position = new Vector3(screenToWorldPointPosition.x, 3, 0);
            }
            else if (Input.GetMouseButtonUp(0) && canMove == true)
            {
                rgbd.bodyType = RigidbodyType2D.Dynamic;
                canMove = false;
                isMoving = true;
            }
        }
        if (isMoving==true && transform.position.y<2.5 && velocity<1.0e-3)
        {
            isMoving = false;
        }
    }


}
