using UnityEngine;
using Utils;

public class SeguidorDePersonaje : MonoBehaviour
{
    private GameObject _personaje;
    private bool _siguiendoAlPersonaje;
    
    public void AsignarPersonajeYSeguir(GameObject personaje)
    {
        _personaje = personaje;
        _siguiendoAlPersonaje = true;
    }

    private void Update()
    {
        if (_siguiendoAlPersonaje)
        {
            var posicionDePersonaje = this.ObtenerPosicionLocalActualDe(_personaje);
            var nuevaPosicionCamara = new Vector3(posicionDePersonaje.x, 
                posicionDePersonaje.y + 5, 
                posicionDePersonaje.z - 4);
            this.CambiarPosicion(nuevaPosicionCamara);
        }
    }
}