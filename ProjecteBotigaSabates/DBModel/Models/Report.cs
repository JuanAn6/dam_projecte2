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
using System.Net.Mail;
using SharpCompress.Common;

namespace DBModel.Models
{
    public static class Report
    {
        //Codi en el que me ajudat amb ChatGPT! https://chatgpt.com/share/6806bbb6-4b7c-800d-b124-1c53ca422a44
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
                    Debug.WriteLine("Descarga de report...");

                    HttpResponseMessage response = await client.GetAsync(urlConParametros);

                    if (response.IsSuccessStatusCode)
                    {
                        byte[] fileBytes = await response.Content.ReadAsByteArrayAsync();
                        await File.WriteAllBytesAsync(outputPath, fileBytes);

                        Debug.WriteLine($"Report guardat: {outputPath}");
                    }
                    else
                    {
                        Debug.WriteLine($"Error al descarregar el report: {response.StatusCode}");
                        string error = await response.Content.ReadAsStringAsync();
                        Debug.WriteLine($"Missarge del server: {error}");
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error: " + ex.Message);
                }
            }
        }


        public static void SendMail(string mail, string num_factura)
        {
            Debug.WriteLine("Send mail to: " + mail);
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("juanantoniogarcia2025@gmail.com", "icft vpmh xuew hogy"),
                    EnableSsl = true,
                };

                var message = new MailMessage
                {
                    From = new MailAddress("juanantoniogarcia2025@gmail.com"),
                    Subject = "Juan Shoes Compra",
                    Body = "<p>Des de la botiga de <b>Juan Shoes</b> agraïmg la teva compra.</p><p>Adjuntem la factura.</p><p>Salut!</p>",
                    IsBodyHtml = true,
                };

                string file_path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FaturaGeneria_" + num_factura + ".pdf");
                if (File.Exists(file_path))
                {
                    Attachment attachment = new Attachment(file_path);
                    message.Attachments.Add(attachment);
                }

                message.To.Add(mail);
                

                smtpClient.Send(message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al enviar el mail!");
            }
        }


    }
}
