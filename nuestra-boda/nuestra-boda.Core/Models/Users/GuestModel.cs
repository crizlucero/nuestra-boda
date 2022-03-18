using nuestra_boda.Core.Helpers;
using nuestra_boda.Core.Models.Events;
using System;
using System.Collections.Generic;

namespace nuestra_boda.Core.Models.Users
{
    public class GuestModel
    {
        static readonly DBHelper db = new();


        public long IDInvitado { get => IDInvitado; set => IDInvitado = 0; }
        public string Nombre { get; set; }
        public int NumeroInvitados { get; set; }
        public string Clave { get => Clave; set => Clave = CodeHelper.GenerateCode(4); }
        public bool Estatus { get; set; }
        public UserModel Usuario { get; set; }
        public EventsModel Evento { get; set; }
        public List<ContactModel> Contacto { get => Contacto; set => Contacto = IDInvitado != 0 ? ContactModel.GetContacts(IDInvitado, "ContactoInvitado", "IDInvitado") : null; }

        public bool AddPersona()
        {
            try
            {
                Dictionary<string, object> parameters = new() { { "@Nombre", Nombre }, { "@NumeroInvitados", NumeroInvitados }, { "@Clave", Clave }, { "@IDEvento", Evento.IDEvento }, { "@IDUser", Usuario.IDUser } };
                IDInvitado = db.InsertQuery("INSERT INTO Invitados (Nombre, NumeroInvitados, Clave, IDEvento, IDUser)", parameters);
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

        public bool GetInvitado()
        {
            try
            {
                Dictionary<string, object> parameters = new() { { "@IDInvitado", IDInvitado }, { "@Clave", Clave } };
                var reader = db.Reader($"SELECT IDInvitado, NumeroInvitados, Estatus  FROM Invitados where IDInvitado = @Invitado and Clave = @Clave;", parameters);
                if (reader.Read())
                {
                    IDInvitado = (long)reader.GetDouble(0);
                    NumeroInvitados = reader.GetInt32(1);
                    Estatus = reader.GetBoolean(2);
                }
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
                Dictionary<string, object> parameters = new() { { "@IDInvitado", IDInvitado }, { "@NumeroInvitados", NumeroInvitados }, { "@Clave", Clave }, { "@IDEvento", Evento.IDEvento } };
                IDInvitado = db.InsertQuery("UPDATE Invitados SET Estatus = 1, NumeroInvitados = @NumeroInvitados WHERE IDInvitado = @Invitado and Clave = @Clave and IDEvento = @IDEvento;", parameters);
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
