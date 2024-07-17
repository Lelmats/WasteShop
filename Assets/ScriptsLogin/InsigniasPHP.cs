using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using UnityEngine.SceneManagement;

public class InsigniasPHP : MonoBehaviour
{
	string Username = LoginPHP.Username;

	// public GameObject Logro1;
	// public GameObject Logro2;
	// public GameObject Logro3;
	// public GameObject Logro4;

	public GameObject Logro1Des;
	public GameObject Logro2Des;
	public GameObject Logro3Des;
	public GameObject Logro4Des;

	// private String[] Lines;
	// public Text usuario;

	// public GameObject username;
	// public GameObject password;

	// private string Username;


	// Use this for initialization
	void Start()
	{
		Logro1Des.gameObject.SetActive(true);
		Logro2Des.gameObject.SetActive(true);
		Logro3Des.gameObject.SetActive(true);
		Logro4Des.gameObject.SetActive(true);
		StartCoroutine(ComprobarLogros());
		Debug.Log("Nombre de usuario: " + Username);
	}

	
	public IEnumerator ComprobarLogros()
	{		
		// usuario.text = Username;

		WWW conexion = new WWW("http://www.sistematizamx.com.mx/max/WasteShop/consultaInsignias.php?user=" + Username);
		yield return conexion;
		
		if (!string.IsNullOrEmpty(conexion.error))
		{
			Debug.LogError("Error al conectar: " + conexion.error);
			yield break;
		}
		
		string[] logros = conexion.text.Trim().Split(','); 
		
		Debug.Log("Logros: " + conexion.text );
		Debug.Log("Logros cantidad: " + logros.Length);
		
		for (int i = 0; i < logros.Length; i++)
		{
			bool logro = logros[i] == "1";

			Debug.Log("Logro " + i + ": " + logro);

			switch (i)
			{
				case 0:
					Logro1Des.gameObject.SetActive(!logro);
					break;
				case 1:
					Logro2Des.gameObject.SetActive(!logro);
					break;
				case 2:
					Logro3Des.gameObject.SetActive(!logro);
					break;
				case 3:
					Logro4Des.gameObject.SetActive(!logro);
					break;
				default:
					Debug.LogWarning("Se encontró un número inesperado de logros.");
					break;
			}
			
		}
	}
}
