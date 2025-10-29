using DatabaseApp.Models;

namespace DatabaseApp.Messages
{
    public class UserAddedMessage
    {
        public User User { get; }
        public UserAddedMessage(User user)
        {
            User = user;
        }
    }
}
