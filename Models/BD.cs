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
            string sql = $"SELECT * FROM Posts Order by IdPost desc";
            ListaPosts = bd.Query<Post>(sql).ToList();
        }
        return ListaPosts;
    }
    public static void AgregarPost(Post post){

        string sql = $"Insert into Posts([TextoPost], [IdUsuario], [FechaCreacion], [Foto]) VALUES ('{post.TextoPost}',{post.IdUsuario},@FechaCreacion, '{post.Foto}')";
        using (SqlConnection bd = new SqlConnection(_connectionString)){
            bd.Execute(sql,new {FechaCreacion = post.FechaCreacion});
        }
    }
     public static void EliminarPost(int IdPost){

        string sql = $"Delete From Posts Where IdPost = '{IdPost}'";
        using (SqlConnection bd = new SqlConnection(_connectionString)){
            bd.Execute(sql);
        }
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
    public static List<Usuario> ListarUsuarios()
    {
        List<Usuario> ListaUsuarios = new List<Usuario>();
        using (SqlConnection bd = new SqlConnection(_connectionString))
        {
            string sql = $"SELECT * FROM Usuarios";
            ListaUsuarios = bd.Query<Usuario>(sql).ToList();
        }
        return ListaUsuarios;
    }
    public static Usuario ListarUnUsuario(int idUsuario)
    {
        Usuario usuario = new Usuario();
        using (SqlConnection bd = new SqlConnection(_connectionString))
        {
            string sql = $"SELECT * FROM Usuarios WHERE IdUsuario = {idUsuario}";
            usuario = bd.QueryFirstOrDefault<Usuario>(sql);
        }
        return usuario;
    }

    public static Jugador ListarUnJugador(int idJugador)
    {
        Jugador jugador = new Jugador();
        using (SqlConnection bd = new SqlConnection(_connectionString))
        {
            string sql = $"SELECT * FROM Jugadores WHERE IdJugador = {idJugador}";
            jugador = bd.QueryFirstOrDefault<Jugador>(sql);
        }
        return jugador;
    }
    public static Equipo ListarUnEquipo(int idEquipo)
    {
        Equipo equipo = new Equipo();
        using (SqlConnection bd = new SqlConnection(_connectionString))
        {
            string sql = $"SELECT * FROM Equipos WHERE IdEquipo = {idEquipo}";
            equipo = bd.QueryFirstOrDefault<Equipo>(sql);
        }
        return equipo;
    }
    public static int AgregarUsuario(Usuario usuario)
    {
        string sql = $"INSERT INTO Usuarios([Nombre], [Contraseña], [Foto]) VALUES('{usuario.Nombre}', '{usuario.Contraseña}', '{usuario.Foto}')";
        int id = -1;
        using (SqlConnection bd = new SqlConnection(_connectionString))
        {
            bd.Execute(sql);
            sql = $"select top 1 IdUsuario from Usuarios where Nombre = '{usuario.Nombre}' order by IdUsuario desc";
            id = bd.QueryFirstOrDefault<int>(sql);
        }
        return id;
    }
}