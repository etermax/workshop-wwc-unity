using UnityEngine;
using UnityEngine.UI;
using Utils;

public class PantallaResultados : MonoBehaviour
{
    public Button BotonReiniciar;
    public Button BotonSalir;

    private void Start()
    {
        BotonReiniciar.onClick.AddListener(ReiniciarPartida);
        BotonSalir.onClick.AddListener(SalirAMenu);
    }

    private void ReiniciarPartida()
    {
        this.CargarEscena("Juego");
    }
    
    private void SalirAMenu()
    {
        this.CargarEscena("MenuDeInicio");
    }
}
