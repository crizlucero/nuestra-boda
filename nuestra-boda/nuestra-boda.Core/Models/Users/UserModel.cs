using nuestra_boda.Core.Helpers;
using nuestra_boda.Core.Models.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace nuestra_boda.Core.Models.Users
{
    public class UserModel
    {
        static readonly DBHelper db = new();

        public long IDUser { get; set; }

        [Required(ErrorMessage = "El correo electrónico no puede estar vacío")]
        [Display(Name = "Correo electrónico")]
        [EmailAddress(ErrorMessage = "El campo no tiene un correo electrónico válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña no puede estar vacía")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password
        {
            get => password; set => password = CypherHelper.Encrypt(value);
        }
        public UserType User_Type { get; set; }

        private string password;

        public bool AddUser()
        {
            try
            {
                Dictionary<string, object> parameters = new() { { "@Email", Email }, { "@Password", password }, { "@User_Type", User_Type } };
                IDUser = db.InsertQuery("INSERT INTO Users (Email, Password, User_Type)", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            if (IDUser != -1)
            {
                return true;
            }
            return false;
        }

        public bool GetUser()
        {
            try
            {
                Dictionary<string, object> parameters = new() { { "@Email", Email }, { "@Password", Password } };
                DataTable dt = db.Reader($"SELECT IDUser FROM Users where Email = @Email and Password = @Password;", parameters);
                IDUser = dt.Rows[0].Field<long>("IDUser");
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }

    public class PersonaModel
    {
        static readonly DBHelper db = new();


        public long IDPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string NombreCompleto { get; set; }
        public UserModel UserModel { get; set; }
        public IList<ContactModel> Contacto { get; set; }
        public IList<EventsModel> Eventos { get; set; }

        public bool AddPersona()
        {
            try
            {
                Dictionary<string, object> parameters = new() { { "@Nombre", Nombre }, { "@Apellidos", Apellidos }, { "@IDUser", UserModel.IDUser } };
                IDPersona = db.InsertQuery("INSERT INTO Personas (Nombre, Apellidos, IDUser)", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            if (IDPersona != -1)
            {
                return true;
            }
            return false;
        }

        public bool GetPersona()
        {
            try
            {
                Dictionary<string, object> parameters = new() { { "@IDUser", UserModel.IDUser } };
                DataTable dt = db.Reader($"SELECT IDPersona, Nombre, Apellidos FROM Personas where IDUser = @IDUser;", parameters);
                IDPersona = dt.Rows[0].Field<long>("IDPersona");
                Nombre = dt.Rows[0].Field<string>("Nombre");
                Apellidos = dt.Rows[0].Field<string>("Apellidos");

                Contacto = IDPersona != 0 ? ContactModel.GetContacts(IDPersona, "Contactos", "IDPersona") : null;

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public bool CreateEvent(long IDEvento)
        {
            try
            {
                Dictionary<string, object> parameters = new() { { "@IDEvento", IDEvento }, { "@IDPersona", IDPersona } };
                IDPersona = db.InsertQuery("INSERT INTO EventosPersonas (IDEvento, IDPersona)", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            if (IDPersona != -1)
            {
                return true;
            }
            return false;
        }
    }

    public enum UserType
    {
        super,
        admin
    }
}
