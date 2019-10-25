using static Utils.Constantes;
using System.Collections;
using UnityEngine;
using Utils;

public class MovimientoDelPersonaje : MonoBehaviour
{
    [Range(0.1f, 2)] public float _duracionDesplazamientoEnSegundos = 0.3f;
    private Vector3 _posicionInicial;
    private Animador _animador;

    private void Start()
    {
        _animador = this.EncontrarAnimador();
        _posicionInicial = this.ObtenerPosicionActual();
    }

    private void Update()
    {
        DetectarMovimiento();
    }

    private void OnTriggerEnter(Collider colisionador)
    {
        if (colisionador.ContieneLaEtiqueta("Obstaculo"))
        {
            this.EmpezarCorutina(Aturdir());
        }
        else if (colisionador.ContieneLaEtiqueta("Transito"))
        {
            this.CargarEscenaSobreLaActual("Derrota");
            this.EmpezarCorutina(Aturdir());
        }
        else if (colisionador.ContieneLaEtiqueta("Victoria"))
        {
            this.CargarEscenaSobreLaActual("Victoria");
        }
    }

    private void DetectarMovimiento()
    {
        if (this.SePresionoLaTecla(FlechaDerecha))
        {
            MoverseHacia(Vector3.right);
        }

        if (this.SePresionoLaTecla(FlechaIzquierda))
        {
            MoverseHacia(Vector3.left);
        }

        if (this.SePresionoLaTecla(FlechaAbajo))
        {
            MoverseHacia(Vector3.back);
        }

        if (this.SePresionoLaTecla(FlechaArriba))
        {
            MoverseHacia(Vector3.forward);
        }
    }

    private void MoverseHacia(Vector3 direccion)
    {
        this.Rotar(direccion);
        _posicionInicial = this.ObtenerPosicionActual();
        var posicionDestino = _posicionInicial + direccion;
        this.EmpezarCorutina(Mover(_posicionInicial, posicionDestino));
        _animador.Saltar();
    }

    private IEnumerator Aturdir()
    {
        yield return Mover(this.ObtenerPosicionActual(), _posicionInicial);
        this.DejarDeRecibirTeclas();
        _animador.Aturdir();
        yield return this.Esperar(0.6f);
        this.EmpezarARecibirTeclas();
    }

    private IEnumerator Mover(Vector3 posicionInicial, Vector3 posicionDestino)
    {
        this.DejarDeRecibirTeclas();
        var tiempo = new Tiempo(_duracionDesplazamientoEnSegundos);

        while (!tiempo.HaTranscurrido())
        {
            var posicionInterpolada = this.InterpolacionLineal(posicionInicial, posicionDestino, tiempo.Transcurrido());
            this.CambiarPosicion(posicionInterpolada);
            tiempo.Incrementar();
            yield return null;
        }

        this.CambiarPosicion(posicionDestino);
        this.EmpezarARecibirTeclas();
    }
}