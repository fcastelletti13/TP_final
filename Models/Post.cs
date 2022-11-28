namespace TP_final;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

public class Post
{
    private int _idPost;
    private string _textoPost;
    private DateTime _fechaCreacion;
    private string _usuario;
    private string _foto;
    public Post(){}
    public Post(int idPost, string textoPost, DateTime fechaCreacion, string usuario, string foto)
    {
        _idPost = idPost;
        _textoPost = textoPost;
        _fechaCreacion = fechaCreacion;
        _usuario = usuario;
        _foto = foto;
        
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
    public string Usuario
    {
        get { return _usuario; }
        set { _usuario = value; }
    }
    public string Foto
    {
        get { return _foto; }
        set { _foto = value; }
    }

}