using UnityEngine;
using Utils;

public class Fruta : MonoBehaviour
{
    private const int PUNTOS_POR_ITEM = 1;
    
    private ControladorDelJuego _controladorDelJuego;

    private void Start()
    {
        _controladorDelJuego = this.EncontrarObjetoDelTipo<ControladorDelJuego>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.ContieneLaEtiqueta("Player"))
        {
            _controladorDelJuego.SumarPuntos(PUNTOS_POR_ITEM);
            this.Ocultar();
        }
    }
}
