using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechAgCompany.Entities
{
    public class userInfo
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
