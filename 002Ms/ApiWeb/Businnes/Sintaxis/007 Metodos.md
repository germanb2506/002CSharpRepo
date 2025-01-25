
# Métodos en C#

Un **método** en C# es un bloque de código que realiza una tarea específica, recibe parámetros (si son necesarios) y devuelve un valor (o no). Los métodos permiten modularizar y reutilizar código, mejorando la organización y legibilidad de un programa.

---

## 1. **Estructura de un Método**

### Declaración Básica
```csharp
[modificadorDeAcceso] [modificadorOpcional] tipoRetorno NombreMetodo([parámetrosOpcionales])
{
    // Cuerpo del método
    return valor; // Si el tipo de retorno no es void
}
```

### Componentes:
1. **Modificador de acceso**: Define la visibilidad del método.
   - `public`: Accesible desde cualquier lugar.
   - `private`: Accesible solo dentro de la clase.
   - `protected`: Accesible en la clase y sus derivadas.
   - `internal`: Accesible dentro del ensamblado actual.
2. **Modificadores adicionales** (opcional):
   - `static`: Pertenece a la clase, no a una instancia.
   - `abstract`: Declarado en una clase abstracta, implementado por clases derivadas.
   - `virtual`: Puede sobrescribirse en una clase derivada.
   - `override`: Sobrescribe un método de la clase base.
3. **Tipo de retorno**: Tipo del valor devuelto (`int`, `string`, `void`, etc.).
4. **Nombre del método**: Debe seguir las convenciones PascalCase.
5. **Parámetros** (opcional): Lista de valores requeridos o no requeridos por el método.
6. **Cuerpo del método**: Código que se ejecutará cuando se invoque el método.

---

## 2. **Tipos de Métodos**

### a. Métodos sin parámetros y sin retorno
```csharp
public void MostrarMensaje()
{
    Console.WriteLine("Hola Mundo");
}
```

### b. Métodos con parámetros
```csharp
public void Saludar(string nombre)
{
    Console.WriteLine($"Hola, {nombre}!");
}
```

### c. Métodos con retorno
```csharp
public int Sumar(int a, int b)
{
    return a + b;
}
```

### d. Métodos con parámetros opcionales
```csharp
public void MostrarSaludo(string nombre = "Usuario")
{
    Console.WriteLine($"Hola, {nombre}!");
}
```

### e. Métodos con parámetros nombrados
```csharp
public void Configurar(int ancho, int alto)
{
    Console.WriteLine($"Ancho: {ancho}, Alto: {alto}");
}
```
Invocación:
```csharp
Configurar(alto: 1080, ancho: 1920);
```

---

## 3. **Sobrecarga de Métodos**

Un método se puede sobrecargar declarando múltiples versiones con el mismo nombre pero con diferentes firmas (número o tipo de parámetros).

```csharp
public int CalcularArea(int lado)
{
    return lado * lado; // Área de un cuadrado
}

public int CalcularArea(int baseTriangulo, int altura)
{
    return (baseTriangulo * altura) / 2; // Área de un triángulo
}
```

---

## 4. **Métodos Estáticos**

Un método estático pertenece a la clase en lugar de a una instancia de la misma.

```csharp
public static int Sumar(int a, int b)
{
    return a + b;
}
```

Uso:
```csharp
int resultado = MiClase.Sumar(5, 10);
```

---

## 5. **Métodos Asíncronos**

Los métodos asíncronos permiten la ejecución no bloqueante utilizando `async` y `await`.

```csharp
public async Task DescargarDatosAsync()
{
    Console.WriteLine("Descargando...");
    await Task.Delay(2000); // Simula una descarga
    Console.WriteLine("Descarga completada");
}
```

Uso:
```csharp
await DescargarDatosAsync();
```

---

## 6. **Parámetros Avanzados**

### a. Parámetros por referencia (`ref`)
Permiten modificar el valor original del argumento.
```csharp
public void Incrementar(ref int numero)
{
    numero++;
}
```

Uso:
```csharp
int valor = 10;
Incrementar(ref valor); // valor = 11
```

### b. Parámetros de salida (`out`)
Se usan para devolver múltiples valores desde un método.
```csharp
public void Dividir(int a, int b, out int cociente, out int resto)
{
    cociente = a / b;
    resto = a % b;
}
```

Uso:
```csharp
int c, r;
Dividir(10, 3, out c, out r); // c = 3, r = 1
```

### c. Parámetros con cantidad variable (`params`)
Permiten pasar un número variable de argumentos al método.
```csharp
public void Imprimir(params string[] mensajes)
{
    foreach (var mensaje in mensajes)
    {
        Console.WriteLine(mensaje);
    }
}
```

Uso:
```csharp
Imprimir("Hola", "Mundo", "C# es genial");
```

---

## 7. **Métodos Genéricos**

Permiten trabajar con tipos desconocidos o definidos en tiempo de ejecución.

```csharp
public T RetornarMayor<T>(T a, T b) where T : IComparable<T>
{
    return a.CompareTo(b) > 0 ? a : b;
}
```

Uso:
```csharp
int mayor = RetornarMayor(10, 20); // mayor = 20
string palabraMayor = RetornarMayor("Hola", "Mundo"); // palabraMayor = "Mundo"
```

---

## 8. **Métodos de Extensión**

Permiten agregar funcionalidad a tipos existentes sin modificar su código original.

```csharp
public static class Extensiones
{
    public static int ContarPalabras(this string texto)
    {
        return texto.Split(' ').Length;
    }
}
```

Uso:
```csharp
string frase = "Hola mundo de C#";
int cantidad = frase.ContarPalabras(); // cantidad = 4
```

---

## 9. **Resumen**

| Tipo                          | Descripción                                    |
|-------------------------------|------------------------------------------------|
| Sin parámetros y sin retorno  | Ejecutan una acción fija sin recibir ni devolver valores. |
| Con parámetros                | Reciben valores para personalizar su ejecución. |
| Con retorno                   | Devuelven un valor al final de su ejecución.    |
| Sobrecarga                    | Permite múltiples versiones de un método.       |
| Estáticos                     | Pertenece a la clase, no a una instancia.       |
| Asíncronos                    | Permite ejecución no bloqueante con `async/await`. |
| Avanzados (`ref`, `out`, `params`) | Manejan datos de forma más flexible.           |
| Genéricos                     | Operan con cualquier tipo de dato.             |
| De extensión                  | Agregan funcionalidad a tipos existentes.      |

Este conocimiento te permitirá diseñar y utilizar métodos de manera eficiente, adaptándolos a diferentes escenarios y necesidades en el desarrollo de aplicaciones C#.