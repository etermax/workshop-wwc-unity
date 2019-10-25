using UnityEngine;
using UnityEngine.UI;
using Utils;
using static Utils.Constantes;

public class ControladorDelJuego : MonoBehaviour
{
    public SeleccionDePersonaje SeleccionDePersonaje;
    public Text TextoPuntos;
    public Camera Perspectiva;
    public Camera Ortografica;

    private int _puntos;
    private bool _estaEnCamaraPerspectiva;
    
    private void Start()
    {
        _puntos = 0;
        TextoPuntos.text = "0000";

        var personaje = Instantiate(SeleccionDePersonaje.personaje, transform);
        FindObjectOfType<SeguidorDePersonaje>().AsignarPersonajeYSeguir(personaje);

        this.DesactivarCamara(Perspectiva);
        _estaEnCamaraPerspectiva = false;
    }
    
    private void Update()
    {
        if (this.SePresionoLaTecla(BarraSpaceadora))
        {
            if (_estaEnCamaraPerspectiva)
            {
                _estaEnCamaraPerspectiva = false;
                this.DesactivarCamara(Perspectiva);
                this.ActivarCamara(Ortografica);
            }
            else
            {
                _estaEnCamaraPerspectiva = true;
                this.DesactivarCamara(Ortografica);
                this.ActivarCamara(Perspectiva);
            }
        }
    }
    
    public void SumarPuntos(int puntos)
    {
        _puntos += puntos;
        TextoPuntos.text = _puntos.ToString("#0000");
    }
}
