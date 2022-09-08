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
    public class EntityRepository<T> : IEntityRepository<T>
        where T : IEntity
    {
        private string _path;

        public string Path { get; set; }
        /// <summary>
        /// reposory consstructor that speifies the path based 
        /// on the generic type of the repository
        /// </summary>
        public EntityRepository()
        {
            Path = Paths.basePath + typeof(T).Name + Paths.extension;
        }


        /// <summary>
        /// saves the object in a JSON file 
        /// </summary>
        /// <param name="myEntity"></param>
        /// <exception cref="ArgumentException"></exception>
        public virtual void SaveEntity(T myEntity)
        {
            OpenFile();
            List<T> entities = DeserializeJson();
            bool unique = IsEntityUnique(myEntity, entities);

            if (unique == true)
            {
                entities.Add(myEntity);
            }

            else
            {
                throw new ArgumentException(ExceptionMessagesRepositoryMessages.IsNotUnique);
            }

            string fileInfo = SerializeJson(entities);
            File.WriteAllText(Path, fileInfo);
        }


        /// <summary>
        /// finds the object based on the name and replaces it with the new object 
        /// </summary>
        /// <param name="newObject"></param>
        public virtual void Update(T newObject)
        {
            OpenFile();
            List<T> entities = DeserializeJson();
            T oldObject = entities.Find(s => s.Name == newObject.Name);
            entities.Remove(oldObject);
            entities.Add(newObject);
            string fileInfo = SerializeJson(entities);
            File.WriteAllText(Path, fileInfo);
        }

        /// <summary>
        /// finds the ibject based on the provided name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public virtual T FindByName(string name)
        {
            OpenFile();
            List<T> entities = DeserializeJson();
            T result = CheckIfEntityExists(name, entities);

            if (result == null)
            {
                throw new ArgumentException(ExceptionMessagesRepositoryMessages.NotFound);
            }

            return result;
        }

        /// <summary>
        /// removes the object from the JSON file based on the provided name
        /// </summary>
        /// <param name="name"></param>
        public virtual void Delete(string name)
        {
            OpenFile();
            List<T> entities = DeserializeJson();
            T targetEntity = FindByName(name);
            //care with default return type
            foreach (T entity in entities)
            {
                if (targetEntity.Name == entity.Name)
                {
                    entities.Remove(entity);
                    break;
                }
            }
            string fileInfo = SerializeJson(entities);
            File.WriteAllText(Path, fileInfo);
        }

        /// <summary>
        /// retrieves all objects from the JSON in form of a list  
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAll()
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

        private T CheckIfEntityExists(string name, List<T> entities)
        {
            T result = default;
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
