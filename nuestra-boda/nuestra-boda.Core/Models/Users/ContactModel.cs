using nuestra_boda.Core.Helpers;
using System;
using System.Collections.Generic;

namespace nuestra_boda.Core.Models.Users
{
    public class ContactModel
    {
        static readonly DBHelper db = new();

        public long IDContacto { get; set; }
        public string Contacto { get; set; }
        public string Tipo { get; set; }

        public bool AddPersona(long ForeignID, string Table, string Column)
        {
            try
            {
                Dictionary<string, object> parameters = new() { { "@Contacto", Contacto }, { "@Tipo", Tipo }, { $"@{Column}", ForeignID } };
                IDContacto = db.InsertQuery($"INSERT INTO {Table} (Contacto, Tipo, {Column})", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            if (IDContacto != -1)
            {
                return true;
            }
            return false;
        }

        public static List<ContactModel> GetContacts(long ForeignID, string Table, string Column)
        {
            try
            {
                List<ContactModel> contacts = new();
                Dictionary<string, object> parameters = new() { { $"@Foreign", ForeignID } };
                var reader = db.Reader($"SELECT IDContacto, Contacto, Tipo FROM {Table} where {Column} = @Foreign;", parameters);
                while (reader.Read())
                {
                    contacts.Add(new ContactModel
                    {
                        IDContacto = (long)reader.GetDouble(0),
                        Contacto = reader.GetString(1),
                        Tipo = reader.GetString(2)
                    });
                }
                return contacts;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
