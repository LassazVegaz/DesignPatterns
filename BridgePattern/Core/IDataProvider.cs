using BridgePattern.Models;

namespace BridgePattern.Core;

public interface IDataProvider
{
    IEnumerable<User> GetUsers();
}
