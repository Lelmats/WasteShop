using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using UnityEngine.SceneManagement;

public class ProgresoPHP : MonoBehaviour {

	public Text ProgresoNeurona;
	public Text ProgresoPuntaje;
	public Text ProgresoInternista;
	public Text ProgresoVara;
	public Text ProgresoObjetivo;
	public Text usuario;

	private String resultado="";
	private String resultadoObjetivo;


	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CargarProgreso()
	{
		StartCoroutine(ComprobarProgresoNuerona(usuario.text));
		StartCoroutine(ComprobarProgresoInternista(usuario.text));
		StartCoroutine(ComprobarProgresoPuntaje(usuario.text));
		StartCoroutine(ComprobarProgresoVara(usuario.text));
		StartCoroutine(ComprobarProgresoObjetivo(usuario.text));
	}

	public IEnumerator ComprobarProgresoNuerona(String uss)
	{
		//Debug.Log(Username);
		WWW conexion = new WWW("www.arevolution.com.mx/synaptix/progresoInsignias.php?uss=" + uss + "&pr=neurona");
		yield return (conexion);
		//Debug.Log(conexion.text);
		if (conexion.text.Equals("false"))
		{
			ProgresoNeurona.GetComponent<Text>().text = "0/1";
		}
		else if (conexion.text.Equals("true"))
		{
			ProgresoNeurona.GetComponent<Text>().text = "1/1";
		}
		
	}

	public IEnumerator ComprobarProgresoPuntaje(String uss)
	{
		//Debug.Log(Username);
		WWW conexion = new WWW("www.arevolution.com.mx/synaptix/progresoInsignias.php?uss=" + uss + "&pr=investigador");
		yield return (conexion);
		//Debug.Log(conexion.text);
		if (conexion.text.Equals("false"))
		{
			ProgresoPuntaje.GetComponent<Text>().text = "0/3";
		}
		else if (conexion.text.Equals("f1"))
		{
			ProgresoPuntaje.GetComponent<Text>().text = "1/3";
		}
		else if (conexion.text.Equals("f2"))
		{
			ProgresoPuntaje.GetComponent<Text>().text = "2/3";
		}
		else if (conexion.text.Equals("true"))
		{
			ProgresoPuntaje.GetComponent<Text>().text = "3/3";
		}
	}


	public IEnumerator ComprobarProgresoInternista(String uss)
	{
		//Debug.Log(Username);
		WWW conexion = new WWW("www.arevolution.com.mx/synaptix/progresoInsignias.php?uss=" + uss + "&pr=internista");
		yield return (conexion);
		//Debug.Log(conexion.text);
		if (conexion.text.Equals("false"))
		{
			ProgresoInternista.GetComponent<Text>().text = "0/3";
		}
		else if (conexion.text.Equals("f1"))
		{
			ProgresoInternista.GetComponent<Text>().text = "1/3";
		}
		else if (conexion.text.Equals("f2"))
		{
			ProgresoInternista.GetComponent<Text>().text = "2/3";
		}
		else if (conexion.text.Equals("true"))
		{
			ProgresoInternista.GetComponent<Text>().text = "3/3";
		}
	}


	public IEnumerator ComprobarProgresoVara(String uss)
	{
		//Debug.Log(Username);
		WWW conexion = new WWW("www.arevolution.com.mx/synaptix/progresoInsignias.php?uss=" + uss + "&pr=vara");
		yield return (conexion);
		//Debug.Log(conexion.text);
		if (conexion.text.Equals("false"))
		{
			ProgresoVara.GetComponent<Text>().text = "0/3";
		}
		else if (conexion.text.Equals("f1"))
		{
			ProgresoVara.GetComponent<Text>().text = "1/3";
		}
		else if (conexion.text.Equals("f2"))
		{
			ProgresoVara.GetComponent<Text>().text = "2/3";
		}
		else if (conexion.text.Equals("true"))
		{
			ProgresoVara.GetComponent<Text>().text = "3/3";
		}
	}

	public IEnumerator ComprobarProgresoObjetivo(String uss)
	{
		//Debug.Log(Username);
		resultadoObjetivo = "";
		WWW conexion = new WWW("www.arevolution.com.mx/synaptix/progresoObjetivo.php?uss=" + uss );
		yield return (conexion);
		//Debug.Log(conexion.text);
		if (conexion.text.Equals("false"))
		{
			ProgresoObjetivo.GetComponent<Text>().text = "0/3";
		}
		else if (conexion.text.Equals("f1"))
		{
			ProgresoObjetivo.GetComponent<Text>().text = "1/3";
		}
		else if (conexion.text.Equals("f2"))
		{
			ProgresoObjetivo.GetComponent<Text>().text = "2/3";
		}
		else if (conexion.text.Equals("true"))
		{
			ProgresoObjetivo.GetComponent<Text>().text = "3/3";
		}
	}

	public void MostrarProgreso()
	{/*
		StartCoroutine(ComprobarProgresoNuerona(usuario.text));
		StartCoroutine(ComprobarProgresoInternista(usuario.text));
		StartCoroutine(ComprobarProgresoPuntaje(usuario.text));
		StartCoroutine(ComprobarProgresoVara(usuario.text));
		StartCoroutine(ComprobarProgresoObjetivo(usuario.text));*/
	}
}
