using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    
    public GameObject[] allDice;
    private float forceToAdd;
    public float maxRange;
    public float start;
    public static GameController instance;


    void Awake()
    {
        instance = this;
        for(int i = 0; i < allDice.Length; i++)
        {
            allDice[i].SetActive(false);
        }
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        forceToAdd = Random.Range(start - maxRange, start + maxRange);
        WatchRaycast(forceToAdd);
	}

    void WatchRaycast(float force)
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                hit.rigidbody.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                hit.rigidbody.useGravity = true;
                hit.rigidbody.AddForceAtPosition(ray.direction * force, hit.point);
                
            }
        }
    }
}
