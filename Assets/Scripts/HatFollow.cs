using UnityEngine;
using System.Collections;

public class HatFollow : MonoBehaviour {
    public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(player.transform.position.x, (float)(player.transform.position.y + 0.3), player.transform.position.z);
	}
}
