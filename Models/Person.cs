using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCTask.Models
{
    public class Person
    {
        [RegularExpression("[a-zA-Z]{0,30}")]
        public string Nickname { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}