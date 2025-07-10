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
string query = "INSERT INTO Integrantes (Nombre, Password, Email, FechaNacimiento, Domicilio, Genero) VALUES(@pNombre, @pPassword, @pEmail, @pFechaNacimiento, @pDomicilio, @pGenero) ";
using (SqlConnection connection = new SqlConnection(_connectionString))
{
connection.Execute (query, new{pNombre = integrante.Nombre , pPassword = integrante.Password, pEmail = integrante.Email, pFechaNacimiento = integrante.FechaNacimiento, pDomicilio = integrante.Domicilio, pGenero = integrante.Genero});
}
}

    }
