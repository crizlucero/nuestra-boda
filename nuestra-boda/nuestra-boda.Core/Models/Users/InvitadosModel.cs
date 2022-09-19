using nuestra_boda.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Data;

namespace nuestra_boda.Core.Models.Users
{
    public class InvitadosModel
    {
        static readonly DBHelper db = new();

        public long IDInvitado { get; set; }
        public string Anfitrion { get; set; }
        public string Invitado { get; set; }
        public string Alias { get; set; }
        public uint NumeroRecepciones { get; set; }
        public uint NumeroNinios { get; set; }
        public string TipoInvitacion { get; set; }
        public string TipoRelacion { get; set; }
        public string Correo { get; set; }
        public string Celular { get; set; }
        public uint InvitacionEntregada { get; set; }
        public byte Confirmacion { get; set; }
        public uint NoAsistiran { get; set; }


        public bool GetInvitado()
        {
            try
            {
                Dictionary<string, object> parameters = new() { { "@IDInvitado", IDInvitado }};
                DataTable dt = db.Reader($"SELECT Invitado, Alias, NumeroRecepciones, NumeroNinios, Confirmacion  FROM Invitados where IDInvitado = @IDInvitado;", parameters);
                Invitado = dt.Rows[0].Field<string>("Invitado");
                Alias = dt.Rows[0].Field<string>("Alias");
                NumeroRecepciones = dt.Rows[0].Field<uint>("NumeroRecepciones");
                NumeroNinios = dt.Rows[0].Field<uint>("NumeroNinios");
                Confirmacion = dt.Rows[0].Field<byte>("Confirmacion");
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public bool AcceptInvitation()
        {
            try
            {
                Dictionary<string, object> parameters = new() { { "@IDInvitado", IDInvitado }, { "@NumeroRecepciones", NumeroRecepciones }, { "@NumeroNinios", NumeroNinios } };
                IDInvitado = db.InsertQuery("UPDATE Invitados SET Confirmacion = 1, NumeroRecepciones = @NumeroRecepciones, NumeroNinios = @NumeroNinios WHERE IDInvitado = @Invitado;", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            if (IDInvitado != -1)
            {
                return true;
            }
            return false;
        }
    }
}
