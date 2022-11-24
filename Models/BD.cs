namespace TP_final;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

public static class BD
{
    /*LISTAR*/
    private static string _connectionString = @"Server=DESKTOP-M15HFS0\SQLEXPRESS;DataBase=DBFutbol;Trusted_Connection=True";

    public static List<Equipo> ListarEquipos()
    {
        List<Equipo> ListaEquipos = new List<Equipo>();
        using (SqlConnection bd = new SqlConnection(_connectionString))
        {
            string sql = $"SELECT * FROM Equipos";
            ListaEquipos = bd.Query<Equipo>(sql).ToList();
        }
        return ListaEquipos;
    }
    public static List<Jugador> ListarGoleadores()
    {
        List<Jugador> ListaGoleadores = new List<Jugador>();
        using (SqlConnection bd = new SqlConnection(_connectionString))
        {
            string sql = $"SELECT TOP(10) * FROM Jugadores ORDER BY Goles desc";
            ListaGoleadores = bd.Query<Jugador>(sql).ToList();
        }
        return ListaGoleadores;
    }
    public static List<Jugador> ListarAsistidores()
    {
        List<Jugador> ListaAsistidores = new List<Jugador>();
        using (SqlConnection bd = new SqlConnection(_connectionString))
        {
            string sql = $"SELECT TOP(10) * FROM Jugadores ORDER BY Asistencias desc";
            ListaAsistidores = bd.Query<Jugador>(sql).ToList();
        }
        return ListaAsistidores;
    }
    public static List<Post> ListarPosts()
    {
        List<Post> ListaPosts = new List<Post>();
        using (SqlConnection bd = new SqlConnection(_connectionString))
        {
            string sql = $"SELECT * FROM Posts ORDER BY Likes desc";
            ListaPosts = bd.Query<Post>(sql).ToList();
        }
        return ListaPosts;
    }
    public static List<Partido> ListarPartidos()
    {
        List<Partido> ListaPartidos = new List<Partido>();
        using (SqlConnection bd = new SqlConnection(_connectionString))
        {
            string sql = $"SELECT * FROM Partidos";
            ListaPartidos = bd.Query<Partido>(sql).ToList();
        }
        return ListaPartidos;
    }
}