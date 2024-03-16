using UnityEngine;

public class CambioDeArma : MonoBehaviour
{
    public GameObject armaAk47; // Referencia al objeto de la arma AK47
    public GameObject armaShot; // Referencia al objeto de la arma Shot
    public GameObject armaActual; // Referencia al arma actual

    private void OnTriggerEnter(Collider other)
    {
        // Comprueba si el objeto con el que colisionamos es un arma
        if (other.CompareTag("ak47"))
        {
            GameObject objetoConTag = GameObject.FindGameObjectWithTag("ak47");

            Destroy(objetoConTag);
            // Desactiva el arma actual
            armaActual.SetActive(false);

            // Activa la nueva arma
            armaAk47.SetActive(true);

            // Actualiza el arma actual
            armaActual = armaAk47;
        }
        else if (other.CompareTag("shot"))
        {
            GameObject objetoConTag = GameObject.FindGameObjectWithTag("shot");

            Destroy(objetoConTag);
            // Desactiva el arma actual
            armaActual.SetActive(false);

            // Activa la nueva arma
            armaShot.SetActive(true);

            // Actualiza el arma actual
            armaActual = armaShot;
        }
    }
}