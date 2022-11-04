using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ONE.Common.Utility
{
    public static class SerializationExtensions
    {
        /// <summary>
        /// Saves to XML using a temporary path
        /// </summary>
        /// <param name="objectToSave">The object to save.</param>
        public static void SaveToXml(this Object objectToSave)
        {
            SaveToXml(objectToSave, String.Format(@"C:\Temp\XML_{0}_{1}.xml", objectToSave.GetType().Name, Guid.NewGuid().ToString("N")));
        }

        /// <summary>
        /// Saves to XML using the specified file path
        /// </summary>
        /// <param name="objectToSave">The object to save.</param>
        /// <param name="filePath">The file path.</param>
        public static void SaveToXml(this Object objectToSave, string filePath)
        {
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(objectToSave.GetType());

            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                writer.Serialize(stream, objectToSave);
            }
        }

        /// <summary>
        /// Converts an object to an XML string
        /// </summary>
        /// <param name="objectToSerialize">The object to serialize.</param>
        /// <returns></returns>
        public static string ToXml(this Object objectToSerialize)
        {
            return objectToSerialize.ToXml(true);
        }

        /// <summary>
        /// Converts an object to an XML string
        /// </summary>
        /// <param name="objectToSerialize">The object to serialize.</param>
        /// <param name="prettyPrint">if set to <c>true</c> [pretty print].</param>
        /// <returns></returns>
        public static string ToXml(this Object objectToSerialize, bool prettyPrint)
        {
            StringWriter writer = new System.IO.StringWriter();
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(objectToSerialize.GetType());
            serializer.Serialize(writer, objectToSerialize);
            string xmlResult = writer.ToString();

            //Determine if we should remove cr/lf/tabs.
            if (prettyPrint)
            {
                return xmlResult;
            }
            else
            {
                return xmlResult.Replace("\r", String.Empty).Replace("\n", String.Empty).Replace("\t", String.Empty);
            }
        }

        /// <summary>
        /// Loads from XML.
        /// </summary>
        /// <typeparam name="TypeToLoad">The type of the ype to load.</typeparam>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        public static TypeToLoad LoadFromXml<TypeToLoad>(string filePath)
        {
            TypeToLoad loadedObject;

            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(TypeToLoad));

            using (FileStream stream = new FileStream(filePath, FileMode.Open))
            {
                loadedObject = (TypeToLoad)serializer.Deserialize(stream);
            }

            return loadedObject;
        }



        /// <summary>
        /// Loads from XML string
        /// </summary>
        /// <typeparam name="TypeToLoad">The type of the ype to load.</typeparam>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        public static TypeToLoad LoadFromXmlString<TypeToLoad>(string xmlString)
        {
            TypeToLoad loadedObject;

            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(TypeToLoad));

            using (TextReader reader = new StringReader(xmlString))
            {
                loadedObject = (TypeToLoad)serializer.Deserialize(reader);
            }

            return loadedObject;
        }

        /// <summary>
        /// Loads from XML string
        /// </summary>
        /// <typeparam name="TypeToLoad">The type of the ype to load.</typeparam>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        public static object LoadFromXmlString(Type typeToLoad, string xmlString)
        {
            object loadedObject;

            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeToLoad);

            using (TextReader reader = new StringReader(xmlString))
            {
                loadedObject = serializer.Deserialize(reader);
            }

            return loadedObject;
        }
    }

}
