using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

/*Using Data Annotations to tell EntityFramework
 how to treat the fields of this model*/
using System.ComponentModel.DataAnnotations;


namespace InterviewAPI
{

    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public int Age { get; set; }

    }
}
