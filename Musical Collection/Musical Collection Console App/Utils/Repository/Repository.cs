using Musical_Collection_Console_App.Classes;
using Musical_Collection_Console_App.Constants;
using Musical_Collection_Console_App.Interfaces.File_System_Interfaces;
using Musical_Collection_Console_App.Utils.Exception_Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musical_Collection_Console_App.Utils.Repository
{
    internal class Repository<T> : IRepository<T>
        where T : IEntity
    {
        private string path;
        public string Path { get; set; }
        public Repository()
        {
            //fix path
            Path = Paths.basePath + typeof(T).Name + Paths.extension;
        }

        public void Save(T myEntity)
        {
            OpenFile();
            List<T> entities = DeserializeJson();
            bool unique = IsEntityUnique(myEntity, entities);
            if (unique == true)
            {
                entities.Append(myEntity);
            }
            else
            {
                throw new Exception(ExceptionMessages.IsNotUnique);
            }
            string fileInfo = SerializeJson(entities);
            File.WriteAllText(Path, fileInfo);
        }

        public void Update(T newObject)
        {
            OpenFile();
            List<T> entities = DeserializeJson();
            T oldObject = entities.Find(s => s.Name == newObject.Name);
            entities.Remove(oldObject);
            entities.Add(newObject);
            string fileInfo = SerializeJson(entities);
            File.WriteAllText(Path, fileInfo);
        }

        public T FindTByName(string name)
        {
            OpenFile();
            List<T> entities = DeserializeJson();
            T result = checkIfEntityExists(name, entities);
            return result;
        }

        public void Delete(string name)
        {
            OpenFile();
            List<T> entities = DeserializeJson();
            T targetEntity = FindTByName(name);
            //care with default return type
            foreach (T entity in entities)
            {
                if (targetEntity.Name == entity.Name)
                {
                    entities.Remove(entity);
                }
            }
            string fileInfo = SerializeJson(entities);
            File.WriteAllText(Path, fileInfo);
        }

        public List<T> GetAll()
        {
            OpenFile();
            List<T> entities = DeserializeJson();
            return entities;
        }

        private void OpenFile()
        {
            if (!File.Exists(Path))
            {
                CreateFile();
            }
        }

        private void CreateFile()
        {
            FileStream fileStream = File.Create(Path);
            fileStream.Close();
        }
        private List<T> DeserializeJson()
        {
            List<T> entities = null;
            string jsonString = File.ReadAllText(Path);
            if (!string.IsNullOrWhiteSpace(jsonString))
            {
                entities = JsonConvert.DeserializeObject<List<T>>(jsonString);
            }
            else
            {
                entities = new List<T>();
            }
            return entities;
        }
        private bool IsEntityUnique(T myEntity, List<T> entities)
        {
            bool result = true;
            foreach (T currentEntity in entities)
            {
                if (myEntity.Name == currentEntity.Name)
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        private string SerializeJson(List<T> entities)
        {
            return JsonConvert.SerializeObject(entities, Formatting.Indented);
        }

        private T checkIfEntityExists(string name, List<T> entities)
        {
            T result = default(T);
            foreach (T enitity in entities)
            {
                if (name == enitity.Name)
                {
                    result = enitity;
                    break;
                }
            }
            return result;
        }
    }
}
