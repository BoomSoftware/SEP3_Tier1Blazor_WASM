namespace SEP3_Tier1Blazor_WASM.Models
{
    public class NotificationModel
    {
        public UserShortVersion NotificationOwner { get; set; }
        public string Content { get; set; }
        public NotificationType Type { get; set; }
        
    }
}