namespace TP_final;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

public class Usuario
{
    private int _idUsuario;
    private string _nombre;
    private string _contrasenia;
    private string _foto;
    public Usuario(){}
    public Usuario(int idUsuario, string nombre, string contrasenia , string foto)
    {
        _idUsuario = idUsuario;
        _nombre = nombre;
        _contrasenia = contrasenia;
        _foto = foto;
    }
    public int idUsuario
    {
        get { return _idUsuario; }
        set { _idUsuario = value; }
    }
    public string Nombre
    {
        get { return _nombre; }
        set { _nombre = value; }
    }
    public string Contrasenia
    {
        get { return _contrasenia; }
        set { _contrasenia = value; }
    }
    public string Foto
    {
        get { return _foto; }
        set { _foto = value; }
    }
}