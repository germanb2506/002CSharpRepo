# Bucles en C#

Los bucles en C# permiten ejecutar un bloque de código repetidamente hasta que se cumpla una condición específica o durante un número determinado de iteraciones.

---

## 1. **for**

El bucle `for` es ideal cuando sabes de antemano cuántas veces necesitas iterar.

### Sintaxis
```csharp
for (inicialización; condición; incremento/decremento)
{
    // Código a ejecutar en cada iteración
}
```

### Ejemplo
```csharp
for (int i = 0; i < 5; i++)
{
    Console.WriteLine($"Iteración {i}");
}
```

---

## 2. **foreach**

El bucle `foreach` se utiliza para iterar a través de elementos en una colección (como arreglos o listas).

### Sintaxis
```csharp
foreach (var elemento in colección)
{
    // Código a ejecutar para cada elemento
}
```

### Ejemplo
```csharp
int[] numeros = { 1, 2, 3, 4, 5 };

foreach (int numero in numeros)
{
    Console.WriteLine($"Número: {numero}");
}
```

---

## 3. **while**

El bucle `while` evalúa una condición antes de cada iteración. Se ejecutará mientras la condición sea verdadera.

### Sintaxis
```csharp
while (condición)
{
    // Código a ejecutar mientras la condición sea verdadera
}
```

### Ejemplo
```csharp
int contador = 0;

while (contador < 5)
{
    Console.WriteLine($"Contador: {contador}");
    contador++;
}
```

---

## 4. **do-while**

El bucle `do-while` garantiza que el bloque de código se ejecute al menos una vez, ya que la condición se evalúa después de la iteración.

### Sintaxis
```csharp
do
{
    // Código a ejecutar al menos una vez
} while (condición);
```

### Ejemplo
```csharp
int contador = 0;

do
{
    Console.WriteLine($"Contador: {contador}");
    contador++;
} while (contador < 5);
```

---

## 5. **break**

`break` detiene la ejecución del bucle de inmediato, independientemente de la condición.

### Ejemplo
```csharp
for (int i = 0; i < 10; i++)
{
    if (i == 5)
        break;
    Console.WriteLine($"Iteración {i}");
}
```

---

## 6. **continue**

`continue` salta el resto del código en la iteración actual y pasa a la siguiente iteración.

### Ejemplo
```csharp
for (int i = 0; i < 10; i++)
{
    if (i % 2 == 0)
        continue;
    Console.WriteLine($"Número impar: {i}");
}
```

---

## 7. **Bucles anidados**

Puedes anidar bucles para trabajar con estructuras más complejas.

### Ejemplo
```csharp
for (int i = 1; i <= 3; i++)
{
    for (int j = 1; j <= 3; j++)
    {
        Console.WriteLine($"i: {i}, j: {j}");
    }
}
```

---

## 8. **Iterar con índices en foreach**

Puedes usar `foreach` con índices cuando necesitas conocer la posición actual en la colección. Esto es posible con `foreach` junto con `Enumerable.Range` o métodos adicionales.

### Ejemplo
```csharp
var nombres = new[] { "Ana", "Luis", "Juan" };

for (int i = 0; i < nombres.Length; i++)
{
    Console.WriteLine($"Índice: {i}, Nombre: {nombres[i]}");
}
```

---

## 9. **Resumen**

| Tipo de Bucle      | Uso Principal                                                 |
|--------------------|-------------------------------------------------------------|
| `for`              | Iteraciones controladas con contador.                       |
| `foreach`          | Recorrer elementos de colecciones.                          |
| `while`            | Ejecutar mientras una condición sea verdadera.              |
| `do-while`         | Garantizar al menos una ejecución del código.               |
| `break`            | Salir de un bucle inmediatamente.                           |
| `continue`         | Saltar a la siguiente iteración sin terminar la actual.     |

Con estos bucles puedes implementar estructuras iterativas desde simples hasta complejas.