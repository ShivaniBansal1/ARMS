using Hrms.Core.Domains.Entities;

namespace Arms.Domain.Entities
{
    public class Location : Entity
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
    }
}