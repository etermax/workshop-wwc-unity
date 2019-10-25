using System.Collections;
using UnityEngine;

namespace Utils
{
    public static class ExtensionesParaCorutinas
    {
        public static void EmpezarCorutina(this MonoBehaviour componente, IEnumerator corutina)
        {
            componente.StopAllCoroutines();
            componente.StartCoroutine(corutina);
        }

        public static WaitForSeconds Esperar(this MonoBehaviour componente, float segundos)
        {
            return new WaitForSeconds(segundos);
        }
    }
}