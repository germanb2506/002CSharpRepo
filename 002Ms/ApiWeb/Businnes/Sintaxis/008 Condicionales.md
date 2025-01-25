# Condicionales en C#

Los condicionales en C# son estructuras de control que permiten ejecutar diferentes bloques de código en función de ciertas condiciones.

---

## 1. **if**

La estructura más básica de control condicional. Evalúa una expresión booleana y, si es verdadera, ejecuta el bloque de código asociado.

### Sintaxis
```csharp
if (condición)
{
    // Código a ejecutar si la condición es verdadera
}
```

### Ejemplo
```csharp
int edad = 20;
if (edad >= 18)
{
    Console.WriteLine("Eres mayor de edad.");
}
```

---

## 2. **if-else**

Proporciona un bloque alternativo si la condición no es verdadera.

### Sintaxis
```csharp
if (condición)
{
    // Código si la condición es verdadera
}
else
{
    // Código si la condición es falsa
}
```

### Ejemplo
```csharp
int edad = 16;
if (edad >= 18)
{
    Console.WriteLine("Eres mayor de edad.");
}
else
{
    Console.WriteLine("Eres menor de edad.");
}
```

---

## 3. **if-else if-else**

Permite evaluar múltiples condiciones en orden secuencial.

### Sintaxis
```csharp
if (condición1)
{
    // Código si condición1 es verdadera
}
else if (condición2)
{
    // Código si condición2 es verdadera
}
else
{
    // Código si ninguna condición es verdadera
}
```

### Ejemplo
```csharp
int nota = 85;

if (nota >= 90)
{
    Console.WriteLine("Calificación: A");
}
else if (nota >= 80)
{
    Console.WriteLine("Calificación: B");
}
else if (nota >= 70)
{
    Console.WriteLine("Calificación: C");
}
else
{
    Console.WriteLine("Calificación: F");
}
```

---

## 4. **Operador Ternario**

Una forma compacta de escribir un `if-else`.

### Sintaxis
```csharp
var resultado = (condición) ? valorSiVerdadero : valorSiFalso;
```

### Ejemplo
```csharp
int edad = 20;
string mensaje = (edad >= 18) ? "Eres mayor de edad." : "Eres menor de edad.";
Console.WriteLine(mensaje);
```

---

## 5. **switch**

Permite evaluar una variable frente a múltiples casos posibles. Es útil cuando hay varias condiciones basadas en el valor de una variable.

### Sintaxis
```csharp
switch (variable)
{
    case valor1:
        // Código si variable == valor1
        break;
    case valor2:
        // Código si variable == valor2
        break;
    default:
        // Código si no coincide con ningún caso
        break;
}
```

### Ejemplo
```csharp
string dia = "Lunes";

switch (dia)
{
    case "Lunes":
        Console.WriteLine("Inicio de semana.");
        break;
    case "Viernes":
        Console.WriteLine("Fin de semana cerca.");
        break;
    case "Sábado":
    case "Domingo":
        Console.WriteLine("Es fin de semana.");
        break;
    default:
        Console.WriteLine("Día entre semana.");
        break;
}
```

---

## 6. **switch (expresiones)**

Desde C# 8.0, es posible utilizar un `switch` basado en expresiones para mayor concisión.

### Sintaxis
```csharp
var resultado = variable switch
{
    valor1 => resultado1,
    valor2 => resultado2,
    _ => resultadoPorDefecto
};
```

### Ejemplo
```csharp
string dia = "Lunes";

string mensaje = dia switch
{
    "Lunes" => "Inicio de semana.",
    "Viernes" => "Fin de semana cerca.",
    "Sábado" or "Domingo" => "Es fin de semana.",
    _ => "Día entre semana."
};

Console.WriteLine(mensaje);
```

---

## 7. **Patrones en switch**

Desde C# 9.0, se pueden usar patrones más avanzados en las condiciones.

### Ejemplo
```csharp
int numero = 5;

string descripcion = numero switch
{
    > 0 => "Número positivo.",
    < 0 => "Número negativo.",
    0 => "Es cero.",
    _ => "Valor no válido."
};

Console.WriteLine(descripcion);
```

---

## 8. **Operadores de Comparación y Lógicos en Condicionales**

- **Operadores de Comparación**:
  - `==` (igual a)
  - `!=` (diferente de)
  - `<`, `>`, `<=`, `>=` (menor, mayor, menor o igual, mayor o igual)

- **Operadores Lógicos**:
  - `&&` (AND lógico)
  - `||` (OR lógico)
  - `!` (NOT lógico)

### Ejemplo:
```csharp
int edad = 25;

if (edad > 18 && edad < 30)
{
    Console.WriteLine("Estás en tus veintes.");
}
else if (edad >= 30 || edad <= 18)
{
    Console.WriteLine("Fuera del rango de los veintes.");
}
```

---

## 9. **Resumen**

| Tipo de Condicional        | Uso Principal                                      |
|----------------------------|---------------------------------------------------|
| `if`                       | Evalúa una sola condición.                        |
| `if-else`                  | Evalúa una condición y tiene una alternativa.     |
| `if-else if-else`          | Evalúa múltiples condiciones.                     |
| Operador Ternario (`? :`)  | Compacta un `if-else` simple.                     |
| `switch`                   | Evalúa un valor frente a múltiples casos.         |
| `switch (expresiones)`     | Simplifica un `switch` usando expresiones.         |
| `switch` con patrones      | Permite evaluaciones avanzadas con expresiones.   |

Con estas herramientas, puedes controlar el flujo de tu programa de manera precisa y eficiente.