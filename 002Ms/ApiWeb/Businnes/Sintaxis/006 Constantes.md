# Constantes en C#

En C#, las **constantes** son valores que no pueden cambiar durante la ejecución del programa. Estas se definen utilizando la palabra clave `const` y su valor debe ser asignado en el momento de la declaración. Además, existen alternativas como `readonly` y literales constantes. A continuación, se explican los diferentes tipos de constantes y su uso.

---

## 1. **Constantes con `const`**

Las constantes declaradas con `const`:
- Son **inmutables** y su valor es determinado en **tiempo de compilación**.
- Deben ser de tipos **primitivos** o compatibles con constantes (e.g., `int`, `double`, `string`).
- Se asocian a una clase o estructura, no a una instancia específica.

### Sintaxis:
```csharp
const tipo nombreConstante = valor;
```

### Ejemplo:
```csharp
const double Pi = 3.14159;
const string ApplicationName = "Mi Aplicación";
```

### Características:
- No se puede modificar su valor después de la declaración.
- Debe inicializarse en el momento de la declaración.

---

## 2. **Campos de Solo Lectura (`readonly`)**

Los campos marcados como `readonly` son similares a las constantes, pero tienen diferencias importantes:
- Su valor se puede establecer **en tiempo de ejecución**, ya sea al declararse o dentro del constructor de la clase.
- Son inmutables después de haber sido inicializados.

### Sintaxis:
```csharp
readonly tipo nombreCampo;
```

### Ejemplo:
```csharp
public class Configuracion
{
    public readonly string ConexionBD;
    public readonly int MaxUsuarios;

    public Configuracion()
    {
        ConexionBD = "Server=localhost;Database=App;";
        MaxUsuarios = 100;
    }
}
```

### Diferencias entre `const` y `readonly`:
| Característica         | `const`                      | `readonly`                  |
|------------------------|------------------------------|-----------------------------|
| Tiempo de inicialización | Tiempo de compilación       | Tiempo de ejecución         |
| Cambiable después de asignación | No                   | No                          |
| Usable en constructores  | No                         | Sí                          |

---

## 3. **Límites y Alcance**

Las constantes tienen un **alcance estático**:
- Si se declaran en una clase o estructura, son **estáticas implícitamente**.
- No se pueden declarar como `static`, ya que esto es redundante.

### Ejemplo:
```csharp
public class Configuracion
{
    public const string NombreAplicacion = "MiApp"; // Accesible como Configuracion.NombreAplicacion
}
```

---

## 4. **Literales Constantes**

Un **literal constante** es un valor fijo que se utiliza directamente en el código sin necesidad de declarar una constante explícita.

### Ejemplo:
```csharp
Console.WriteLine(3.14); // Literal constante
Console.WriteLine("Hola Mundo"); // Literal constante
```

Aunque los literales constantes son útiles, el uso de constantes declaradas (`const`) mejora la legibilidad y facilita el mantenimiento del código.

---

## 5. **Constantes Enumeradas**

En C#, las constantes relacionadas pueden agruparse usando `enum`. Esto permite definir un conjunto de valores constantes asociados con nombres simbólicos.

### Ejemplo:
```csharp
public enum DiasSemana
{
    Lunes = 1,
    Martes,
    Miercoles,
    Jueves,
    Viernes,
    Sabado,
    Domingo
}
```

Uso:
```csharp
DiasSemana dia = DiasSemana.Lunes;
Console.WriteLine((int)dia); // Imprime: 1
```

---

## Resumen de Uso de Constantes

| Tipo                  | Tiempo de Inicialización     | Modificable después de la declaración | Contexto de Uso              |
|-----------------------|------------------------------|---------------------------------------|------------------------------|
| `const`               | Tiempo de compilación        | No                                   | Valores constantes e inmutables. |
| `readonly`            | Tiempo de ejecución (constructores) | No                                   | Valores calculados o configurados dinámicamente. |
| Literales constantes  | N/A                          | N/A                                  | Uso directo en el código (e.g., números, cadenas). |
| `enum`                | Tiempo de compilación        | No                                   | Agrupar valores simbólicos relacionados. |

---

Al usar constantes, es importante elegir el enfoque adecuado (`const`, `readonly` o `enum`) dependiendo de si el valor es fijo en tiempo de compilación, dinámico o parte de un conjunto simbólico. Esto asegura código más limpio, legible y fácil de mantener.