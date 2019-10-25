using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils
{
    public static class SceneExtensions
    {
        public static void CargarEscenaSobreLaActual(this MonoBehaviour componente, string nombreEscena)
        {
            SceneManager.LoadScene(nombreEscena, LoadSceneMode.Additive);
        }

        public static void CargarEscena(this MonoBehaviour componente, string nombreEscena)
        {
            SceneManager.LoadScene(nombreEscena, LoadSceneMode.Single);
        }
    }
}