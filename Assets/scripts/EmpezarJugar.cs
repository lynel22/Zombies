using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EmpezarJugar : MonoBehaviour
{
    // Start is called before the first frame update
    public void CargarEscena()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void volveraInicio()
    {
        SceneManager.LoadScene("Inicio");
    }
}
