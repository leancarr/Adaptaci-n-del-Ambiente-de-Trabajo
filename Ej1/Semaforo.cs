namespace Ej1
{
    public class Semaforo
    {
        private string _color;
        private int _tiempoAcumulado;
        private bool _esIntermitente; // Nueva bandera para controlar el modo

        public Semaforo(string colorInicial)
        {
            ValidarColor(colorInicial);
            _color = colorInicial;
            _tiempoAcumulado = 0;
            _esIntermitente = false;
        }

        public void pasoDelTiempo(int segundos)
        {
            if (_esIntermitente)
            {
                // Lógica Intermitente: Alterna cada 1 segundo
                _tiempoAcumulado += segundos;
                while (_tiempoAcumulado >= 1)
                {
                    _color = (_color == "Amarillo") ? "Apagado" : "Amarillo";
                    _tiempoAcumulado -= 1;
                }
            }
            else
            {
                // Lógica Normal: Usamos tu motor de estados profesional
                int tiempoRestante = segundos;
                while (tiempoRestante > 0)
                {
                    int limite = ObtenerLimite(_color);
                    int necesario = limite - _tiempoAcumulado;

                    if (tiempoRestante >= necesario)
                    {
                        tiempoRestante -= necesario;
                        CambiarEstado();
                        _tiempoAcumulado = 0;
                    }
                    else
                    {
                        _tiempoAcumulado += tiempoRestante;
                        tiempoRestante = 0;
                    }
                }
            }
        }

        public void mostrarColor()
        {
            Console.WriteLine($"El semáforo está en: {_color}");
        }

        public void ponerEnIntermitente()
        {
            _esIntermitente = true;
            _color = "Amarillo"; // Inicializamos el modo intermitente
            _tiempoAcumulado = 0;
            Console.WriteLine("Modo intermitente activado.");
        }

        public void sacarDeIntermitente()
        {
            _esIntermitente = false;
            _color = "Rojo"; // Retomamos la secuencia normal desde Rojo
            _tiempoAcumulado = 0;
            Console.WriteLine("Modo intermitente desactivado. Secuencia normal retomada.");
        }

        // --- Métodos auxiliares para mantener el código limpio ---

        private void ValidarColor(string color)
        {
            string[] validos = { "Rojo", "Rojo + Amarillo", "Verde", "Amarillo" };
            if (!validos.Contains(color)) throw new ArgumentException("Color inválido");
        }

        private int ObtenerLimite(string color) => color switch
        {
            "Rojo" => 30,
            "Rojo + Amarillo" => 2,
            "Verde" => 20,
            "Amarillo" => 2,
            _ => 0
        };

        private void CambiarEstado()
        {
            _color = _color switch
            {
                "Rojo" => "Rojo + Amarillo",
                "Rojo + Amarillo" => "Verde",
                "Verde" => "Amarillo",
                "Amarillo" => "Rojo",
                _ => "Rojo"
            };
        }
    }
}