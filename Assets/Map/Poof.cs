using UnityEngine;
using System.Collections;

public class Poof : MonoBehaviour {
	
	public int columns = 5;
    public int rows = 1;
    public float framesPerSecond = 10f;
 
	public void Start_this_Up (){	
		
		GetComponent<Renderer>().material.mainTextureScale = new Vector2(0.2f, 1);
		
		GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0,0);
		
		StartCoroutine(updateTiling());
		
	}
	
	void OnTriggerEnter2D(Collider2D other) {
//		Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Map"){
			Start_this_Up();
		}
    }
	
	private IEnumerator updateTiling(){
		while (true){
            if (GetComponent<Renderer>().material.mainTextureOffset.x == 1.2f){
				this.transform.parent.GetComponent<Bullet_v2>().stop();
				break;	
			}
			
		GetComponent<Renderer>().material.mainTextureOffset = new Vector2(GetComponent<Renderer>().material.mainTextureOffset.x + 0.2f,
														GetComponent<Renderer>().material.mainTextureOffset.y);

		 yield return new WaitForSeconds(1f / framesPerSecond);
		}
	}
}


