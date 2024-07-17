using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginPHP : MonoBehaviour
{
	public GameObject username;
	public GameObject password;
	// public GameObject usernameUpdate;
	// public GameObject passwordUpdate;

	public static string Username;
	private string Password;

	public Text mensaje;
	public Text mensajeVerf;

	public void iniciarSesion()
	{
		StartCoroutine(Login());
	}
	
	public void ExitApp(){
		Application.Quit();
    }
	private void ChangeSceneEvent(){
		SceneManager.LoadScene("Menu");
    }
	IEnumerator Login()
	{
		// Debug.Log("Usuario: " + Username + "Clave: " + Password);
		// http://localhost/Preexamen/login.php?nombre=Max&contrasena=123
		// Debug.Log("Conexion.text: " + conexion.text);
		WWW conexion = new WWW("http://www.sistematizamx.com.mx/max/WasteShop/login.php?user=" + Username + "&pass=" + Password);
		yield return (conexion);
		if (conexion.text == "bien")
		{
			mensaje.gameObject.SetActive(true);
			mensajeVerf.gameObject.SetActive(false);
			// Debug.Log("Iniciaste Sesión, Hola " + Username + "!");
			Invoke("ChangeSceneEvent", 1f);
		}
		else
		{
			mensaje.gameObject.SetActive(false);
			mensajeVerf.gameObject.SetActive(true);
			Debug.Log("Verificar los datos");
		}
	}
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		Debug.Log("Usuario: " + Username );
		if (Input.GetKey("escape"))
		{
			Application.Quit();
		}
		// Debug.Log("Usuario:" + Username + "Constraseña:" + Password);
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			if (username.GetComponent<InputField>().isFocused)
			{
				mensaje.gameObject.SetActive(false);
				mensajeVerf.gameObject.SetActive(false);
				password.GetComponent<InputField>().Select();
			}
		}
		if (Input.GetKeyDown(KeyCode.Return))
		{
			if (Password != "" && Password != "")
			{
				iniciarSesion();
			}
		}
		Username = username.GetComponent<InputField>().text;
		Password = password.GetComponent<InputField>().text;
		Username = username.GetComponent<InputField>().text;
		Password = password.GetComponent<InputField>().text;
	}
}
