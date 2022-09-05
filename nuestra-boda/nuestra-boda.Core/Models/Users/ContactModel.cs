using nuestra_boda.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

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

        public static IList<ContactModel> GetContacts(long ForeignID, string Table, string Column)
        {
            try
            {
                Dictionary<string, object> parameters = new() { { $"@Foreign", ForeignID } };
                DataTable dt = db.Reader($"SELECT IDContacto, Contacto, Tipo FROM {Table} where {Column} = @Foreign;", parameters);
                IList<ContactModel> contacts = dt.AsEnumerable().Select(row =>
                    new ContactModel
                    {
                        IDContacto = row.Field<long>("IDContacto"),
                        Contacto = row.Field<string>("Contacto"),
                        Tipo = row.Field<string>("Tipo")
                    }).ToList();
                return contacts;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
