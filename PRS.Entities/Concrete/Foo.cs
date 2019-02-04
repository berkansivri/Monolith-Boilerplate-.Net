using Dapper.Contrib;
using PRS.Entities.Abstract;
using System.ComponentModel;

namespace PRS.Entities.Concrete
{
    [Table("DENEME2")]
    public class Foo : IEntity
    {
        [Key, Description("ID")]
        public int Id { get; set; }
        [Description("NAME")]
        public string Name { get; set; }
    }
}