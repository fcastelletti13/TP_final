namespace TP_final;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

public  class Equipo
{
    private int _idEquipo;
    private string _nombre;
    private string _escudo;
    private int _pos;
    private int _pts;
    private int _pj;
    private int _dg;
    
    public Equipo(){}
    public Equipo(int idEquipo, string nombre, string escudo, int pos, int pts, int pj, int dg)
    {
        _idEquipo = idEquipo;
        _nombre = nombre;
        _escudo = escudo;
        _pos = pos;
        _pts = pts;
        _pj = pj;
        _dg = dg;
    }
    public int IdEquipo
    {
        get{return _idEquipo;}
        set{_idEquipo = value;}
    }
    public string Nombre
    {
        get{return _nombre;}
        set{_nombre = value;}
    }
    public string Escudo
    {
        get{return _escudo;}
        set{_escudo = value;}
    }
    public int Pos
    {
        get{return _pos;}
        set{_pos = value;}
    }
    public int PJ
    {
        get{return _pj;}
        set{_pj = value;}
    }
    public int Pts
    {
        get{return _pts;}
        set{_pts = value;}
    }
    public int DG
    {
        get{return _dg;}
        set{_dg = value;}
    }
}