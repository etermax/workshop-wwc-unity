using UnityEngine;
using Utils;

public class MovimientoDelTransito : MonoBehaviour
{
    private Vector3 _posicionInicial;
    private int _velocidad;
    private Vector3 _direccion;
    private bool _detenido = true;

    public void Inicializar(int velocidadDeVehiculo)
    {
        _posicionInicial = this.ObtenerPosicionActual();
        _velocidad = velocidadDeVehiculo;
        _detenido = false;
    }
    
    private void OnTriggerEnter(Collider colisionador)
    {
        if (colisionador.ContieneLaEtiqueta("Limite"))
        {
            this.Destruir();
        }
        else if(colisionador.ContieneLaEtiqueta("Transito")||colisionador.ContieneLaEtiqueta("Player"))
        {
            Detener();
        }
    }

    private void Detener()
    {
        _detenido = true;
    }
    
    private void Update()
    {
        if (_detenido)
            return;
        
        Avanzar();
    }

    private void Avanzar()
    {
        transform.localPosition += Time.deltaTime * _velocidad * Vector3.forward;
    }
}
