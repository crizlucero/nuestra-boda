using nuestra_boda.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nuestra_boda.Core.Models.Users
{
    public class ConfirmadosModel
    {
        static readonly DBHelper db = new();

        public long IDConfirmado { get; set; }
        public long IDInvitado { get; set; }
        public uint NumeroInvitados { get; set; }
        public uint NumeroNinios { get; set; }
        public int Confirmacion { get; set; }


        public bool ConfirmarInvitacion()
        {
            try
            {
                Dictionary<string, object> parameters = new() { { "@IDInvitado", IDInvitado }, { "@NumeroInvitados", NumeroInvitados }, { "@NumeroNinios", NumeroNinios }, { "@Confirmacion", Confirmacion } };
                IDConfirmado = db.InsertQuery("INSERT INTO confirmados (IDInvitado, NumeroInvitados, NumeroNinios, Confirmacion) VALUES  (@IDInvitado, @NumeroInvitados, @NumeroNinios, @Confirmacion);", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            if (IDConfirmado != -1)
            {
                return true;
            }
            return false;
        }
    }
}
