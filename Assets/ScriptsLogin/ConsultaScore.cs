using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro; 
using UnityEngine.SceneManagement;
using UnityEngine.Networking; 

public class ConsultaScore : MonoBehaviour {
	string Username = LoginPHP.Username;
	int Puntaje = PuntajeScore.Puntaje;
	public TextMeshPro usuario;
	public TextMeshPro usuarios;
	public TextMeshPro score;
	private TextMeshPro scoreUpdated;
	private bool ScoreValid = true;

	void Start () {
        if (Username == null)
        {
            Username = "No User Found";
        }
	}
	
	void Update () {
		if (ScoreValid == true) {
			VerScore();
			ScoreValid = false;
		}
	}
	public void VerScore() {
		StartCoroutine(ComprobarScore());
		StartCoroutine(ComprobarUsersScores());
	}
    public IEnumerator ComprobarScore()
    {
        usuario.text = Username;
        UnityWebRequest conexion = UnityWebRequest.Get("http://www.sistematizamx.com.mx/max/WasteShop/consultaScore.php?user=" + Username);

        yield return conexion.SendWebRequest();

        if (conexion.result == UnityWebRequest.Result.Success)
        {
            score.text = conexion.downloadHandler.text;
			ScoreValid = true;
        }
        else
        {
            Debug.LogError("Error al obtener el puntaje: " + conexion.error);
        }
    }
    public IEnumerator ComprobarUsersScores()
    {
        UnityWebRequest conexion = UnityWebRequest.Get("http://www.sistematizamx.com.mx/max/WasteShop/consultaScoreName.php?user=" + Username);

        yield return conexion.SendWebRequest();

        if (conexion.result == UnityWebRequest.Result.Success)
        {
            usuarios.text = conexion.downloadHandler.text;
			ScoreValid = true;
        }
        else
        {
            Debug.LogError("Error al obtener los nombres: " + conexion.error);
        }
    }
    
    public IEnumerator UpdateScore()
    {
        // Actualiza el puntaje del usuario
        UnityWebRequest conexion = UnityWebRequest.Get("https://www.sistematizamx.com.mx/max/WasteShop/updateScore.php?user=" + Username + "&score=" + Puntaje);
        yield return conexion.SendWebRequest();

        if (conexion.result == UnityWebRequest.Result.Success)
        {
            scoreUpdated.text = conexion.downloadHandler.text;
            ScoreValid = true;
            // Debug.LogWarning("Puntaje actualizado" + scoreUpdated.text);
            // yield return conexion.SendWebRequest();
        }
        else
        {
            Debug.LogError("Error al actualizar puntaje " + conexion.error);
        }
    }
}
