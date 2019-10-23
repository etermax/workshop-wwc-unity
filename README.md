# Workshop: Armá tu primer videojuego

Workshop de introducción a la programación de juegos con Unity

# CONSIGNAS

## EASY 
*(No se necesita programar, se pueden resolver desde el editor)*

1. Hacer que el personaje no pueda salirse de los límites del escenario.

2. Personaliza el escenario! (Podes poner más obstáculos, más o menos calles y veredas, cambiar la velocidad de los autos, etc).

## MEDIUM
*(Se resuelven con unas pocas líneas de código)*

3. Hacer que los autos sean de distintos colores y/o modelos de forma random.

4. Al apretar la tecla Space se puede cambiar de cámara ortogonal y perspectiva.

## HARD
*(A programar!!!)*

5. El personaje puede recolectar frutitas que están tiradas por el escenario. Al recolectarlas suma puntos que se ven reflejados en el texto de la parte superior de la pantalla.


## Ayuditas:

1. Poner paredes (Cubos) invisibles (o sea, con el componente `Mesh Renderer` apagado), que tengan el componente `Box Collider` y el Tag `Obstaculo`. 

2. En la carpeta `Assets/DecoracionesDeEscenario` hay varios objetos para usar. Arrastrarlos a la escena y acomodarlos como gustes.
Tambien podes cambiar el setup del escenario agregando o sacando calles, pasto o agua.
Para modificar la dificultad, los GameObjects llamados `CreadorDeVehiculos` tienen configurables los parámetros de `Velocidad de vehiculo` e `Intervalo de Aparicion`. 

3. 
- Para cambiar de modelos: 
En la carpeta `Assets/Transito` vas a encontrar prefabs de diferentes tipos de autos. Los GameObjects llamados `CreadorDeVehiculos` tienen una lista de posibles prefabs a instanciar. Agregarlos ahí.
 
- Para que los vehículos tengan color random: 
Crear un script que herede de `MonoBehaviour` y agregarlo como componente a los prefabs `Auto` y `Camioneta`.
En el método `Start` de ese script llamar a la función:

  `this.CambiarColor(MeshRenderer, Color);`

  Donde:

  - `MeshRenderer` puede ser una propiedad pública del componente, a la que vamos a arrastrar el componente `MeshRenderer` del objeto en cuestión.

  - `Color` va a ser un color generado de forma random utilizando `Random.ColorHSV()`

4. Agregar dos variables publicas de tipo `Camera` a la clase `ControladorDelJuego`, y desde el editor arrastrar las camaras para asignarles valor. En el método `Update` de esta misma clase, chequear si se presionó la tecla `BarraSpaceadora` utilizando la función `this.SePresionoLaTecla(CodigoDeTecla)`. Cuando esto suceda, prender una cámara y apagar la otra (de forma intercambiada) utilizando
`gameObject.SetActive(bool);`

5. En la carpeta `Assets/Frutas` hay varios los prefabs de frutitas, arrastrarlos en la escena y acomodarlos.
Crear un script que herede de `MonoBehaviour` y agregarlo como componente a todos los prefabs de frutas.
Agregar en este script el método `OnTriggerEnter(Collider other)`. Y en el mismo chequear si other contiene la etiqueta `Player` (utilizando la función `ContieneLaEtiqueta`). En caso positivo, ocultar la frutita llamando a `this.Ocultar()` y sumar puntos.

    Para sumar puntos, debemos hacerlo en algún lugar global del juego. Para eso podemos utilizar la clase `ControladorDelJuego` que el GameObject `Game` tiene como componente.
Desde el script en el que estamos podemos acceder al `ControladorDelJuego` de la siguiente forma:

    `ControladorDelJuego _controladorDelJuego = this.EncontrarObjetoDelTipo<ControladorDelJuego>();`

    Ahora podemos incluir una función en la clase `ControladorDelJuego` llamada `SumarPuntos(int)` que sume puntos y actualice el texto con el nuevo valor utilizando

    `_textoPuntos.text = _puntos.ToString("#0000");`


------------------

# REFERENCIAS

## Métodos de Monobehaviour

### Update()
  Método que se llama en todos los frames

### Start()
  Método que se llama cuando el objeto se crea en la escena

### OnColissionEnter(Collision)
  Método que se llama cuando el objeto empieza a colisionar con otro objeto que lo bloquea

### OnTriggerEnter(Collider)
  Método que se llama cuando el objeto empieza a colisionar con otro objeto que no lo bloquea

### OnColissionExit(Collision)
  Método que se llama cuando el objeto deja de colisionar con otro objeto que lo bloquea

### OnTriggerExit(Collider)
  Método que se llama cuando el objeto deja de colisionar con otro objeto que no lo bloquea

### EmpezarARecibirTeclas()
  A partir de la llamada a este método el objeto empieza a escuchar eventos del teclado

### DejarDeRecibirTeclas()
  A partir de la llamada a este método el objeto deja de escuchar eventos del teclado

### EmpezarCorutina(IEnumerator corutina)
  Para llamar a un método que se va a ejecutar de forma asincrónica

### Esperar(float segundos)
  Espera una cantidad de segundos antes de seguir ejecutando (solo se utiliza dentro de corutinas para no bloquear el thread principal)

### CambiarPosicion(Vector3 posicion)
  Mueve a objeto a la posición recibida por parámetro

### Rotar(Vector3 direccion)
  Rota al objeto para que "mire" hacia la dirección recibida por parámetro. La dirección puede ser left (izquierda), right (derecha), forward (hacia adelante) o back (hacia atrás)

### bool SePresionoLaTecla(KeyCode codigoDeTecla)
  Devuelve true si la tecla si la tecla se presiono en el frame actual y false en caso contrario. codigoDeTecla puede ser: FlechaDerecha, FlechaIzquierda, FlechaArriba, FlechaAbajo o BarraEspaceadora

### Vector3 InterpolacionLineal(Vector3 posicionInicial, Vector3 posicionDestino, float tiempo)
  Devuelve el Vector resultante de la interpolación de dos vectores

### Vector3 ObtenerPosicionActual()
  Devuelve un Vector3 que indica la posición actual del objeto

### CargarEscena(string nombreEscena)
  Carga la nueva escena eliminando la anterior

### CargarEscenaSobreLaActual(string nombreEscena)
  Carga la nueva escena sobre la actual, sin eliminarla

### Animator EncontrarAnimador()
  Encuentra el componente de tipo Animator en el objeto

### Ocultar()
  Oculta y deshabilita al objeto

### T EncontrarObjetoDelTipo\<T\>()
  Busca en la escena un GameObject que tenga un componente de tipo T

### CambiarColor(MeshRenderer maya3D, Color color)
  Le cambia el tint color a la maya3D recibida por parametro.


## Métodos de Collider

### bool ContieneLaEtiqueta(string etiqueta)
  Devuelve true si el Tag del collider es “etiqueta”

