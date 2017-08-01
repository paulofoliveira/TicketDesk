using Newtonsoft.Json.Linq;
using S22.Mail;
using SparkPost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TicketDesk.Localization;
using TicketDesk.Localization.PushNotifications;
using TicketDesk.PushNotifications.Model;

// FONTE: https://github.com/darrencauthon/csharp-sparkpost

namespace TicketDesk.PushNotifications.Delivery
{
    [LocalizedDescription("SparkPostProvider", NameResourceType = typeof(Strings))]
    public class SparkPostDeliveryProvider : EmailDeliveryProviderBase
    {
        public SparkPostDeliveryProvider(JToken configuration)
        {
            Configuration = configuration == null ?
                new SparkPostDeliveryProviderConfiguration() :
                configuration.ToObject<SparkPostDeliveryProviderConfiguration>();
        }

        public override async Task<bool> SendNotificationAsync(PushNotificationItem notificationItem, object message, CancellationToken ct)
        {
            var cfg = (SendGridDeliveryProviderConfiguration)Configuration;
            var sent = false;

            MailMessage smsg = message as SerializableMailMessage;

            if (smsg != null)
            {
                try
                {
                    var hView = smsg.AlternateViews.First(v => v.ContentType.MediaType == "text/html");
                    var tView = smsg.AlternateViews.First(v => v.ContentType.MediaType == "text/plain");

                    Transmission transmission = new Transmission();
                    transmission.Content.From.Email = cfg.FromAddress;
                    transmission.Content.From.Name = cfg.FromDisplayName;

                    transmission.Content.Subject = smsg.Subject;
                    transmission.Content.Text = tView.ContentStream.ReadToString();
                    transmission.Content.Html = hView.ContentStream.ReadToString();

                    transmission.Recipients.Add(new Recipient
                    {
                        Address = new Address { Email = notificationItem.Destination.DestinationAddress, Name = notificationItem.Destination.SubscriberName }
                    });

                    var client = new Client(cfg.ApiKey);
                    await client.Transmissions.Send(transmission);
                    sent = true;
                }
                catch (Exception)
                {
                    sent = false;
                    //TODO: log this somewhere
                }
            }


            return sent;
        }
    }
}
