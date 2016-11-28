using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHinernateTestApp
{
    public enum UserType
    {
        ProjectManager,
        TeamLeader,
        Cordinator,
        TeamMember


    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public UserType Type { get; set; }

    }
}
