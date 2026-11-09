using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Data;

namespace MiAplicacionWeb.Pages
{
    public class DocentesModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public DataTable Datos { get; set; } = new DataTable();

        public DocentesModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task OnGetAsync()
        {
            string cadena = _configuration["ConexionSQL"]!;
            using SqlConnection conexion = new SqlConnection(cadena);
            await conexion.OpenAsync();

            string sql = "SELECT * FROM dbo.Docentes";
            using SqlCommand comando = new SqlCommand(sql, conexion);
            using SqlDataReader lector = await comando.ExecuteReaderAsync();
            Datos.Load(lector);
        }
    }
}
