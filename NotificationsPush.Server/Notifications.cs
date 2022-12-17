namespace NotificationsPush.Server;

using FirebaseAdmin.Messaging;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;

public class NotificationMessage
{
    public string? Message { get; set; }
}

public class Notifications
{
    private readonly ILogger logger;

    public Notifications(ILoggerFactory loggerFactory)
    {
        this.logger = loggerFactory.CreateLogger<Notifications>();
    }

    [Function("SendNotifications")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = "notificaciones")] HttpRequestData req)
    {
        this.logger.LogInformation("Preparando el envio del mensaje...");

        StreamReader sr = new(req.Body);
        var notificationMessage = JsonConvert.DeserializeObject<NotificationMessage>(sr.ReadToEnd());

        var message = new Message()
        {
            Topic = "Bienvenido",
            Notification = new Notification()
            {
                Title = "Bienvenido",
                Body = notificationMessage.Message ?? "Bienvenido usuario",
            }
        };

        string result = await FirebaseMessaging.DefaultInstance.SendAsync(message);
        this.logger.LogInformation($"Respuesta: {result}");

        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
        response.WriteString("Mensaje enviado");
        return response;
    }
}
