using UnityEngine;
using System.Collections;

public class Cube_p_right : MonoBehaviour {
	
	private int max_health;
	
	public int damage;
	
	public Sprite d3;
	public Sprite d2;
	public Sprite d1;
	
	void Start (){
		max_health = 3;
		damage = 1;
	}
	
	void OnTriggerEnter2D(Collider2D other) {
//		Debug.Log(other.gameObject.name);
		if (other.gameObject.name == "Explosion(Clone)" ){
			max_health = max_health - damage;
			Check_Health ();
		}
       
    }
	
	public void Check_Health (){
		if (max_health == 2){
			transform.parent.GetComponent<SpriteRenderer>().sprite = d2;
		}
		if (max_health == 1){
			transform.parent.GetComponent<SpriteRenderer>().sprite = d1;
		}
		if (max_health <= 0){
			transform.parent.gameObject.SetActive(false);
			Destroy( transform.parent.gameObject);
		}
	}
	
}
