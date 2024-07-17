using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class RegisterPHP : MonoBehaviour
{
	public GameObject username;
	// public GameObject email;
	public GameObject password;
	// public GameObject confPassword;
	public Text mensaje;
	private string Username;
	// private string Email;
	private string Password;
	// private string ConfPassword;
	private string form;
	private long Scorm;

	void start(){
		mensaje.gameObject.SetActive(false);
	}
	// private bool EmailValid = false;
	private string[] Characters = {"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z",
								   "A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z",
								   "1","2","3","4","5","6","7","8","9","0","_","-"};

	public void RegisterButton()
	{
		bool UN = false;
		// bool EM = false;
		bool PW = false;
		// bool CPW = false;
		mensaje.text = "";
		if (Username != "")
		{
			UN = true;
		}
		else
		{
			Debug.LogWarning("Username field Empty");
			mensaje.text += "Escribir nombre de usuario \n";
		}
		if (Password != "")
		{
			if (Password.Length > 5)
			{
				PW = true;
			}
			else
			{
				Debug.LogWarning("Password Must Be atleast 6 Characters long");
				mensaje.text += "La contraseña debe tener mínimo 6 caracteres \n";
			}
		}
		else
		{
			Debug.LogWarning("Password Field Empty");
			mensaje.text += "Escribir contraseña \n";
		}

		if (UN == true && PW == true)
		{
			mensaje.gameObject.SetActive(true);
			//form = (Username+Environment.NewLine+Email+Environment.NewLine+Password+Environment.NewLine+Scorm);
			//System.IO.File.WriteAllText(@"C:/UnityTestFolder/"+Username+".txt", form);
			Debug.Log("Usuario: " + Username  + "Password" + Password);
			StartCoroutine(Registro());
			// StartCoroutine(Insignias());
			username.GetComponent<InputField>().text = "";
			password.GetComponent<InputField>().text = "";
			print("Registration Complete");
			mensaje.text += "Usuario Registrado \n";			
			SceneManager.LoadScene("LoginDesign");
		}
	}
	IEnumerator Registro()
	{
		WWW conexion = new WWW("http://www.sistematizamx.com.mx/max/WasteShop/registroUsuarios.php?user=" + Username + "&pass=" + Password);
		//localhost/WasteShop/registroUsuarios.php?user=JD&password=123&score=999
		yield return (conexion);
		Debug.Log(conexion.text);
	}

	IEnumerator Insignias()
	{
		WWW conexion = new WWW("http://www.sistematizamx.com.mx/max/registroUsuarios.php?user=" + Username);
		//localhost/synaptix/registroUsuarios.php?uss=xxx&mail=prueba@xxx.com&pss=ulsa
		yield return (conexion);
		Debug.Log(conexion.text);
	}

	void Update()
	{

		if (Input.GetKeyDown(KeyCode.Tab))
		{
			if (username.GetComponent<InputField>().isFocused)
			{
				mensaje.gameObject.SetActive(false);
				username.GetComponent<InputField>().Select();
			}
			if (password.GetComponent<InputField>().isFocused)
			{
				mensaje.gameObject.SetActive(false);
				password.GetComponent<InputField>().Select();
			}
		}
		if (Input.GetKeyDown(KeyCode.Return))
		{
			if (Username != "" && Password != "" )
			{
				RegisterButton();
			}
		}
		Username = username.GetComponent<InputField>().text;
		Password = password.GetComponent<InputField>().text;
		Scorm = 0;

	}



	public void CargarNivel(string NombreNivel)
	{
		SceneManager.LoadScene(NombreNivel);
	}
}
