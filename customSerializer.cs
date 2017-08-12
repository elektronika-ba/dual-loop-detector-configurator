using System;
using System.IO;
using System.Xml.Serialization;

namespace DLDConfig1v1
{
    class customSerializer
    {
        // https://stackoverflow.com/questions/4266875/how-to-quickly-save-load-class-instance-to-file

        public static T Load<T>(string FileSpec)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));

            using (FileStream aFile = new FileStream(FileSpec, FileMode.Open))
            {
                byte[] buffer = new byte[aFile.Length];
                aFile.Read(buffer, 0, (int)aFile.Length);

                using (MemoryStream stream = new MemoryStream(buffer))
                {
                    return (T)formatter.Deserialize(stream);
                }
            }
        }

        public static void Save<T>(string FileSpec, T ToSerialize)
        {
            using (FileStream outFile = File.Create(FileSpec))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(T));
                formatter.Serialize(outFile, ToSerialize);
            }
        }
    }
}
