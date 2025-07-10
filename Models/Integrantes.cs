using Newtonsoft.Json;
using Microsoft.Data.SqlClient;
using Dapper;
namespace TP0_INTROBD;

public class Integrantes{
[JsonProperty]
 public string Nombre {get; set; }
 [JsonProperty]
public string Password{get; set; }
[JsonProperty]

public string Email{get; set; }
[JsonProperty]
public DateTime FechaNacimiento {get; set; }
[JsonProperty]

public int IdIntegrantes {get; set; }
[JsonProperty]

public string Domicilio {get; set; }
[JsonProperty]

public string Genero {get; set; }



}