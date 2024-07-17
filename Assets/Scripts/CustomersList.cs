using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.SceneManagement;

public class CustomersList : MonoBehaviour
{
    public string OrdenNombre;
    public ParticleSystem Conffeti;
    public Transform textMeshBounds; // Padre para los TextMeshPro
    public TextMeshPro ListOrder; // TextMesh para el texto del ítem
    private GameObject spriteObject;
    private GameObject textMeshProObject;
    public GameObject textMeshProPrefab; 
    private SpriteRenderer spriteRenderer;
    public GameObject ButtonStart; 
    public GameObject ButtonCustomersNext; 
    public GameObject noMasOrdenes;
    public GameObject OrdenIncorrecta;
    private int filaClientes;
    private int ultimoCliente;
    private PuntajeScore scriptDinero;
    private Timer timer;
    private float currentZ = 0f;
    public List<Cliente> clientesLista = new List<Cliente>();
    private Cliente actualCliente;
    void Start()
    {
        ListOrder.text = "";
        filaClientes = 0;
        ultimoCliente = filaClientes - 1;
        ButtonCustomersNext.SetActive(false);
        OrdenIncorrecta.SetActive(false);
        noMasOrdenes.SetActive(false);
        timer = FindObjectOfType<Timer>();
        
    }
    void Update(){
        // Debug.Log("Ultimo cliente " + ultimoCliente);
        // Debug.Log("Fila clientes " + filaClientes);
        // Debug.Log("Total Clientes " + clientesLista.Count);
    }
    private void OnCollisionEnter(Collision collision)
    {
        foreach (Cliente cliente in clientesLista)
        {
            foreach (Objeto objeto in cliente.objetosCliente)
            {
                if (objeto != null && objeto.objeto != null && collision.gameObject != null && collision.gameObject == objeto.objeto)
                {
                    // Debug.Log("El " + objeto.nombreObjeto + " ha tocado la caja");

                    // Asegúrate de inicializar objeto.spriteRenderer si aún no está inicializado
                    if (objeto.spriteRenderer == null)
                    {
                        objeto.spriteRenderer = objeto.objeto.GetComponent<SpriteRenderer>();
                        if (objeto.spriteRenderer == null)
                        {
                            // Debug.Log("El objeto " + objeto.nombreObjeto + " no tiene un componente SpriteRenderer adjunto.");
                            return;
                        }
                    }

                    objeto.spriteRenderer.enabled = true;
                }
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        foreach (Cliente cliente in clientesLista)
        {
            foreach (Objeto objeto in cliente.objetosCliente)
            {
                if (collision.gameObject == objeto.objeto)
                {
                    // Debug.Log("El " + objeto.nombreObjeto + " ha dejado de tocar la caja");

                    // Asegúrate de inicializar objeto.spriteRenderer si aún no está inicializado
                    if (objeto.spriteRenderer == null)
                    {
                        objeto.spriteRenderer = objeto.objeto.GetComponent<SpriteRenderer>();
                        if (objeto.spriteRenderer == null)
                        {
                            // Debug.Log("El objeto " + objeto.nombreObjeto + " no tiene un componente SpriteRenderer adjunto.");
                            return;
                        }
                    }

                    objeto.spriteRenderer.enabled = false;
                }
            }
        }
    }

    public void ordenTerminada()
    {
        timer.StartTimer();
        bool todosActivados = true;
        if (filaClientes < clientesLista.Count - 1)
        {
            actualCliente = clientesLista[filaClientes];
            foreach (Objeto objeto in actualCliente.objetosCliente)
            {
                if (!objeto.spriteRenderer.enabled)
                {
                    todosActivados = false;
                    break; 
                }
            }
            if (todosActivados)
            {          
                Debug.Log(timer.timeValueFinal);
                timer.StopTimer();    
                actualCliente.anim.SetBool("Victory", true);
                foreach (Objeto objeto in actualCliente.objetosCliente)
                {
                    scriptDinero.ActualizarPuntaje(objeto.precio * Mathf.FloorToInt(timer.timeValueFinal)); 
                    if (objeto.spriteRenderer.gameObject != null)
                    {
                        objeto.spriteRenderer.enabled = false;
                        Destroy(objeto.textMeshPro);
                    }
                }
                actualCliente.animCar.SetBool("CarOut", true);
                OrdenIncorrecta.SetActive(false);
                ListOrder.text = "";
                ultimoCliente += 1;
                currentZ = 0f;
                filaClientes += 1;  
                ClienteEntra();
            }
            else if(!todosActivados && clientesLista.Count > 0)
            {
                // actualCliente.anim.SetBool("Angry", true);
                OrdenIncorrecta.SetActive(true);
            }
        }
        // If there are no more clients, do this
        else
        {
            actualCliente = clientesLista[filaClientes];
            foreach (Objeto objeto in actualCliente.objetosCliente)
            {
                if (!objeto.spriteRenderer.enabled)
                {
                    todosActivados = false;
                    break; 
                }
            }
            if (todosActivados)
            {        
                timer.StopTimer();
                actualCliente.anim.SetBool("Victory", true);
                foreach (Objeto objeto in actualCliente.objetosCliente)
                {
                    scriptDinero.ActualizarPuntaje(objeto.precio * Mathf.FloorToInt(timer.timeValueFinal)); 
                    if (objeto.spriteRenderer.gameObject != null)
                    {
                        objeto.spriteRenderer.enabled = false;
                        Destroy(objeto.textMeshPro);
                    }
                }
                // actualCliente.anim.SetBool("Out", true);
                actualCliente.animCar.SetBool("CarOut", true);
                OrdenIncorrecta.SetActive(false);
                ListOrder.text = "";
                ultimoCliente += 1;
                currentZ = 0f;
                noMasOrdenes.SetActive(true);
                Conffeti.Play();
                ConsultaScore consultaScore = new ConsultaScore();
                StartCoroutine(consultaScore.UpdateScore());
                Invoke("ChangeSceneEvent", 10f);
            }
        }

    }
    public void ClienteEntra()
    {
        if (clientesLista.Count > 0)
        {
            ButtonStart.SetActive(false);
            ButtonCustomersNext.SetActive(true);
            actualCliente = clientesLista[filaClientes];
            actualCliente.animCar.SetBool("CarIn", true);
            actualCliente.anim.SetBool("IDLE", true);
            foreach (Objeto objeto in actualCliente.objetosCliente)
            {
                scriptDinero = FindObjectOfType<PuntajeScore>();
                //Cada vez que cree un item se baje
                currentZ += -0.1f;
                // Crear un textMeshPro(Objeto Referenciado)
                textMeshProObject = Instantiate(textMeshProPrefab, textMeshBounds);
                // Hacer display del objeto
                // TextMeshPro textMeshPro = textMeshProObject.GetComponent<TextMeshPro>();
                objeto.textMeshPro = textMeshProObject.GetComponent<TextMeshPro>();
                // Pides el nombre del objeto de la clase y lo guardas
                objeto.textMeshPro.text = objeto.nombreObjeto;
                // darle posición del TextMeshPro usando el currentZ que le dimos
                textMeshProObject.transform.localPosition = new Vector3(0f, 0.6f, currentZ);              
                // Crear el objeto del sprite
                spriteObject = new GameObject("SpriteObject");
                // Añadir el componente SpriteRenderer
                SpriteRenderer spriteRenderer = spriteObject.AddComponent<SpriteRenderer>();
                // Obtener el tamaño del texto
                Vector2 textSize = objeto.textMeshPro.GetRenderedValues(false);
                // Obtener el tamaño del sprite
                spriteRenderer.sprite = objeto.sprite;
                // Guardar referencia al SpriteRenderer en el objetoPedido
                objeto.spriteRenderer = spriteRenderer;
                // Calcular la posición del sprite al lado del textMeshPro
                Vector3 spritePosition = new Vector3(objeto.textMeshPro.transform.position.x,
                                                    objeto.textMeshPro.transform.position.y + 0.009f,
                                                    objeto.textMeshPro.transform.position.z + 0.15f);
                Vector3 spriteRotation = new Vector3(objeto.textMeshPro.transform.rotation.x,
                                                    objeto.textMeshPro.transform.rotation.y,
                                                    objeto.textMeshPro.transform.rotation.z);
                // Asignar la posición al sprite
                spriteObject.transform.position = spritePosition;
                spriteObject.transform.localScale = new Vector3(0.0025f, 0.0025f, 1f);
                spriteObject.transform.rotation = objeto.textMeshPro.transform.rotation;
                spriteRenderer.enabled = false;
                
                }
        }
        else
        {
            // Debug.LogWarning("No hay clientesss.");
        }
        timer.StartTimer();
    }
	private void ChangeSceneEvent(){
		SceneManager.LoadScene("Menu");
    }
}

[System.Serializable] 
public class Cliente 
{
    public string nombre;
    public GameObject Customer;
    public Animator anim;
    public GameObject Car;
    public Animator animCar;
    public List<Objeto> objetosCliente = new List<Objeto>();
}

[System.Serializable]
public class Objeto
{
    public string nombreObjeto;
    public GameObject objeto;
    public int precio;
    public Sprite sprite; 
    public SpriteRenderer spriteRenderer; 
    public TextMeshPro textMeshPro;
}