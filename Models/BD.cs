namespace TP0_INTROBD;
using Microsoft.Data.SqlClient;
using Dapper;


    public class BD
    {
        private static string _connectionString = @"Server=localhost;DataBase=Tp0_IntroBD;Integrated Security=True;TrustServerCertificate=True;";
        public List<Integrantes> Integrantes()
{
    List<Integrantes> integrantes = new List<Integrantes>();
    using(SqlConnection connection = new SqlConnection(_connectionString))
    {
        string query = "SELECT * FROM Integrantes";
        integrantes = connection.Query<Integrantes>(query).ToList();
    }
    return integrantes;
}

public void AgregarIntegrante (Integrantes integrante)
{
string query = "INSERT INTO Integrantes (Nombre, Password, Email, FechaNacimiento, Domicilio, Genero, Equipo) VALUES(@pNombre, @pPassword, @pEmail, @pFechaNacimiento, @pDomicilio, @pGenero, @pEquipo)";
using (SqlConnection connection = new SqlConnection(_connectionString))
{
connection.Execute (query, new{pNombre = integrante.Nombre , pPassword = integrante.Password, pEmail = integrante.Email, pFechaNacimiento = integrante.FechaNacimiento, pDomicilio = integrante.Domicilio, pGenero = integrante.Genero, pEquipo=integrante.Equipo});
}
}
public List<Integrantes> ObtenerIntegrantesDelEquipo(int idIntegrante)
{
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        connection.Open();

        // Obtenemos el equipo del integrante
        int equipo = connection.QueryFirstOrDefault<int>(
            "SELECT Equipo FROM Integrantes WHERE IdIntegrantes = @Id",
            new { Id = idIntegrante });

        if (equipo == 0)
            return new List<Integrantes>();

        // Obtenemos todos los integrantes del equipo
        var integrantesEquipo = connection.Query<Integrantes>(
            "SELECT * FROM Integrantes WHERE Equipo = @Equipo",
            new { Equipo = equipo }).ToList();

        return integrantesEquipo;
    }
}


    }
