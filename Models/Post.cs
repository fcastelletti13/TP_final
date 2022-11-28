namespace TP_final;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

public class Post
{
    private int _idPost;
    private string _textoPost;
    private DateTime _fechaCreacion;
    private int _idUsuario;
    private string _foto;
    private Usuario _usuario;
    public Post(){}
    public Post(int idPost, string textoPost, DateTime fechaCreacion, int idUsuario, string foto, Usuario usuario)
    {
        _idPost = idPost;
        _textoPost = textoPost;
        _fechaCreacion = fechaCreacion;
        _idUsuario = idUsuario;
        _foto = foto;
        
    }
    public Usuario Usuario
    {
        get { return _usuario; }
        set { _usuario = value; }
    }
    public int IdPost
    {
        get { return _idPost; }
        set { _idPost = value; }
    }
    public string TextoPost
    {
        get { return _textoPost; }
        set { _textoPost = value; }
    }
    public DateTime FechaCreacion
    {
        get { return _fechaCreacion; }
        set { _fechaCreacion = value; }
    }
    public int IdUsuario
    {
        get { return _idUsuario; }
        set { _idUsuario = value; }
    }
    public string Foto
    {
        get { return _foto; }
        set { _foto = value; }
    }

}