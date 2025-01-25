# Conversiones de Datos en C#

En C#, las conversiones de datos son necesarias cuando se necesita convertir un tipo de dato en otro. Estas conversiones pueden ser **implícitas** (automáticas) o **explícitas** (requieren intervención del programador). Además, hay herramientas específicas para conversiones avanzadas, como el uso de métodos de la clase `Convert` y el manejo de excepciones en conversiones inseguras.

---

## 1. **Conversión Implícita**

La **conversión implícita** ocurre de manera automática y no requiere intervención del programador. Se realiza únicamente cuando no hay pérdida de datos o riesgo de error. 

### Ejemplo:
```csharp
int intValue = 10;
double doubleValue = intValue; // Conversión implícita de int a double
```

### Reglas:
- Solo entre tipos compatibles (e.g., de tipos más pequeños a más grandes, como `int` a `long` o `float` a `double`).
- No requiere sintaxis especial.

---

## 2. **Conversión Explícita (Casting)**

La **conversión explícita** se utiliza cuando hay posibilidad de pérdida de datos o incompatibilidad entre los tipos. El programador utiliza la sintaxis de **casting** para realizar la conversión.

### Sintaxis:
```csharp
(tipoDestino) valor
```

### Ejemplo:
```csharp
double doubleValue = 10.5;
int intValue = (int)doubleValue; // Conversión explícita, trunca la parte decimal
```

### Consideraciones:
- Puede provocar pérdida de datos (e.g., truncamiento de decimales).
- Es el programador quien asume el riesgo de error.

---

## 3. **Clase `Convert`**

C# proporciona la clase `Convert` para realizar conversiones seguras entre tipos. Esta clase ofrece métodos estáticos como `ToInt32`, `ToDouble`, etc.

### Ejemplo:
```csharp
string stringValue = "123";
int intValue = Convert.ToInt32(stringValue); // Convierte un string a int
```

### Métodos comunes:
- `Convert.ToInt32()`: Convierte a `int`.
- `Convert.ToDouble()`: Convierte a `double`.
- `Convert.ToBoolean()`: Convierte a `bool`.
- `Convert.ToString()`: Convierte a `string`.

---

## 4. **Método `Parse`**

Se utiliza para convertir una cadena (`string`) en un tipo de dato específico. Está disponible en tipos como `int`, `double`, `decimal`, etc.

### Ejemplo:
```csharp
string stringValue = "123.45";
double doubleValue = double.Parse(stringValue); // Convierte el string a double
```

### Consideraciones:
- Lanza una excepción si la cadena no tiene un formato válido.
- No debe usarse directamente si no se tiene certeza del formato.

---

## 5. **Método `TryParse`**

Una alternativa segura a `Parse`, que evita excepciones en caso de error. Devuelve `true` si la conversión es exitosa y `false` en caso contrario.

### Ejemplo:
```csharp
string stringValue = "123.45";
bool success = double.TryParse(stringValue, out double doubleValue);

if (success)
{
    Console.WriteLine($"Conversión exitosa: {doubleValue}");
}
else
{
    Console.WriteLine("Error en la conversión.");
}
```

---

## 6. **Conversión entre Tipos de Referencia**

### `as` y `is`
Se usan para conversiones entre tipos de referencia.

- **`as`**: Realiza una conversión segura. Devuelve `null` si no es posible.
- **`is`**: Verifica si el objeto es de un tipo específico.

### Ejemplo:
```csharp
object obj = "Hola Mundo";
string str = obj as string; // Conversión segura
if (obj is string)
{
    Console.WriteLine("El objeto es un string.");
}
```

---

## 7. **Conversión entre Tipos Numéricos y `string`**

### Usando `ToString()`:
Convierte un tipo numérico a una representación de cadena.

**Ejemplo:**
```csharp
int intValue = 123;
string stringValue = intValue.ToString(); // Resultado: "123"
```

### Usando `string.Format` o interpolación:
Permite dar formato a los valores al convertirlos.

**Ejemplo:**
```csharp
double value = 123.456;
string formatted = $"El valor es: {value:F2}"; // Resultado: "El valor es: 123.46"
```

---

## 8. **Boxing y Unboxing**

### Boxing:
Convierte un tipo de valor a un tipo de referencia (`object`).

**Ejemplo:**
```csharp
int intValue = 123;
object obj = intValue; // Boxing
```

### Unboxing:
Convierte un tipo de referencia a un tipo de valor.

**Ejemplo:**
```csharp
object obj = 123;
int intValue = (int)obj; // Unboxing
```

### Consideraciones:
- El **boxing** y **unboxing** pueden afectar el rendimiento, ya que requieren asignación y recuperación de memoria en el heap.

---

## Resumen de Métodos y Técnicas

| Método / Técnica       | Conversión                                    | Seguro       |
|------------------------|-----------------------------------------------|--------------|
| Implícita              | De tipos compatibles                         | Sí           |
| Explícita (casting)    | Conversión manual con riesgo de error         | No           |
| `Convert`              | Métodos estáticos para conversión segura      | Sí           |
| `Parse`                | Convierte cadenas en tipos básicos            | No           |
| `TryParse`             | Alternativa segura a `Parse`                  | Sí           |
| `ToString()`           | Convierte valores en cadenas                  | Sí           |
| Boxing / Unboxing      | Entre tipos de valor y referencia             | No (costo)   |

---

Con estas herramientas y técnicas, es posible manejar conversiones de datos de manera eficiente y segura en C#.