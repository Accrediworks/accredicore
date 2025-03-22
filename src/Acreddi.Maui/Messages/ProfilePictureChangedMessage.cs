using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Acreddi.Maui.Messages;

public class ProfilePictureChangedMessage : ValueChangedMessage<string>
{
    public ProfilePictureChangedMessage(string value) : base(value)
    {
    }
}
