using UnityEngine;
using System.Collections;

public class ParticleController : MonoBehaviour {

    public GameObject player;

	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position + new Vector3(0, -1f, 0);
	}
}
