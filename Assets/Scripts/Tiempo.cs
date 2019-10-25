using UnityEngine;

public class Tiempo
{
    private readonly float _tiempoNecesario;
    private float _transcurrido;

    public Tiempo(float tiempoNecesario)
    {
        _tiempoNecesario = tiempoNecesario;
    }

    public void Incrementar()
    {
        _transcurrido += Time.deltaTime;
    }

    public bool HaTranscurrido()
    {
        return _transcurrido >= _tiempoNecesario;
    }

    public float Transcurrido()
    {
        return _transcurrido / _tiempoNecesario;
    }
}