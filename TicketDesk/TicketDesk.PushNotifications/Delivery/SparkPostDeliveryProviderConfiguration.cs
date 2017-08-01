using System.ComponentModel.DataAnnotations;
using TicketDesk.Localization;
using TicketDesk.Localization.PushNotifications;

namespace TicketDesk.PushNotifications.Delivery
{
    public class SparkPostDeliveryProviderConfiguration : IDeliveryProviderConfiguration
    {
        [Display(Name = "ApiKey", ResourceType = typeof(Strings))]
        [LocalizedDescription("ApiKey_SparkPost_Description", NameResourceType = typeof(Strings))]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(Validation))]
        [DataType(DataType.Password)]
        public string ApiKey { get; set; }

        [Display(Name = "FromAddress", ResourceType = typeof(Strings))]
        [LocalizedDescription("FromAddress_Description", NameResourceType = typeof(Strings))]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(Validation))]
        [DataType(DataType.EmailAddress, ErrorMessageResourceName = "InvalidEmail", ErrorMessageResourceType = typeof(Validation))]
        public string FromAddress { get; set; }

        [Display(Name = "FromDisplayName", ResourceType = typeof(Strings))]
        [LocalizedDescription("FromDisplayName_Description", NameResourceType = typeof(Strings))]
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(Validation))]
        public string FromDisplayName { get; set; }
    }
}
