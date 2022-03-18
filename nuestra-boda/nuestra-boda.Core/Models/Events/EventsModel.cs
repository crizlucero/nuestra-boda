using nuestra_boda.Core.Helpers;
using System;
using System.Collections.Generic;

namespace nuestra_boda.Core.Models.Events
{
    public class EventsModel
    {
        static readonly DBHelper db = new();

        public long IDEvento { get; set; }
        public string EventCode { get => EventCode; set => EventCode = CodeHelper.GenerateCode(); }
        public DateTime Fecha { get; set; }
        public EventType TipoEvento { get; set; }
        public List<MicroEventsModel> MicroEventos { get; set; }

        public bool AddEvent()
        {
            try
            {
                Dictionary<string, object> parameters = new() { { "@EventCode", EventCode }, { "@Fecha", Fecha }, { "@TipoEvento", TipoEvento } };
                IDEvento = db.InsertQuery("INSERT INTO Eventos (EventCode, Fecha)", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            if (IDEvento != -1)
            {
                return true;
            }
            return false;
        }

        public bool GetEvento()
        {
            try
            {
                Dictionary<string, object> parameters = new() { { "@EventCode", EventCode } };
                var reader = db.Reader($"SELECT IDEvento, Fecha, TipoEvento FROM Eventos where EventCode = @EventCode;", parameters);
                if (reader.Read())
                {
                    IDEvento = (long)reader.GetDouble(0);
                    Fecha = reader.GetDateTime(1);
                    TipoEvento = (EventType)Enum.Parse(typeof(EventType), reader.GetString(2));
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public static List<EventsModel> GetEventos(long IDPersona)
        {
            try
            {
                List<EventsModel> Eventos = new();
                Dictionary<string, object> parameters = new() { { "@IDPersona", IDPersona } };
                var reader = db.Reader($"SELECT e.IDEvento, e.Fecha, e.TipoEvento FROM Eventos JOIN EventosPersonas ep ON e.IDEvento = ep.IDEvento where IDPersona = @IDPersona;", parameters);
                while (reader.Read())
                {
                    Eventos.Add(new EventsModel
                    {
                        IDEvento = (long)reader.GetDouble(0),
                        Fecha = reader.GetDateTime(1),
                        TipoEvento = (EventType)Enum.Parse(typeof(EventType), reader.GetString(2))
                    });
                }
                return Eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }

    public enum EventType
    {
        Boda = 0,
        Cumpleaños = 1,
        XV = 2
    }
}
