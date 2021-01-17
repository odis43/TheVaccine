
using UnityEngine;

public class rope : MonoBehaviour
{
	private bool grabbing;
	public Vector3 targetpos;
	public float comeback = 0.1f;
	public DistanceJoint2D joint;

	// Update is called once per frame
	void Update()
	{

		LineRenderer line = gameObject.GetComponentInChildren<LineRenderer>();
		line.startColor = Color.white;
		line.SetWidth(0.2f, 0.2f);

		if (Input.GetMouseButtonDown(1))
		{
			targetpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			targetpos.z = 0;
			grabbing = true;
			line.enabled = true;
			joint.enabled = true;
			FindObjectOfType<audiomanager>().Play("PlayerRope");
		}

		if (Input.GetMouseButton(1))
		{
			
			GameObject closest = FindNearest();
			line.positionCount = 2;
		
			
			if (grabbing)
			{
				line.SetPosition(1, closest.transform.position);
				closest.GetComponentInChildren<DistanceJoint2D>().connectedBody = gameObject.GetComponentInChildren<Rigidbody2D>();
				grabbing = false;
				

			}
			
			line.SetPosition(0, transform.position);
		}

	
			if (joint.distance > 13f)
		{
			line.enabled = false; 
			joint.enabled = false;
		}

		
		if (Input.GetMouseButtonUp(1))
		{
			line.enabled = false;
			GameObject[] hinges;
			hinges = GameObject.FindGameObjectsWithTag("hinge");
			line.enabled = false;
			joint.enabled = false;

			foreach (GameObject go in hinges)
			{
				go.GetComponentInChildren<DistanceJoint2D>().connectedBody = null;
			}

		}

	}

	GameObject FindNearest()
	{
		GameObject[] hinges;
		hinges = GameObject.FindGameObjectsWithTag("hinge");
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;

		foreach (GameObject go in hinges)
		{
			Vector3 diff = go.transform.position- targetpos;
			float curDistance = diff.sqrMagnitude;
			if (curDistance<distance)
			{
				closest = go;
				distance = curDistance;
			}
		}
		return closest;
	}
}
