using UnityEngine;
using System.Collections;

public class sensor : MonoBehaviour {

	public bool valor;
	public float distancia;
	Color col;
	// Use this for initialization
	void Start () {
		valor = false;
		col = new Color (0, 0, 0);
	}

	// Update is called once per frame
	void Update () {
		valor = false;
		RaycastHit hit;
		Ray ray = new Ray (this.transform.position, transform.up);
		Debug.DrawRay(transform.position, transform.up*10, Color.green);
		if (Physics.Raycast (ray, out hit)) {
			if (hit.collider != null) {
				distancia = hit.distance;
				if (hit.distance < 10) {
					Renderer r = hit.collider.GetComponentInParent<Renderer> ();
					//Debug.Log ("Color = " + r.material.color);
					if (r.material.color == col) {
						valor = true;
					}else {
						valor = false;
					}
				} else {
					valor = false;
				}
			}else {
				valor = false;
			}
		}
		Debug.Log (valor);
	}

}
