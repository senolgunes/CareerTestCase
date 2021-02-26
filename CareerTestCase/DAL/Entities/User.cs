using System;
using System.Collections.Generic;

namespace CareerTestCase.DAL.Entities
{
    public partial class User
    {
        public User()
        {
            Applies = new HashSet<Apply>();
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual Cv Cvs { get; set; }
        public virtual ICollection<Apply> Applies { get; set; }
    }
}
