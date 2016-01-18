using UnityEngine;
using System.Collections;

public class Dust : MonoBehaviour {

    public float counter;
    public GameObject dust;
    public float destroytime;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        counter += Time.deltaTime;
        if (counter >= destroytime)
        {
            Destroy(dust);
        }
	}
}
