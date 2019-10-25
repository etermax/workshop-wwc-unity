using UnityEngine;

namespace Utils
{
    public static class UnityExtensions
    {
        public static void EmpezarARecibirTeclas(this MonoBehaviour componente)
        {
            componente.enabled = true;
        }

        public static void DejarDeRecibirTeclas(this MonoBehaviour componente)
        {
            componente.enabled = false;
        }


        public static void CambiarPosicion(this MonoBehaviour componente, Vector3 posicion)
        {
            componente.gameObject.transform.position = posicion;
        }

        public static void Rotar(this MonoBehaviour componente, Vector3 direccion)
        {
            componente.gameObject.transform.rotation = Quaternion.LookRotation(direccion);
        }

        public static bool SePresionoLaTecla(this MonoBehaviour componente, KeyCode codigoDeTecla)
        {
            return Input.GetKeyDown(codigoDeTecla);
        }

        public static Vector3 InterpolacionLineal(this MonoBehaviour componente, Vector3 posicionInicial,
            Vector3 posicionDestino, float tiempo)
        {
            return Vector3.Lerp(posicionInicial, posicionDestino, tiempo);
        }

        public static Vector3 ObtenerPosicionActual(this MonoBehaviour componente)
        {
            return componente.gameObject.transform.position;
        }

        public static Vector3 ObtenerPosicionLocalActualDe(this MonoBehaviour componente, GameObject gameObject)
        {
            return gameObject.transform.localPosition;
        }

        public static Animador EncontrarAnimador(this MonoBehaviour componente)
        {
            return new Animador(componente.GetComponent<Animator>());
        }

        public static void Ocultar(this MonoBehaviour componente)
        {
            componente.gameObject.SetActive(false);
        }
        
        public static T EncontrarObjetoDelTipo<T>(this MonoBehaviour componente) where T : Object
        {
            return GameObject.FindObjectOfType<T>();
        }

        public static void CambiarColor(this MonoBehaviour componente, MeshRenderer maya3D, Color color)
        {
            maya3D.material.color = color;
        }

        public static MovimientoDelTransito InstanciarVehiculo(this MonoBehaviour componente, MovimientoDelTransito vehiculo,
            Transform padre)
        {
            return GameObject.Instantiate(vehiculo, padre);
        }
        
        public static void ActivarCamara(this MonoBehaviour componente, Camera camara)
        {
            camara.enabled = true;
        }
        
        public static void DesactivarCamara(this MonoBehaviour componente, Camera camara)
        {
            camara.enabled = false;
        }
        
        public static void Destruir(this MonoBehaviour componente)
        {
            Object.Destroy(componente.gameObject);
        }
    }
}