using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour {
    public float time;
    public GameObject QuestionMark;
	// Use this for initialization
	void Start () {
        StartCoroutine(NeedHelp());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator NeedHelp()
    {
        yield return new WaitForSeconds(time);
        Handheld.Vibrate();
        QuestionMark.SetActive(true);
    } 
}
