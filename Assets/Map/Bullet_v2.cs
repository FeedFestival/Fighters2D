using UnityEngine;
using System.Collections;

public class Bullet_v2 : MonoBehaviour {
	
	public GameObject expl;
	
	public Animator explosion;
	
	void Awake(){
		//expl.GetComponent<Poof>().Play();
		
		
		
	} 

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Map" ){
			//this.gameObject.rigidbody2D.isKinematic = true;
			expl.SetActive(true);
			
			expl.GetComponent<Poof>().Start_this_Up();
			
		}
//		Debug.Log("Am Lovit " + coll.gameObject.name);
	}
	
	public void stop (){
		this.gameObject.SetActive(false);
		Destroy(this.gameObject);
	}
}
