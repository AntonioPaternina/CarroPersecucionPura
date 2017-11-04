using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trayectoria : MonoBehaviour {

    public float wti;
    public float wtd;

	// Use this for initialization
	void Start () {
        GameObject destino = GameObject.Find("PuntoRojo");

        float xg = destino.transform.position.x;
        float yg = destino.transform.position.z;
        float x0 = this.transform.position.x;
        float y0 = this.transform.position.z;
        Vector3 anguloOrigen = this.transform.rotation.eulerAngles;
        float anguloRadianes = anguloOrigen.magnitude * Mathf.Deg2Rad;

        float x = (xg - x0) * Mathf.Cos(anguloRadianes)
            + (yg - y0) * Mathf.Sin(anguloRadianes);
        float y = -(xg - x0) * Mathf.Sin(anguloRadianes)
           + (yg - y0) * Mathf.Cos(anguloRadianes);

        float D = Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2));
        float r = Mathf.Pow(D, 2) / (2 * x);
        float rho = (2 * x) / Mathf.Pow(D, 2);

        float b = GameObject.Find("Eje").transform.lossyScale.y * 2;
        calcularVelocidades(rho, b);
    }
	
	// Update is called once per frame
	void Update () {
       
    }

    void calcularVelocidades(float rho, float b)
    {
        wtd = 5;
        float temp = (2 + rho * b) / (2 - rho * b);
        wti = wtd * temp;
    }
}
