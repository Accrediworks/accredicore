using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Accredi.Maui.Messages;
public class LogoutMessage : ValueChangedMessage<bool?>
{
    public LogoutMessage(bool? value = null) : base(value)
    {
    }
}