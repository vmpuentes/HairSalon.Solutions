using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;
using System;

namespace HairSalon.Models
{
  public class Stylist
  {
    private int _id;
    private string _firstName;
    private string _lastName;
    private string _

    public Stylist(string Description, int id = 0)
    {
      _id = Id;
      _description = Description;
    }

    //...GETTERS AND SETTERS WILL GO HERE...

        public static List<Stylist> GetAll()
        {
            List<Stylist> allTasks = new List<Stylist> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM stylist;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
              int taskId = rdr.GetInt32(0);
              string taskDescription = rdr.GetString(1);
              Stylist newStylist = new Stylist(taskDescription, taskId);
              allTasks.Add(newTask);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allTasks;
        }
...
  }
}
