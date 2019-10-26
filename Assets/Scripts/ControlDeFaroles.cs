using UnityEngine;

public class ControlDeFaroles : MonoBehaviour
{
    public Animation AnimacionDeBlink;

    private void OnTriggerEnter(Collider other)
    {
        AnimacionDeBlink.Play();
    }
}
