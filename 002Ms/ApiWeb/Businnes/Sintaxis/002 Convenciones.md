# Convenciones a la hora de usar C#

Las convenciones de codificación son esenciales para mantener el código claro, consistente y fácil de mantener. A continuación, se detallan las principales convenciones a seguir al escribir código en C#.

## 1. **Nombres de tipos**
- **Clases**: Utilizar el formato **PascalCase** (la primera letra de cada palabra en mayúscula).
  - Ejemplo: `CustomerOrder`, `EmployeeDetails`, `PaymentGateway`.
  
- **Interfaces**: Utilizar el formato **PascalCase**, precedido por una `I` mayúscula.
  - Ejemplo: `IEnumerable`, `IDisposable`, `IService`.

- **Enumeraciones**: Utilizar **PascalCase**.
  - Ejemplo: `OrderStatus`, `AccountType`.

- **Delegados**: Usar **PascalCase**, como las clases.
  - Ejemplo: `EventHandler`, `Action`.

## 2. **Nombres de variables y campos**
- **Variables locales**: Usar **camelCase** (la primera palabra en minúscula y la siguiente en mayúscula).
  - Ejemplo: `customerName`, `orderDate`, `totalAmount`.

- **Campos privados**: Usar **camelCase** con un prefijo de guion bajo (`_`) para diferenciar de otras variables.
  - Ejemplo: `_totalAmount`, `_customerName`.

- **Propiedades**: Usar **PascalCase**.
  - Ejemplo: `TotalAmount`, `OrderDate`, `CustomerName`.

- **Constantes**: Usar **UPPER_CASE** con guiones bajos entre las palabras.
  - Ejemplo: `MAX_ITEMS`, `DEFAULT_TIMEOUT`.

## 3. **Métodos**
- Utilizar **PascalCase** para los métodos.
  - Ejemplo: `CalculateTotal`, `ProcessOrder`, `GetCustomerDetails`.

## 4. **Parámetros de métodos**
- Usar **camelCase** para los nombres de parámetros.
  - Ejemplo: `customerId`, `orderAmount`, `paymentMethod`.

## 5. **Uso de Espacios y Tabulaciones**
- Utilizar **4 espacios** por nivel de indentación (no usar tabuladores).
- Dejar un espacio después de las comas y operadores.
  - Ejemplo: `var result = Add(3, 5);`

## 6. **Llaves de Bloques de Código**
- Siempre usar llaves, incluso si el bloque de código tiene solo una línea.
  - Ejemplo:
    ```csharp
    if (condition)
    {
        // código aquí
    }
    ```

## 7. **Comentarios**
- **Comentarios en línea**: Usar `//` para comentarios breves en una línea.
  - Ejemplo: `// Esta es una variable de configuración`.

- **Comentarios de bloque**: Usar `/*...*/` para comentarios más largos.
  - Ejemplo:
    ```csharp
    /*
      Este es un comentario largo
      que abarca múltiples líneas.
    */
    ```

- **Comentarios XML**: Usar para describir clases, métodos y propiedades.
  - Ejemplo:
    ```csharp
    /// <summary>
    /// Calcula el total de un pedido.
    /// </summary>
    /// <param name="orderAmount">Monto total del pedido</param>
    /// <returns>Total calculado</returns>
    public decimal CalculateTotal(decimal orderAmount)
    {
        // Implementación
    }
    ```

## 8. **Uso de `var`**
- Usar `var` cuando el tipo es obvio a partir de la inicialización.
  - Ejemplo: `var customer = new Customer();`
- Evitar el uso de `var` cuando el tipo no es evidente o el tipo es complicado (como en el caso de tipos genéricos complejos).

## 9. **Excepciones**
- Usar excepciones para flujos excepcionales, no para control de flujo normal.
- Utilizar bloques `try-catch` solo cuando es necesario capturar errores específicos.
- Cuando se maneja una excepción, se debe proporcionar un mensaje detallado de la causa.
  
  Ejemplo:
  ```csharp
  try
  {
      // Intentar algo
  }
  catch (Exception ex)
  {
      // Loguear error
      Console.WriteLine(ex.Message);
  }
  ```

## 10. **Uso de `async` y `await`**
- Utilizar `async` para métodos que realizan operaciones asíncronas.
- Asegúrate de usar `await` con las llamadas asíncronas, en lugar de `.Result` o `.Wait()`, para evitar bloqueos.
  
  Ejemplo:
  ```csharp
  public async Task<string> GetDataAsync()
  {
      var data = await FetchDataFromApiAsync();
      return data;
  }
  ```

## 11. **Accesibilidad**
- Los métodos y propiedades deben tener el menor nivel de acceso necesario para cumplir con su función.
  - Usar **private** para miembros internos que no deben ser accesibles desde fuera de la clase.
  - Usar **public** cuando se necesita acceso externo.
  - Usar **internal** cuando el acceso debe estar limitado al ensamblaje actual.
  - Usar **protected** para miembros que deben ser accesibles desde la clase base y las clases derivadas.

## 12. **Uso de LINQ**
- Preferir el uso de **LINQ** cuando sea apropiado para escribir consultas más legibles y declarativas.
  - Ejemplo:
    ```csharp
    var evenNumbers = numbers.Where(n => n % 2 == 0).ToList();
    ```

## 13. **Evitar código muerto**
- El código no utilizado o comentado no debe permanecer en el código fuente. Eliminar el código muerto de manera regular.

## 14. **Uso de `using`**
- Para la gestión de recursos, se debe utilizar la instrucción `using` para garantizar la liberación adecuada de los recursos.
  
  Ejemplo:
  ```csharp
  using (var stream = new FileStream("file.txt", FileMode.Open))
  {
      // Uso del stream
  }
  ```

## Resumen
Estas convenciones ayudan a mantener un código limpio, estructurado y fácil de mantener. Seguirlas correctamente mejora la legibilidad del código, facilita la colaboración y hace que el código sea más fácil de depurar.