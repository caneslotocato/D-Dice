using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    //public GameObject dice;
    public int myDice;
    private Transform currentDice;


    void Awake()
    {
        currentDice = GameObject.Find("Current Dice").transform;
        //dice.SetActive(false);
        //GameController.instance.allDice[myDice].SetActive(false);
    }


    public void SetDice()
    {
        GameController.instance.isTap = false;
        /*
        //currentDice = null;
        //currentDice.SetActive(false);
        //Destroy(currentDice);
        GameObject cane = Instantiate(dice, dice.transform.position, dice.transform.rotation)as GameObject;
        Destroy(dice);
        //currentDice = dice;
        cane.GetComponent<Rigidbody>().useGravity = false;
        cane.SetActive(true);
        DontDestroyOnLoad(cane);
        Application.LoadLevel(Application.loadedLevel);
        */
        for (int i = 0; i < GameController.instance.allDice.Length; i++)
        {
            GameController.instance.allDice[i].SetActive(false);
        }
        GameController.instance.allDicesRb[myDice].useGravity = false;
        GameController.instance.allDice[myDice].SetActive(true);
        float a = Random.Range(0, 360);
        float b = Random.Range(0, 360);
        float c = Random.Range(0, 360);
        GameController.instance.allDicesTransform[myDice].rotation = Quaternion.Euler(a, b, c);
        GameController.instance.allDicesTransform[myDice].position = currentDice.position;
        GameController.instance.allDicesRb[myDice].constraints = RigidbodyConstraints.FreezeAll;
        GameController.instance.dicesButton.PlayReverse();
        GameController.instance.dicesMenu.PlayReverse();

    }



	
}
