using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    
    public GameObject[] allDice;
    private float forceToAdd;
    public float maxRange;
    public float start;
    [HideInInspector]
    public bool isTap;
    public static GameController instance;
    public TweenPosition dicesMenu;
    public TweenPosition dicesButton;
    [HideInInspector]
    public Transform[] allDicesTransform;
    [HideInInspector]
    public Rigidbody[] allDicesRb;


    void Awake()
    {
        allDicesRb = new Rigidbody[allDice.Length];
        allDicesTransform = new Transform[allDice.Length];
        instance = this;
        for(int i = 0; i < allDice.Length; i++)
        {
            allDicesTransform[i] = allDice[i].transform;
            allDicesRb[i] = allDice[i].GetComponent<Rigidbody>();
            allDice[i].SetActive(false);
        }
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetMouseButtonDown(0) && isTap == false)
        {
            forceToAdd = Random.Range(start - maxRange, start + maxRange);
            WatchRaycast(forceToAdd);
            Debug.Log(isTap);
        }
	}

    void WatchRaycast(float force)
    {
        
        
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                
                hit.rigidbody.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                hit.rigidbody.useGravity = true;
                hit.rigidbody.AddForceAtPosition(ray.direction * force, hit.point);
                if(hit.transform.gameObject.tag == "dice")
                    isTap = true;

            }
        }
    
}
