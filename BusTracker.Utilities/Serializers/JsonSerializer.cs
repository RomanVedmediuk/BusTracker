namespace BusTracker.Utilities.Serializers
{
    using System.IO;
    using System.Runtime.Serialization.Json;
    using System.Text;

    public class JsonSerializer: IDataContractSerializer
    {
        public string Serialize<TEntity>(TEntity entity)
            where TEntity : class, new()
        {
            using (var ms = new MemoryStream())
            {
                var ser = new DataContractJsonSerializer(typeof(TEntity));
                ser.WriteObject(ms, entity);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }

        public TEntity Deserialize<TEntity>(string entity)
            where TEntity : class, new()
        {
            var ser = new DataContractJsonSerializer(typeof(TEntity));
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(entity)))
            {
                return ser.ReadObject(stream) as TEntity;
            }
        }
    }
}