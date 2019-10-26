using UnityEngine;

public class ControlDeArboles : MonoBehaviour
{
    public Animation AnimacionTemblar;

    private void OnTriggerEnter(Collider other)
    {
        AnimacionTemblar.Play();
    }
}
