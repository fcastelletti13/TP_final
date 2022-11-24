namespace TP_final;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

public class Partido
{
    private int _idPartido;
    private int _fecha;
    private DateTime _horario;
    private int _golesL;
    private int _golesV;
    private string _nombreL;
    private string _nombreV;

    public Partido() { }
    public Partido(int idPartido, int fecha, DateTime horario, int golesL, int golesV, string nombreL, string nombreV)
    {
        _idPartido = idPartido;
        _fecha = fecha;
        _horario = horario;
        _golesL = golesL;
        _golesV = golesV;
        _nombreL = nombreL;
        _nombreV = nombreV;
    }
    public int IdPartido
    {
        get { return _idPartido; }
        set { _idPartido = value; }
    }
    public int Fecha
    {
        get { return _fecha; }
        set { _fecha = value; }
    }
    public DateTime Horario
    {
        get { return _horario; }
        set { _horario = value; }
    }    
    public int GolesL
    {
        get { return _golesL; }
        set { _golesL = value; }
    }
    public int GolesV
    {
        get { return _golesV; }
        set { _golesV = value; }
    }
    public string NombreL
    {
        get { return _nombreL; }
        set { _nombreL = value; }
    }
    public string NombreV
    {
        get { return _nombreV; }
        set { _nombreV = value; }
    }
}