using System;
using System.IO;
using System.Xml.Serialization;

namespace YpCommonLibrary.Utils
{
    public class XmlSerializerHelper<T>  where T : new() 
    {

        public static void SerializeObjectToXml(string filename, T objectToSerialize)
        {
            TextWriter writer = null;
            try
            {
                writer = new StreamWriter(filename);
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, objectToSerialize);
            }
            catch (Exception)
            {
                //do nothing
            }
            finally
            {
                if (writer !=null)
                {
                    writer.Close();
                }
            }
        }
        public static T DeserializeObjectFromXml(string filename)
        {
            if (!File.Exists(filename))
            {
                return default(T);
            }
            FileStream fs = new FileStream(filename, FileMode.Open);
            // in case anything wrong recreate the file
            bool isNeedDelete    = false;
            T obj;
            try
            {
                
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                obj = (T)serializer.Deserialize(fs);
            }
            catch (Exception)
            {
                isNeedDelete = true;
                obj = default(T);
            }
            finally
            {
                fs.Close();
            }
            if (isNeedDelete)
            {
                File.Delete(filename);
            }
            return obj;
        }
    }
}
