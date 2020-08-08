using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public LayerMask layerMask; //make sure we aren't in this layer 
	public float skinWidth = 0.1f; //probably doesn't need to be changed 
 
	private float minimumExtent; 
	private float partialExtent; 
	private float sqrMinimumExtent; 
	private Vector3 previousPosition; 
	private Rigidbody2D myRigidbody; 
 
 
	//initialize values 
	void Awake() 
	{ 
	   myRigidbody = GetComponent<Rigidbody2D>();
	   previousPosition = transform.position; 
		
		Vector3 extents = GetComponent<BoxCollider2D>().size * 0.5f;
		
	   minimumExtent = Mathf.Min(Mathf.Min(extents.x, extents.y), extents.z); 
	   partialExtent = minimumExtent * (1.0f - skinWidth); 
	   sqrMinimumExtent = minimumExtent * minimumExtent; 
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Map" ){
			//this.gameObject.rigidbody2D.isKinematic = true;
			
		}
		Debug.Log("Am Lovit" + coll);
	}
 
	void FixedUpdate() 
	{ 
	   //have we moved more than our minimum extent? 
	   Vector3 movementThisStep = transform.position - previousPosition; 
	   float movementSqrMagnitude = movementThisStep.sqrMagnitude;
 
	   if (movementSqrMagnitude > sqrMinimumExtent) 
		{ 
	      float movementMagnitude = Mathf.Sqrt(movementSqrMagnitude);
	      RaycastHit hitInfo; 
 
	      //check for obstructions we might have missed 
	      if (Physics.Raycast(previousPosition, movementThisStep, out hitInfo, movementMagnitude, layerMask.value)) 
	         transform.position = hitInfo.point - (movementThisStep/movementMagnitude)*partialExtent; 
	   } 
 
	   previousPosition = transform.position; 
	}
}
