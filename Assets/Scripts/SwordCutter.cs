using UnityEngine;
using System.Collections;
using Valve.VR;


//[RequireComponent (typeof(Rigidbody))]
public class SwordCutter : MonoBehaviour {

	public Material capMaterial;
	public SteamVR_Input_Sources inputSources;
	// Use this for initialization
	void Start () {

		
	}
	
	void Update(){
		//if(Input.GetMouseButtonDown(0)){
		//	RaycastHit hit;

		//	if(Physics.Raycast(transform.position, transform.forward, out hit)){

		//		GameObject victim = hit.collider.gameObject;

		//		GameObject[] pieces = BLINDED_AM_ME.MeshCut.Cut(victim, transform.position, transform.right, capMaterial);

		//		if(!pieces[1].GetComponent<Rigidbody>())
		//			pieces[1].AddComponent<Rigidbody>();

		//		Destroy(pieces[1], 1);
		//	}

		//}
	}

    private void OnCollisionEnter(Collision collision)
    {		
		GameObject victim = collision.collider.gameObject;

		if (victim.GetComponent<Fruit>() == null) return;

		GameObject[] pieces = BLINDED_AM_ME.MeshCut.Cut(victim, transform.position, transform.right	, capMaterial);

		if (!pieces[1].GetComponent<Rigidbody>())
        {
			var tempRigidBody = pieces[1].AddComponent<Rigidbody>();
			tempRigidBody.useGravity = true;
			var tempCollider = pieces[1].AddComponent<MeshCollider>();
			tempCollider.convex = true;

			SteamVR_Actions.default_Haptic[inputSources].Execute(0, 1.2f, 5, 1);			
		}
			

		Destroy(pieces[1], 1);		
	}


}
