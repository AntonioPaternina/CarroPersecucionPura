using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour {
	public float wd;
	public float wi;
	private float r;
	private float b;
	// Use this for initialization
	void Start () {
		wd = 0f;
		wi = 0f;
		b = GameObject.Find ("Eje").transform.lossyScale.y*2;
		r = GameObject.Find ("Rueda_d").transform.lossyScale.x/2;
	}
	
	// Update is called once per frame
	void Update () {
        settearVelocidades();
        float delta_t = Time.deltaTime;
		float delta_angulo = r / b * (wi - wd) * delta_t;
		float angulo = GameObject.Find ("Robot").transform.eulerAngles.y;
		GameObject.Find("Robot").transform.eulerAngles = new Vector3(0 , angulo + delta_angulo*180/Mathf.PI , 0);
		Vector3 robot_pos = GameObject.Find ("Robot").transform.position;
		float delta_x;
		float delta_y;
		if (wd == wi) {
			delta_x = r / 2 * (wd + wi) * delta_t * -Mathf.Cos ((90+angulo)*Mathf.PI/180);
			delta_y = r / 2 * (wd + wi) * delta_t * Mathf.Sin ((90+angulo)*Mathf.PI/180);
			robot_pos.x = robot_pos.x + delta_x;
			robot_pos.z = robot_pos.z + delta_y;
			GameObject.Find ("Robot").transform.position = robot_pos;
		} else {
			delta_x = b / 2 * ((wd + wi)/(wi-wd)) * (Mathf.Cos(angulo*Mathf.PI/180) - Mathf.Cos(angulo*Mathf.PI/180+delta_angulo));
			delta_y = b / 2 * ((wd + wi)/(wi-wd)) * (-Mathf.Sin(angulo*Mathf.PI/180) + Mathf.Sin(angulo*Mathf.PI/180+delta_angulo));
			robot_pos.x = robot_pos.x + delta_x;
			robot_pos.z = robot_pos.z + delta_y;
			GameObject.Find ("Robot").transform.position = robot_pos;
		}   
    }

	void f_inicia () {
		wi = 0;//1*2*Mathf.PI;
		wd = 1*2*Mathf.PI;
		//wd = 0;
		Invoke ("f_termina", 1);
	}
	void f_termina () {
		wd = 0;
		wi = 0;
	}

    void settearVelocidades()
    {
        wi = GameObject.Find("Robot").GetComponent<trayectoria>().wti;
        wd = GameObject.Find("Robot").GetComponent<trayectoria>().wtd;
    }

}
