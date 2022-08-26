using CapaDatos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapaNegocio
{
    public class SocioContactoBusiness
    {
        private SocioContactoRepository socioContactoRepository = new SocioContactoRepository();

        public void Create(string mail, int telefonos, Guid idSocio)
        {
            socioContactoRepository.CreateSocioContacto(mail, telefonos, idSocio);
        }

        public void Update(string mail, int telefonos, string idSocio)
        {
            socioContactoRepository.UpdateSocioContacto(mail, telefonos, idSocio);
        }
        public void Delete(string id)
        {
            socioContactoRepository.DeleteSocioContacto(id);
        }
    }
}
