using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {
	
	
	
	public Vector3 direction;
	
	public GameObject Weapon;
	public GameObject explosion;
	public GameObject gunshot;
	
	public GameObject Barrel;
	
	public GameObject bullet;
	
	public RaycastHit2D hit;
	
	public float rotate_Speed;
	
	public bool spot;
	
	void Start (){
//		force = new Vector2(-1000,0);
		
		rotate_Speed = 0.5f;
		
		Screen.orientation = ScreenOrientation.Landscape;
  		Screen.SetResolution (Screen.currentResolution.width, Screen.currentResolution.height, true);
	}

	void FixedUpdate (){
		
		
		
		if (hit != null){
			direction = hit.point;
		}
		
		if (Input.GetKey(KeyCode.S)){
			if ((Weapon.transform.eulerAngles.z <= 318)&&(Weapon.transform.eulerAngles.z >= 90)){
				Weapon.transform.eulerAngles = new Vector3(Weapon.transform.eulerAngles.x,
													Weapon.transform.eulerAngles.y,
													318f);
			} else {
				Weapon.transform.eulerAngles = new Vector3(Weapon.transform.eulerAngles.x,
													Weapon.transform.eulerAngles.y,
													Weapon.transform.eulerAngles.z - rotate_Speed);
				Rotate(0,Mathf.Abs(Weapon.transform.eulerAngles.z));
			}
			
		}
		if (Input.GetKey(KeyCode.W)){
			
			if ((Weapon.transform.eulerAngles.z >= 50)&&(Weapon.transform.eulerAngles.z <= 60)){
				Weapon.transform.eulerAngles = new Vector3(Weapon.transform.eulerAngles.x,
													Weapon.transform.eulerAngles.y,
													50f);
			} else {
				Weapon.transform.eulerAngles = new Vector3(Weapon.transform.eulerAngles.x,
													Weapon.transform.eulerAngles.y,
													Weapon.transform.eulerAngles.z + rotate_Speed);
				Rotate(1,Mathf.Abs(Weapon.transform.eulerAngles.z));
			}
			
		}
		
		if (Input.GetKey(KeyCode.D)){
			transform.Translate(Vector2.right * 1.0f * Time.deltaTime);
			transform.localScale = new Vector3(1,1,1);
			
		}
		if (Input.GetKey(KeyCode.A)){
			transform.Translate(Vector2.right * -1.0f * Time.deltaTime);
			transform.localScale = new Vector3(-1,1,1);
		}
		if (Input.GetKeyDown(KeyCode.E)){
			Firev2 ();
		}
		
	}
	
	public void Rotate (int dir,float unghi){
				
				if ((unghi >= 0)&&(unghi <= 15)){
					
					Weapon.transform.localPosition = new Vector3(0 ,0 ,0 );
				}
				if ((unghi > 15)&&(unghi <= 20)){
					
					Weapon.transform.localPosition = new Vector3(0 ,-0.001f ,0 );
				}
				if ((unghi > 20)&&(unghi <= 25)){
					
					Weapon.transform.localPosition = new Vector3(0 ,- 0.003f ,0 );
				}
				if ((unghi > 25)&&(unghi <= 30)){
					
					Weapon.transform.localPosition = new Vector3(0.001f ,- 0.007f ,0 );
					
				}
				if ((unghi > 30)&&(unghi <= 35)){
					
					Weapon.transform.localPosition = new Vector3(0.005f ,- 0.01f ,0 );
				}
				if ((unghi > 35)&&(unghi <= 40)){
					
					Weapon.transform.localPosition = new Vector3(0.01f ,- 0.02f ,0 );
				}
				if ((unghi > 40)&&(unghi <= 43)){
					
					Weapon.transform.localPosition = new Vector3(0.01f ,- 0.04f,0 );
				}
				if ((unghi > 43)&&(unghi <= 46)){
					
					Weapon.transform.localPosition = new Vector3(0.02f,- 0.05f ,0 );
				}
				if ((unghi > 46)&&(unghi <= 50)){
					
					Weapon.transform.localPosition = new Vector3(0.03f ,- 0.07f ,0  );
				}
		//------------------------------------------------------------------------------------------------------
				if ((unghi >353)&&(unghi < 360)){
					
					Weapon.transform.localPosition = new Vector3(0 ,0.01f,0 );
				}
				if ((unghi > 348)&&(unghi <= 353)){
					
					Weapon.transform.localPosition = new Vector3(0 ,0.015f ,0  );
				}
				if ((unghi > 343)&&(unghi <= 348)){
					
					Weapon.transform.localPosition = new Vector3(0 ,0.02f ,0  );
				}
				if ((unghi > 335)&&(unghi <= 343)){
					
					Weapon.transform.localPosition = new Vector3(0 ,0.03f ,0  );
				}
				if ((unghi > 330)&&(unghi <= 335)){
					
					Weapon.transform.localPosition = new Vector3(-0.003f ,0.04f ,0  );
				}
				if ((unghi > 318)&&(unghi <= 330)){
					
					Weapon.transform.localPosition = new Vector3(-0.0035f ,0.067f ,0  );
				}
		Barrel.transform.eulerAngles = Weapon.transform.eulerAngles;
	}
	
	
	public void Firev2 () {
		GameObject explosion_clone;
		
		gunshot.SetActive(true);
		gunshot.GetComponent<GunShot>().Start_this_Up();
		
		explosion_clone = Instantiate (explosion,Weapon.transform.position,Quaternion.Euler (
													new Vector3(Weapon.transform.eulerAngles.x,
													Weapon.transform.eulerAngles.y,
													Weapon.transform.eulerAngles.z))) as GameObject;
		
		explosion_clone.transform.position = direction;
		explosion_clone.gameObject.GetComponent<Rigidbody2D>().isKinematic = true ;
	}
}