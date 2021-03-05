using System.Collections.Generic;

namespace VS.Task.Business.Models
{
    public class Group
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public ICollection<Provider> Providers { get; set; }
    }
}
