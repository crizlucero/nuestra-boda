using nuestra_boda.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace nuestra_boda.Core.Models.Events
{
    public class MicroEventsModel
    {
        static readonly DBHelper db = new();

        public long IDMicroevento { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public DateTime Fecha { get; set; }
        public EventsModel Evento { get; set; }


        public bool AddMicroevent()
        {
            try
            {
                Dictionary<string, object> parameters = new() { { "@Latitud", Latitud }, { "@Longitud", Longitud }, { "@Nombre", Nombre }, { "@Tipo", Tipo }, { "@Fecha", Fecha }, { "@IDEvento", Evento.IDEvento } };
                IDMicroevento = db.InsertQuery("INSERT INTO Microeventos (Latitud, Longitud, Nombre, Tipo, Fecha, IDEvento)", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
            if (IDMicroevento != -1)
            {
                return true;
            }
            return false;
        }

        public static IList<MicroEventsModel> GetMicroEventos(string EventCode)
        {
            try
            {
                Dictionary<string, object> parameters = new() { { "@EventCode", EventCode } };
                DataTable dt = db.Reader($"SELECT m.IDMicroevento, m.Latitud, m.Longitud, m.Nombre, m.Tipo, m.Fecha FROM Microeventos m left join Eventos e on e.IDEvento = m.IDEvento where e.EventCode = @EventCode;", parameters);
                IList<MicroEventsModel> microeventos = dt.AsEnumerable().Select(row =>
                    new MicroEventsModel
                    {
                        IDMicroevento = row.Field<long>("IDMicroevento"),
                        Latitud = row.Field<string>("Latitud"),
                        Longitud = row.Field<string>("Longitud"),
                        Nombre = row.Field<string>("Nombre"),
                        Tipo = row.Field<string>("Tipo"),
                        Fecha = row.Field<DateTime>("Fecha")
                    }).ToList();
                return microeventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
