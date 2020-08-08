using UnityEngine;
using System.Collections;

public class Cube_p_Center : MonoBehaviour {

	public int max_health;
	
	public int damage;
	
	public Sprite d3;
	public Sprite d2;
	public Sprite d1;
	
	void Start (){
		
//		Debug.Log(transform.parent.transform.parent.childCount);
		
		max_health = 5;
		damage = 1;
	}
	
	void OnTriggerEnter2D(Collider2D other) {
	//	Debug.Log(transform.parent.transform.parent.childCount);
//		Debug.Log(other.gameObject.name);
		if (transform.parent.transform.parent.childCount == 1){
	//		Debug.Log("este singur");
		
			if (other.gameObject.name == "Explosion(Clone)" ){
			//	Debug.Log("intra singur");
				max_health = max_health - damage;
				Check_Health ();
			}
		}
    }
	
	public void Check_Health (){
		if (max_health == 4){
			transform.parent.GetComponent<SpriteRenderer>().sprite = d2;
		}
		if (max_health == 3){
			transform.parent.GetComponent<SpriteRenderer>().sprite = d2;
			transform.parent.gameObject.transform.localScale = new Vector3(0.9f,0.9f,1);
		}
		if (max_health == 2){
			transform.parent.GetComponent<SpriteRenderer>().sprite = d1;
			
		}
		if (max_health == 1){
			transform.parent.GetComponent<SpriteRenderer>().sprite = d1;
			transform.parent.gameObject.transform.localScale = new Vector3(0.7f,0.7f,1);
		}
		if (max_health <= 0){
			transform.parent.gameObject.SetActive(false);
		}
	}
	
}
