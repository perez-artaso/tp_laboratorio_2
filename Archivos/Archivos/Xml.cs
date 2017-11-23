using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using Excepciones;




namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        public bool guardar(string archivo, T datos)
        {
            bool retValue=false;
            try
            {
                var serializador = new XmlSerializer(typeof(T));
                var xmlWriter = new XmlTextWriter(archivo, Encoding.UTF8);
                serializador.Serialize(xmlWriter, datos);
                xmlWriter.Close();
                retValue = true;
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }

            return retValue;
        }

        public bool leer(string archivo, out T datos)
        {
            bool retValue = false;
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                XmlTextReader reader = new XmlTextReader(archivo);
                datos = (T)serializer.Deserialize(reader);
                reader.Close();
                retValue = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return retValue;
        }
    }
}
