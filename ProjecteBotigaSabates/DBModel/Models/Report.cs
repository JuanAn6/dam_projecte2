using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Diagnostics;

namespace DBModel.Models
{
    public static class Report
    {
        //Codi preparat amb ChatGPT! https://chatgpt.com/share/6806bbb6-4b7c-800d-b124-1c53ca422a44
        public static async Task DownloadReport(string num_fatura)
        {
            string jasperUrl = "http://localhost:8080/jasperserver/rest_v2/reports/Projecte2/FacturaGenerica.pdf";
            string outputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FaturaGeneria_"+ num_fatura+".pdf");
            
            string parametro = "numFactura="+ num_fatura;

            string urlConParametros = $"{jasperUrl}?{parametro}";

            string username = "jasperadmin";
            string password = "bitnami";

            using (HttpClient client = new HttpClient())
            {
                // Autenticación básica
                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{username}:{password}");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                try
                {
                    Debug.WriteLine("Descargando reporte...");

                    HttpResponseMessage response = await client.GetAsync(urlConParametros);

                    if (response.IsSuccessStatusCode)
                    {
                        byte[] fileBytes = await response.Content.ReadAsByteArrayAsync();
                        await File.WriteAllBytesAsync(outputPath, fileBytes);

                        Debug.WriteLine($"Reporte guardado en: {outputPath}");
                    }
                    else
                    {
                        Debug.WriteLine($"Error al descargar el reporte. Código: {response.StatusCode}");
                        string error = await response.Content.ReadAsStringAsync();
                        Debug.WriteLine($"Mensaje del servidor: {error}");
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
