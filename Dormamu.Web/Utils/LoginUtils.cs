using Dormamu.Web.Controllers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dormamu.Web.Utils
{
    public class LoginUtils
    {
        private static LoginUtils _loginUtils;

        //public long? UsuarioConectado
        //{
        //    get
        //    {
        //        Startup.Configuration

        //        new LoginController().PessoaConectada();
        //    }
        //}

        private LoginUtils()
        {

        }

        public static LoginUtils Buscar()
        {
            if (_loginUtils == null)
            {
                _loginUtils = new LoginUtils();
            }

            return _loginUtils;
        }
    }
}
