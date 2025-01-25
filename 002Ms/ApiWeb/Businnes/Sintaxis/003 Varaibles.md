# Variables en C#

Las **variables** son espacios en memoria que almacenan valores de un tipo de dato específico. La declaración y la inicialización de variables en C# se pueden hacer de diversas maneras, ya sea **explícita** o **implícitamente**, y existen ciertas convenciones sobre cómo manejarlas. A continuación se detalla el uso de variables, su declaración e inicialización en C#.

## 1. **Declaración de Variables**

### Declaración Explícita
Una declaración explícita es cuando se especifica tanto el tipo de la variable como el nombre de la misma al momento de declararla.

**Sintaxis**:
```csharp
tipo nombreVariable;
```

**Ejemplo**:
```csharp
int age; // Se declara una variable 'age' de tipo int
string name; // Se declara una variable 'name' de tipo string
```

### Declaración Implícita
Una declaración implícita se realiza usando la palabra clave `var`. El compilador infiere el tipo de la variable a partir del valor que se le asigna durante la inicialización.

**Sintaxis**:
```csharp
var nombreVariable = valor;
```

**Ejemplo**:
```csharp
var age = 30; // El compilador infiere que 'age' es de tipo int
var name = "John"; // El compilador infiere que 'name' es de tipo string
```

**Notas**:
- `var` solo puede ser utilizado cuando el tipo es claramente inferido por el compilador.
- No es posible usar `var` sin asignar un valor al momento de la declaración.
  
### Declaración de Tipos de Valor (Ejemplos):
- **Tipos enteros**:
  ```csharp
  int a = 10; // Declaración explícita
  var b = 20; // Declaración implícita
  ```

- **Tipos decimales**:
  ```csharp
  float pi = 3.14f; // Declaración explícita
  var e = 2.718; // Declaración implícita
  ```

## 2. **Inicialización de Variables**

La **inicialización** de variables se refiere a la asignación de un valor a una variable en el momento de su declaración.

### Inicialización Explícita
En la declaración explícita, la variable se inicializa asignando un valor de forma directa al momento de la declaración.

**Ejemplo**:
```csharp
int x = 100;  // Declaración e inicialización explícita
string city = "New York"; // Declaración e inicialización explícita
```

### Inicialización Implícita
En la declaración implícita, el tipo de la variable se infiere del valor asignado. No es necesario especificar el tipo de la variable, ya que el compilador lo infiere de manera implícita.

**Ejemplo**:
```csharp
var y = 10;  // El compilador infiere que 'y' es de tipo int
var message = "Hello, World!";  // El compilador infiere que 'message' es de tipo string
```

## 3. **Ámbito y Vida de las Variables**

El **ámbito** (scope) de una variable depende de dónde se declara:
- **Variables locales**: Se declaran dentro de métodos, funciones o bloques de código y solo son accesibles dentro de ese contexto.
- **Variables de instancia**: Se declaran dentro de una clase y son accesibles en cualquier parte de esa clase.
- **Variables globales (solo dentro de un ensamblado)**: Se definen en una clase o un espacio de nombres, accesibles en todo el proyecto (aunque su uso no es común).

### Inicialización Implícita de Variables Locales
Si se declara una variable local sin inicializarla explícitamente, se le asignará un valor predeterminado basado en su tipo:
- **Tipos numéricos (enteros, decimales, etc.)**: Inicializados en `0`.
- **Tipos booleanos**: Inicializados en `false`.
- **Referencias a objetos**: Inicializadas en `null`.

**Ejemplo**:
```csharp
int count; // Inicializado por defecto a 0
bool isValid; // Inicializado por defecto a false
string name; // Inicializado por defecto a null
```

Sin embargo, se recomienda siempre inicializar las variables antes de usarlas para evitar posibles errores de ejecución.

## 4. **Tipos de Variables**

### 4.1 **Variables de Tipo de Valor**
Son tipos de datos que almacenan su valor directamente en la variable. Estos incluyen tipos primitivos como `int`, `float`, `double`, `char`, etc.

**Ejemplo**:
```csharp
int number = 10; // Tipo de valor
double price = 9.99; // Tipo de valor
```

### 4.2 **Variables de Tipo de Referencia**
Son tipos que almacenan una referencia a los datos (la dirección de memoria), no el valor directo. Estos incluyen tipos como `string`, clases, arreglos, delegados, etc.

**Ejemplo**:
```csharp
string message = "Hello"; // Tipo de referencia
var customer = new Customer(); // Tipo de referencia
```

### 4.3 **Variables Nulas**
Algunos tipos de valor (como `int`, `double`, `bool`, etc.) no pueden ser nulos por defecto. Sin embargo, es posible hacer que un tipo de valor acepte valores nulos utilizando **tipos anulables**.

**Sintaxis**:
```csharp
int? nullableInt = null; // Un tipo int que acepta valores nulos
bool? nullableBool = null; // Un tipo bool que acepta valores nulos
```

## 5. **Convenciones de Nombres**

### 5.1 **Nombres de Variables**
- Usar **camelCase** para los nombres de las variables locales y parámetros.
  - Ejemplo: `var userName = "John";`
  
### 5.2 **Nombres de Campos Privados**
- Usar **camelCase** con un guion bajo (`_`) al principio para los campos privados.
  - Ejemplo: `_totalAmount`, `_userName`.

### 5.3 **Nombres de Propiedades**
- Usar **PascalCase** para las propiedades públicas.
  - Ejemplo: `public string UserName { get; set; }`

## 6. **Variables Estáticas**
Las **variables estáticas** son aquellas que pertenecen a la clase en lugar de a una instancia específica. Se utilizan para valores que deben ser comunes para todas las instancias de la clase.

**Ejemplo**:
```csharp
public class Counter
{
    public static int Count = 0; // Variable estática

    public Counter()
    {
        Count++;
    }
}
```

## 7. **Destructores de Variables**
Cuando las variables son del tipo **referencia**, su vida útil termina cuando ya no hay referencias a ellas. El recolector de basura de C# se encarga de liberar la memoria de las variables que ya no son utilizadas.

Para tipos **no gestionados**, se puede utilizar un destructor (`~ClassName`) para liberar recursos no administrados.

**Ejemplo**:
```csharp
public class MyClass
{
    // Destructor para liberar recursos no gestionados
    ~MyClass()
    {
        // Lógica para liberar recursos no gestionados
    }
}
```

## Resumen
- **Declaración explícita**: Se especifica el tipo de la variable.
- **Declaración implícita**: El tipo de la variable se infiere con `var`.
- Las **variables locales** deben ser inicializadas antes de su uso, y pueden ser de tipo valor o referencia.
- Se recomienda seguir convenciones de nombres, como **camelCase** para variables y **PascalCase** para propiedades.
- El uso adecuado de **tipos anulables** (`int?`, `bool?`) permite manejar valores nulos en tipos de valor.

Estas convenciones y prácticas permiten escribir código limpio, claro y eficiente en C#.