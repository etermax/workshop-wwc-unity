using UnityEngine;
using Utils;

public class IniciadorDeJuego : MonoBehaviour
{
    // Este método se llama desde Unity
    public void AlPresionarElBoton()
    {
        this.CargarEscena("Juego");
    }
}