using UnityEngine;
using System.Collections;

public class GunShot : MonoBehaviour {

	public int columns = 4;
    public int rows = 1;
    public float framesPerSecond = 30f;
 
	public void Start_this_Up (){	
		
		GetComponent<Renderer>().material.mainTextureScale = new Vector2(0.25f, 1);
		
		GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0,0);
		
		StartCoroutine(updateTiling());
		
	}
	
	private IEnumerator updateTiling(){
		while (true){
            if (GetComponent<Renderer>().material.mainTextureOffset.x >= 1f){
				this.gameObject.SetActive(false);
				break;	
			}
			
		GetComponent<Renderer>().material.mainTextureOffset = new Vector2(GetComponent<Renderer>().material.mainTextureOffset.x + 0.25f,
														GetComponent<Renderer>().material.mainTextureOffset.y);

		 yield return new WaitForSeconds(1f / framesPerSecond);
		}
	}
}
