using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tl2_tp09_2023_alvaroad29
{
    public class Tarea
    {
        int id;
        int id_tablero;
        string nombre;
        string descripcion;
        string color;
        EstadoTarea estado;
        int? idUsuarioAsignado;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Color { get => color; set => color = value; }
        public EstadoTarea Estado { get => estado; set => estado = value; }
        public int? IdUsuarioAsignado { get => idUsuarioAsignado; set => idUsuarioAsignado = value; }
        public int Id_tablero { get => id_tablero; set => id_tablero = value; }
    }

    public enum EstadoTarea
    {
        Ideas, ToDo, Doing, Review, Done
    }
}