using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

namespace tl2_tp09_2023_alvaroad29
{
    public class TareaRepository : ITareaRepository
    {
        private string cadenaConexion = "Data Source=DB/kanban.db;Cache=Shared";
        public void Create(int idTablero, Tarea tarea)
        {
            var query = @"INSERT INTO Tarea(id_tablero, nombre, estado, descripcion, color) VALUES(@idTablero,@nombre,@estado,@descripcion,@color);";
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                var command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@idTablero",idTablero));
                command.Parameters.Add(new SQLiteParameter("@nombre",tarea.Nombre));
                command.Parameters.Add(new SQLiteParameter("@estado",tarea.Estado));
                command.Parameters.Add(new SQLiteParameter("@descripcion",tarea.Descripcion));
                command.Parameters.Add(new SQLiteParameter("@color",tarea.Color));
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();   
            }
        }

        public void Update(int id, Tarea tarea)
        {
            var query = @"UPDATE Tarea SET nombre = @nombre, descripcion = @descripcion, color = @color, estado = @estado WHERE id = @id";
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                var command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@nombre", tarea.Nombre));
                command.Parameters.Add(new SQLiteParameter("@descripcion", tarea.Descripcion));
                command.Parameters.Add(new SQLiteParameter("@estado", tarea.Estado));
                command.Parameters.Add(new SQLiteParameter("@color", tarea.Color));
                command.Parameters.Add(new SQLiteParameter("@id", id));
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public Tarea GetById(int id)
        {
            var tarea = new Tarea();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = @"SELECT * FROM Tarea WHERE id = @idTarea";
                command.Parameters.Add(new SQLiteParameter("@idTarea", id));
                connection.Open();
                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tarea.Id = Convert.ToInt32(reader["id"]);
                        tarea.Id_tablero = Convert.ToInt32(reader["id_tablero"]);
                        tarea.Nombre = reader["nombre"].ToString();
                        tarea.Estado = (EstadoTarea)Convert.ToInt32(reader["estado"]); //?
                        tarea.Descripcion = reader["descripcion"].ToString();
                        tarea.Color = reader["color"].ToString();
                        tarea.IdUsuarioAsignado = reader["id_usuario_asignado"] as int?;
                    }
                }
                connection.Close();
            }

            return tarea;
        }

        public List<Tarea> GetAllByIdUsuario(int id)
        {
            List<Tarea> tareas = new List<Tarea>();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = @"SELECT * FROM Tarea WHERE id_usuario_asignado = @idUsuario";
                command.Parameters.Add(new SQLiteParameter("@idUsuario", id));
                connection.Open();
                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tarea = new Tarea();
                        tarea.Id = Convert.ToInt32(reader["id"]);
                        tarea.Id_tablero = Convert.ToInt32(reader["id_tablero"]);
                        tarea.Nombre = reader["nombre"].ToString();
                        tarea.Estado = (EstadoTarea)Convert.ToInt32(reader["estado"]);
                        tarea.Descripcion = reader["descripcion"].ToString();
                        tarea.Color = reader["color"].ToString();
                        tarea.IdUsuarioAsignado = reader["id_usuario_asignado"] as int?;
                        tareas.Add(tarea);
                    }
                }
                connection.Close();
            }

            return tareas;
        }

        public List<Tarea> GetAllByIdTablero(int id)
        {
            List<Tarea> tareas = new List<Tarea>();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = @"SELECT * FROM Tarea WHERE id_tablero = @idTablero";
                command.Parameters.Add(new SQLiteParameter("@idTablero", id));
                connection.Open();
                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tarea = new Tarea();
                        tarea.Id = Convert.ToInt32(reader["id"]);
                        tarea.Id_tablero = Convert.ToInt32(reader["id_tablero"]);
                        tarea.Nombre = reader["nombre"].ToString();
                        tarea.Estado = (EstadoTarea)Convert.ToInt32(reader["estado"]);
                        tarea.Descripcion = reader["descripcion"].ToString();
                        tarea.Color = reader["color"].ToString();
                        tarea.IdUsuarioAsignado = reader["id_usuario_asignado"] as int?; //si es null da problemas
                        tareas.Add(tarea);
                    }
                }
                connection.Close();
            }

            return tareas;
        }

        public List<Tarea> GetAllByEstado(EstadoTarea estado)
        {
            List<Tarea> tareas = new List<Tarea>();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = @"SELECT * FROM Tarea WHERE estado = @estado";
                command.Parameters.Add(new SQLiteParameter("@estado", Convert.ToInt32(estado))); //?
                connection.Open();
                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tarea = new Tarea();
                        tarea.Id = Convert.ToInt32(reader["id"]);
                        tarea.Id_tablero = Convert.ToInt32(reader["id_tablero"]);
                        tarea.Nombre = reader["nombre"].ToString();
                        tarea.Estado = (EstadoTarea)Convert.ToInt32(reader["estado"]);
                        tarea.Descripcion = reader["descripcion"].ToString();
                        tarea.Color = reader["color"].ToString();
                        tarea.IdUsuarioAsignado = reader["id_usuario_asignado"] as int?;
                        tareas.Add(tarea);
                    }
                }
                connection.Close();
            }

            return tareas;
        }

        public void Remove(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = connection.CreateCommand();
                command.CommandText = @"DELETE FROM Tarea WHERE id = @id;";
                command.Parameters.Add(new SQLiteParameter("@id", id));
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void AsignarTarea(int idUsuario, int idTarea)
        {
            var query = @"UPADTE Tarea SET id_usuario_asignado = @idUsuario WHERE id = @idTarea";
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                var command = new SQLiteCommand(query, connection);
                command.Parameters.Add(new SQLiteParameter("@idUsuario", idUsuario));
                command.Parameters.Add(new SQLiteParameter("@idTarea", idTarea));
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}