using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
	
	public Transform range;
	
	public RaycastHit2D hit;
	
	// Use this for initialization
	void Start () {
	
	}
	
	public void set_Angle(){
		
	}
	
	void FixedUpdate (){
		
		
		//RaycastHit2D hit = Physics2D.Raycast(Weapon.transform.position,range.position,Color.green);
		
		Debug.DrawLine (this.transform.position,range.position,Color.green);
		
		RaycastHit2D hit = Physics2D.Linecast(this.transform.position,range.position,
																		1 << LayerMask.NameToLayer ("Shootable"));
		//Debug.Log(hit.collider.gameObject.name);
	}
}
