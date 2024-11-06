using glasluisaS5.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace glasluisaS5.Utils
{
    public class PersonRepository
    {
        string dbPath;
        private SQLiteConnection conn;
        public string Status { get; set; }

        public PersonRepository(string path)
        {
            dbPath = path;
        }

        public void Init()
        {
            if (conn is not null)
                return;

            conn = new SQLiteConnection(dbPath);
            conn.CreateTable<Persona>();
        }

        public void AddNewPerson(string name)
        {
            try
            {
                Init();
                if (string.IsNullOrEmpty(name))
                    throw new Exception("El nombre es requerido");

                Persona person = new Persona() { Name = name };
                conn.Insert(person);
                Status = "Dato Ingresado";
            }
            catch (Exception)
            {
                Status = "Error al Ingresar";
            }
        }

        public List<Persona> GetAllPeople()
        {
            try
            {
                Init();
                return conn.Table<Persona>().ToList();
            }
            catch (Exception)
            {
                Status = "Error al listar";
                return new List<Persona>();
            }
        }

        public void DeletePerson(int id)
        {
            try
            {
                Init();
                conn.Delete<Persona>(id);
                Status = "Persona eliminada";
            }
            catch (Exception)
            {
                Status = "Error al eliminar";
            }
        }

        public void UpdatePerson(Persona person)
        {
            try
            {
                Init();
                conn.Update(person);
                Status = "Persona actualizada";
            }
            catch (Exception)
            {
                Status = "Error al actualizar";
            }
        }
    }
}
