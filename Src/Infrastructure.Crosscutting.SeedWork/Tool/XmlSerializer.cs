using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Infrastructure.Crosscutting.SeedWork.Tool
{
    /// <summary>
    /// XML序列化
    /// XML与Object相互转换
    /// </summary>
    public static class XmlSerializers
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <param name="array"></param>
        public static void Serialize<T>(string filePath, T[] array) where T : new()
        {
            if (string.IsNullOrEmpty(filePath) ||
                array == null || array.Length == 0)
            {
                return;
            }

            try
            {
                XmlSerializerFactory xmlSerializerFactory = new XmlSerializerFactory();
                XmlSerializer xmlSerializer =
                    xmlSerializerFactory.CreateSerializer(array.GetType(), typeof(T).Name);
                Stream stream = new FileStream(filePath, FileMode.Create);
                xmlSerializer.Serialize(stream, array);
                stream.Close();
            }
            catch
            {
            }
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="obj"></param>
        public static void Serialize(string filePath, object obj)
        {
            if (string.IsNullOrEmpty(filePath) || obj == null)
            {
                return;
            }

            try
            {
                XmlSerializerFactory xmlSerializerFactory = new XmlSerializerFactory();
                XmlSerializer xmlSerializer =
                    xmlSerializerFactory.CreateSerializer(obj.GetType(), obj.GetType().Name);
                Stream stream = new FileStream(filePath, FileMode.Create);
                xmlSerializer.Serialize(stream, obj);
                stream.Close();
            }
            catch
            {
            }
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="filePath">路径</param>
        /// <returns></returns>
        public static List<T> Deserialize<T>(string filePath) where T : new()
        {
            List<T> results = new List<T>();
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                return results;
            }
            object obj = null;
            try
            {
                XmlSerializerFactory xmlSerializerFactory = new XmlSerializerFactory();
                XmlSerializer xmlSerializer =
                    xmlSerializerFactory.CreateSerializer(typeof(T[]), typeof(T).Name);
                Stream stream = new FileStream(filePath, System.IO.FileMode.Open);
                obj = xmlSerializer.Deserialize(stream);
                stream.Close();

                results.AddRange(obj as T[]);
            }
            catch
            {
            }

            return results;
        }


        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="filePath">路径</param>
        /// <param name="targetType">类型</param>
        /// <returns></returns>
        public static object Deserialize(string filePath, Type targetType)
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath)
                || targetType == null)
            {
                return null;
            }

            object obj = null;
            try
            {
                XmlSerializerFactory xmlSerializerFactory = new XmlSerializerFactory();
                XmlSerializer xmlSerializer =
                    xmlSerializerFactory.CreateSerializer(targetType, targetType.Name);
                Stream stream = new FileStream(filePath, FileMode.Open);
                obj = xmlSerializer.Deserialize(stream);
                stream.Close();
            }
            catch
            {
            }

            return obj;
        }
    }
}
