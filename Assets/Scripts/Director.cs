using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Director : MonoBehaviour {


    private GameObject currentDrug;
    DrugController drugController;

    public int score;
    public GameObject scoreObj;
    public GameObject currentDrugObj;

    public GameObject[] drugs;

    private float span = 1.5f;
    private float delta = 0;

    private string[] drugNames = {
        "アセチルコリン",
        "ニコチン",
        "バンコマイシン",
        "レベチラセタム",
        "ジアゼパム",
        "ペニシリン"
    };

	// Use this for initialization
	void Start () {
        score = 1;

        int number = Random.Range(0, drugs.Length);
        currentDrug = Instantiate(drugs[number], transform.position, transform.rotation);
        currentDrugObj.GetComponent<Text>().text = drugNames[number];
    }
	
	// Update is called once per frame
	void Update () {
        drugController = currentDrug.GetComponent<DrugController>();
        bool isMoving = drugController.isMoving;
        bool canMove = drugController.canMove;
        scoreObj.GetComponent<Text>().text = score.ToString();
        if (isMoving == false && canMove==false)
        {
            delta += Time.deltaTime;
            if (delta > span)
            {
                score++;
                delta = 0;
                int number = Random.Range(0, drugs.Length);
                currentDrug = Instantiate(drugs[number], transform.position, transform.rotation);
                currentDrugObj.GetComponent<Text>().text = drugNames[number];
            }

        }
    }

    public void Rotate()
    {
        if (drugController.canMove == true)
        {
            currentDrug.transform.Rotate(new Vector3(0, 0, -30));
        }
    }
}
