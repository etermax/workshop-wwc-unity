using UnityEngine;
using Utils;

public class SelectorDeColorModelo : MonoBehaviour
{
    public MeshRenderer Maya3D;

    private void Start()
    {
        this.CambiarColor(Maya3D, Random.ColorHSV());
    }
}
