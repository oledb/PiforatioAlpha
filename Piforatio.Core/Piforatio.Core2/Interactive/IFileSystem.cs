using System.Collections.Generic;

namespace Piforatio.Core2
{
    public interface IFileSystem
    {
        Dictionary<string, string> GetFiles();
    }
}
