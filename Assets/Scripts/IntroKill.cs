using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IntroKill : MonoBehaviour {

    public Text t;

	// Use this for initialization
	void Start () {
        StartCoroutine(kill());
	}

    IEnumerator kill()
    {
        yield return new WaitForSeconds(5);
        t.text = "";
    }
}
