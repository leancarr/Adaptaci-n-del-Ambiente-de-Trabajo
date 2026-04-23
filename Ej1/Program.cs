namespace Ej1
{
    using System;

    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Prueba de Inicialización ===");

            // Creamos el semáforo en Verde (arranca en segundo 0)
            Semaforo semaforo = new Semaforo("Verde");

            // Verificamos el estado inicial
            Console.WriteLine("\nEstado recién creado:");
            semaforo.mostrarColor(); // Debería mostrar 0s acumulados

            // Avanzamos 10 segundos, debería estar en Verde con 10s acumulados
            Console.WriteLine("\n--- Avanzando 10 segundos ---");
            semaforo.pasoDelTiempo(10);
            semaforo.mostrarColor();

            // Avanzamos otros 15 segundos. 
            // Como estaba en 10s, y el Verde dura 20s:
            // Se consumen los 10s restantes del Verde (cambia a Amarillo)
            // Sobran 5s que el Amarillo consume.
            Console.WriteLine("\n--- Avanzando 15 segundos adicionales (Cambio a Amarillo) ---");
            semaforo.pasoDelTiempo(15);
            semaforo.mostrarColor(); // Debería estar en Amarillo con 5s acumulados
        }
    }
}