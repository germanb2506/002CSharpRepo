# Excepciones en C#

Las excepciones son errores que ocurren durante la ejecución de un programa y pueden interrumpir su flujo normal. En C#, las excepciones se manejan mediante bloques `try`, `catch`, `finally` y pueden ser personalizadas para necesidades específicas.

---

## 1. **Estructura básica del manejo de excepciones**

### Sintaxis
```csharp
try
{
    // Código que podría lanzar una excepción
}
catch (TipoDeExcepcion ex)
{
    // Código para manejar la excepción
}
finally
{
    // Código que siempre se ejecuta (opcional)
}
```

---

## 2. **Bloques try-catch**

El bloque `try` contiene el código que puede lanzar excepciones. Si ocurre una excepción, el bloque `catch` captura la excepción y la maneja.

### Ejemplo
```csharp
try
{
    int divisor = 0;
    int resultado = 10 / divisor; // Esto genera una excepción
}
catch (DivideByZeroException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
```

---

## 3. **Bloque finally**

El bloque `finally` se ejecuta siempre, independientemente de si ocurrió una excepción o no. Es útil para liberar recursos.

### Ejemplo
```csharp
FileStream archivo = null;

try
{
    archivo = new FileStream("archivo.txt", FileMode.Open);
    // Operaciones con el archivo
}
catch (FileNotFoundException ex)
{
    Console.WriteLine($"Archivo no encontrado: {ex.Message}");
}
finally
{
    archivo?.Close(); // Liberar recursos
}
```

---

## 4. **Propagación de excepciones**

Si una excepción no se maneja en un método, se propaga hacia el método que lo llamó.

### Ejemplo
```csharp
static void MetodoPrincipal()
{
    try
    {
        MetodoQueLanzaExcepcion();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Excepción capturada: {ex.Message}");
    }
}

static void MetodoQueLanzaExcepcion()
{
    throw new InvalidOperationException("Operación inválida.");
}
```

---

## 5. **Excepciones personalizadas**

Puedes crear tus propias excepciones heredando de la clase base `Exception`.

### Ejemplo
```csharp
public class MiExcepcionPersonalizada : Exception
{
    public MiExcepcionPersonalizada(string mensaje) : base(mensaje) { }
}

static void Main()
{
    try
    {
        throw new MiExcepcionPersonalizada("Este es un error personalizado.");
    }
    catch (MiExcepcionPersonalizada ex)
    {
        Console.WriteLine($"Excepción personalizada: {ex.Message}");
    }
}
```

---

## 6. **Jerarquía de excepciones**

C# tiene una jerarquía de excepciones. Algunas comunes son:

| Excepción               | Descripción                                                                 |
|-------------------------|-----------------------------------------------------------------------------|
| `Exception`             | Clase base para todas las excepciones.                                     |
| `SystemException`       | Clase base para excepciones lanzadas por el sistema.                       |
| `InvalidOperationException` | Se lanza cuando una operación no es válida en el estado actual.         |
| `NullReferenceException`| Se lanza cuando se intenta usar un objeto nulo.                           |
| `DivideByZeroException` | Se lanza al dividir entre cero.                                            |
| `FileNotFoundException` | Se lanza cuando no se encuentra un archivo.                               |
| `ArgumentException`     | Se lanza cuando un argumento proporcionado es inválido.                   |
| `IndexOutOfRangeException` | Se lanza al intentar acceder a un índice fuera de los límites de un array. |

---

## 7. **Lanzar excepciones**

Puedes lanzar excepciones explícitamente usando la palabra clave `throw`.

### Ejemplo
```csharp
static void ValidarEdad(int edad)
{
    if (edad < 18)
    {
        throw new ArgumentException("La edad debe ser mayor o igual a 18.");
    }
}
```

---

## 8. **Manejo de excepciones múltiples**

Puedes manejar diferentes tipos de excepciones en bloques `catch` separados.

### Ejemplo
```csharp
try
{
    int[] numeros = { 1, 2, 3 };
    Console.WriteLine(numeros[5]); // Genera IndexOutOfRangeException
}
catch (IndexOutOfRangeException ex)
{
    Console.WriteLine("Error: Índice fuera de rango.");
}
catch (Exception ex)
{
    Console.WriteLine($"Error inesperado: {ex.Message}");
}
```

---

## 9. **Checked y unchecked**

C# permite manejar excepciones aritméticas como desbordamientos (`OverflowException`) usando los contextos `checked` y `unchecked`.

### Ejemplo
```csharp
checked
{
    int valor = int.MaxValue;
    valor++; // Genera una excepción OverflowException
}
```

---

## 10. **Resumen**

| Concepto              | Descripción                                                                 |
|-----------------------|-----------------------------------------------------------------------------|
| `try`                | Bloque donde se coloca el código que puede lanzar excepciones.              |
| `catch`              | Bloque que captura y maneja la excepción lanzada.                          |
| `finally`            | Bloque que siempre se ejecuta para limpiar recursos.                       |
| `throw`              | Se utiliza para lanzar una excepción de forma explícita.                   |
| Excepciones personalizadas | Permite definir errores específicos de la aplicación.                  |

Con un manejo adecuado de excepciones, puedes garantizar que tu aplicación sea más robusta y maneje errores inesperados de manera controlada.