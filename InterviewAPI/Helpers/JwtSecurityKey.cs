using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace InterviewAPI.Helpers
{
    public static class JwtSecurityKey
    {
        public static SymmetricSecurityKey Create(String secret)
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
        }
    }
}
