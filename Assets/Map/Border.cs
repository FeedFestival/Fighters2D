using UnityEngine;
using System.Collections;

public class Border : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
//		Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Map"){
//			Start_this_Up();
		}
    }
}
