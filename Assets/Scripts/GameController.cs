using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private float forceToAdd;
    public float maxRange;
    public float start;

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
                hit.rigidbody.useGravity = true;
                hit.rigidbody.AddForceAtPosition(ray.direction * force, hit.point);
            }
        }
    }
}
