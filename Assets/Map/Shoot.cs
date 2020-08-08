using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public GameObject weapon;
	
	void OnMouseDown(){
        
		weapon.GetComponent<test>().Firev2();
    }
}
