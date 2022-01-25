using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dormamu.Web.Controllers
{
    public class BaseController : Controller
    {
        public long? PessoaConectada()
        {
            if (User.Identity.IsAuthenticated)
            {
                var identity = User.Identities.FirstOrDefault(identity => identity.AuthenticationType == "Identity.Login");
                string strUser = identity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;

                if (!string.IsNullOrEmpty(strUser))
                {
                    long user = Convert.ToInt64(strUser);
                    return user;
                }
            }
            return null;
        }
    }
}
