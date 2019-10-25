using UnityEngine;
using UnityEngine.UI;

public class ControladorDelJuego : MonoBehaviour
{
    public SeleccionDePersonaje SeleccionDePersonaje;
    public Text TextoPuntos;

    private int _puntos;
    
    private void Start()
    {
        _puntos = 0;
        TextoPuntos.text = "0000";

        var personaje = Instantiate(SeleccionDePersonaje.personaje, transform);
        FindObjectOfType<SeguidorDePersonaje>().AsignarPersonajeYSeguir(personaje);
    }
}
