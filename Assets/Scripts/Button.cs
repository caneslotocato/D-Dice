using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    public GameObject dice;
    private Transform currentDice;


    void Awake()
    {
        currentDice = GameObject.Find("Current Dice").transform;
        
    }


    public void SetDice()
    {
        dice.transform.position = currentDice.position;
        //currentDice.transform.position = new Vector3(5000, 5000, 5000);
        //currentDice.GetComponent<Rigidbody>().useGravity = false;
        
        currentDice.GetComponent<Rigidbody>().useGravity = false;
    }



	
}
