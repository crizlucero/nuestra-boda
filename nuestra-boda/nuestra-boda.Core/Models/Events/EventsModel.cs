using nuestra_boda.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace nuestra_boda.Core.Models.Events
{
    public class EventsModel
    {
        static readonly DBHelper db = new();

        public uint IDEvento { get; set; }
        public string EventCode { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoEvento { get; set; }
        //public List<MicroEventsModel> MicroEventos { get; set; }

        public bool AddEvent()
        {
            int idevento;
            try
            {
                Dictionary<string, object> parameters = new() { { "@EventCode", EventCode }, { "@Fecha", Fecha }, { "@TipoEvento", TipoEvento } };
                idevento = (int)db.InsertQuery("INSERT INTO Eventos (EventCode, Fecha)", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            
            if (idevento != -1)
            {
                IDEvento = (uint)idevento;
                return true;
            }
            return false;
        }

        public bool GetEvento()
        {
            try
            {
                Dictionary<string, object> parameters = new() { { "@EventCode", EventCode } };
                DataTable dt = db.Reader($"SELECT IDEvento, Fecha, TipoEvento FROM Eventos where EventCode = @EventCode;", parameters);
                IDEvento = dt.Rows[0].Field<uint>("IDEvento");
                TipoEvento = dt.Rows[0].Field<string>("TipoEvento");
                Fecha = dt.Rows[0].Field<DateTime>("Fecha");
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public static IList<EventsModel> GetEventos(long IDPersona)
        {
            try
            {
                Dictionary<string, object> parameters = new() { { "@IDPersona", IDPersona } };
                DataTable dt = db.Reader($"SELECT e.IDEvento, e.Fecha, e.TipoEvento FROM Eventos JOIN EventosPersonas ep ON e.IDEvento = ep.IDEvento where IDPersona = @IDPersona;", parameters);
                IList<EventsModel> Eventos = dt.AsEnumerable().Select(row =>
                new EventsModel
                {
                    IDEvento = row.Field<uint>("IDEvento"),
                    TipoEvento = row.Field<string>("TipoEvento"),
                    Fecha = row.Field<DateTime>("Fecha")
                }).ToList();
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
