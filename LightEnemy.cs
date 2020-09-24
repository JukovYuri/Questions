using UnityEngine;
using System.Collections;

public class LightEnemy : MonoBehaviour {
	public Vector3 Rotate_light;
	public float speed;
	GameObject _target;
	Quaternion startRotate;



void Start()
{
	startRotate = transform.rotation;
}


	void Update () {
		if (_target)
		{
			transform.LookAt(_target.transform);
		}
		else
		{
			transform.Rotate(Rotate_light * Time.deltaTime * speed);	
		}
			}

void OnTriggerEnter(Collider other)
{
	if (other.gameObject.name == "Player")
	{
		_target = other.gameObject;
	}
}

void OnTriggerExit(Collider other)
{
	if (other.GetComponent<PlayerControllers>())
	{
		_target = null;
		transform.rotation = startRotate;
		print(other.GetComponent<PlayerControllers>());
	}
}


}
