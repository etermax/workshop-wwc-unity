using System.Collections.Generic;
using UnityEngine;
using Utils;

public class CreadorDeVehiculos : MonoBehaviour
{
    public float IntervaloDeAparicionSegundos = 2;
    public int VelocidadDeVehiculo = 3;
    public List<MovimientoDelTransito> Vehiculos;
    private float _tiempoFaltante;

    private void Start()
    {
        _tiempoFaltante = 0;
    }
    
    private void CrearVehiculo()
    {
        MovimientoDelTransito movimientoDeVehiculo = this.InstanciarVehiculo(ObtenerVehiculoAlAzar(), transform);
        movimientoDeVehiculo.Inicializar(VelocidadDeVehiculo);
    }

    private MovimientoDelTransito ObtenerVehiculoAlAzar()
    {
        return Vehiculos[Random.Range(0, Vehiculos.Count)];
    }

    private void Update()
    {
        EvaluarCreacionDeVehiculo();
    }

    private void EvaluarCreacionDeVehiculo()
    {
        ActualizarTiempoCreacionDeVehiculo();
        if (DebeCrearVehiculo())
        {
            CrearVehiculo();
            ReiniciarTiempoParaCreacion();
        }
    }

    private void ActualizarTiempoCreacionDeVehiculo()
    {
        _tiempoFaltante -= Time.deltaTime;
    }

    private void ReiniciarTiempoParaCreacion()
    {
        _tiempoFaltante = IntervaloDeAparicionSegundos;
    }

    private bool DebeCrearVehiculo()
    {
        return _tiempoFaltante <= 0;
    }
}
