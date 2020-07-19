using WebApi.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace WebApi.Models
{
    public class User : IBaseEntity
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? CreationTime { get; set; }
    }
}
