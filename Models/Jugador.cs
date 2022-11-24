namespace TP_final;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

public class Jugador
{
    private int _idJugador;
    private string _nombreApellido;
    private int _goles;
    private int _asistencias;
    private int _equipo;
    
    public Jugador(){}
    public Jugador(int idJugador, string nombreApellido, int goles, int asistencias, int equipo)
    {
        _idJugador = idJugador;
        _nombreApellido = nombreApellido;
        _goles = goles;
        _asistencias = asistencias;
        _equipo = equipo;
    }
    public int IdJugador
    {
        get{return _idJugador;}
        set{_idJugador = value;}
    }
    public string NombreApellido
    {
        get{return _nombreApellido;}
        set{_nombreApellido = value;}
    }
    public int Goles
    {
        get{return _goles;}
        set{_goles = value;}
    }
    public int Asistencias
    {
        get{return _asistencias;}
        set{_asistencias = value;}
    }
    public int Equipo
    {
        get{return _equipo;}
        set{_equipo = value;}
    }
}