using UnityEngine;

public class SelectorDePersonaje : MonoBehaviour
{
    public SeleccionDePersonaje _seleccionDePersonaje;
    public GameObject _personaje;
    
    // Este método se llama desde Unity
    public void AlElegirPersonaje()
    {
        _seleccionDePersonaje.personaje = _personaje;
    }
}