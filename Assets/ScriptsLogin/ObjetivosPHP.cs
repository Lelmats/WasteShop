using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using UnityEngine.SceneManagement;

public class ObjetivosPHP : MonoBehaviour {

	public GameObject barra;
	public GameObject barra2;
	public GameObject barra3;

	public Text usuario;
	private string Username;

	// Use this for initialization
	void Start () {
		StartCoroutine(ComprobarObjetivo());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void VerObjetivo() {
		StartCoroutine(ComprobarObjetivo());
	}

	public IEnumerator ComprobarObjetivo()
	{
		Username = usuario.text;

		//Debug.Log(Username);
		WWW conexion = new WWW("www.arevolution.com.mx/synaptix/objetivos.php?uss=" + Username);
		yield return (conexion);
		//Debug.Log(con);
		//Debug.Log(conexion.text);
		if (conexion.text.Equals("false"))
		{
			barra.gameObject.SetActive(false);
			barra2.gameObject.SetActive(false);
			barra3.gameObject.SetActive(false);
		}
		if (conexion.text.Equals("f1"))
		{
			barra.gameObject.SetActive(true);
			barra2.gameObject.SetActive(false);
			barra3.gameObject.SetActive(false);
		}
		if (conexion.text.Equals("f2"))
		{
			barra.gameObject.SetActive(false);
			barra2.gameObject.SetActive(true);
			barra3.gameObject.SetActive(false);
		}
		if (conexion.text.Equals("true"))
		{
			barra.gameObject.SetActive(false);
			barra2.gameObject.SetActive(false);
			barra3.gameObject.SetActive(true);
		}
	}




}
