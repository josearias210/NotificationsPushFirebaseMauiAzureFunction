using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .Build();

// Reemplace todos los valores con lo de si configuración.
string jsonData = @"{
                  'type': 'service_account',
                  'project_id': 'xxxxx-xxx-xxxx',
                  'private_key_id': 'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx',
                  'private_key': '-----BEGIN PRIVATE KEY-----\xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx\n-----END PRIVATE KEY-----\n',
                  'client_email': 'firebase-adminsdk-bpkgb@message-push-195b5.iam.gserviceaccount.com',
                  'client_id': 'xxxxxxxxxxxxxxxxxxxxxxxx',
                  'auth_uri': 'https://accounts.google.com/o/oauth2/auth',
                  'token_uri': 'https://oauth2.googleapis.com/token',
                  'auth_provider_x509_cert_url': 'https://www.googleapis.com/oauth2/v1/certs',
                  'client_x509_cert_url': 'https://www.googleapis.com/robot/v1/metadata/x509/firebase-adminsdk-bpkgb%40message-push-195b5.iam.gserviceaccount.com'
                }";

if (FirebaseApp.DefaultInstance == null)
{
    FirebaseApp.Create(new AppOptions()
    {
        Credential = GoogleCredential.FromJson(jsonData)
    });
}

host.Run();
