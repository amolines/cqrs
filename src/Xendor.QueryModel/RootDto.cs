using Newtonsoft.Json;

namespace Xendor.QueryModel
{
    public class RootDto : IRootDto
    {
        [JsonIgnore]
        public long Key { get; set; }
    }
}