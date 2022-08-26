using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CapaNegocio
{
    public class SocioBusiness
    {

        private SocioRepository socioRepository = new SocioRepository();
        private SocioContactoRepository socioContactoRepository = new SocioContactoRepository();
        private SocioContactoBusiness socioContactoBusiness = new SocioContactoBusiness();

        public DataTable View()
        {
            DataTable tabla = new DataTable();
            tabla = socioRepository.ReadAllSocios();
            return tabla;
        }
        public void Create(string nombre, string apellido, string direccion, string tipoDocId, int documento, string tipoSocioId, string mail, int telefonos)
        {
            switch (tipoDocId)
            {
                case "DNI":
                    tipoDocId = "b06923ff-6d76-4774-b250-975484110f13";
                    break;
                case "Libreta de Enrolamiento":
                    tipoDocId = "9fea6984-a77a-42bc-aac8-d2a0c02385fe";
                    break;
                default:
                    break;
            }

            switch (tipoSocioId)
            {
                case "Vitalicio":
                    tipoSocioId = "9d6ee309-e42d-4f86-ab61-939bfc6ee062";
                    break;
                case "Regular":
                    tipoSocioId = "eaed5c1b-4de4-42f2-894e-00256075ab91";
                    break;
                case "No Socio":
                    tipoSocioId = "16f0529f-9873-4162-bdf6-69a39dd4ae38";
                    break;
                default:
                    break;
            }


            var idSocio = Guid.NewGuid();
            socioRepository.CreateSocio(idSocio, nombre, apellido, direccion, tipoDocId, documento, tipoSocioId);
            socioContactoBusiness.Create(mail, telefonos, idSocio);
        }

        public void Update(string id,string nombre, string apellido, string direccion, string tipoDocId, int documento, string tipoSocioId, string mail, int telefonos)
        {
            switch (tipoDocId)
            {
                case "DNI":
                    tipoDocId = "b06923ff-6d76-4774-b250-975484110f13";
                    break;
                case "Libreta de Enrolamiento":
                    tipoDocId = "9fea6984-a77a-42bc-aac8-d2a0c02385fe";
                    break;
                default:
                    break;
            }

            switch (tipoSocioId)
            {
                case "Vitalicio":
                    tipoSocioId = "9d6ee309-e42d-4f86-ab61-939bfc6ee062";
                    break;
                case "Regular":
                    tipoSocioId = "eaed5c1b-4de4-42f2-894e-00256075ab91";
                    break;
                case "No Socio":
                    tipoSocioId = "16f0529f-9873-4162-bdf6-69a39dd4ae38";
                    break;
                default:
                    break;
            }

            socioRepository.UpdateSocio(id,nombre, apellido, direccion, tipoDocId, documento, tipoSocioId);
            socioContactoBusiness.Update(mail, telefonos, id);
        }

        public void Delete(string id)
        {
            socioContactoBusiness.Delete(id);
            socioRepository.DeleteSocio(id);           
        }
    }
}
