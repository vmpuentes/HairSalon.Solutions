using System.Collections.Generic;
using MySql.Data.MySqlClient;
// using HairSalon;
using System;

namespace HairSalon.Models
{
  public class Stylist
  {
    private int _id;
    private string _name;
    private int _fee;

    public Stylist(string name, int fee, int id = 0)
    {
      _id = id;
      _name = name;
      _fee = fee;
    }

    public int GetId()
    {
      return _id;
    }

    public string name()
    {
      return _name;
    }

    public int GetFee()
    {
      return _fee;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO `stylist` ('stylist_id',`first_name`,'last_name') VALUES (@stylistFirstName, @stylistLastName);";

      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@stylist_id";
      name.Value = this.stylist_id;
      cmd.Parameters.Add(name);

      ySqlParameter name = new MySqlParameter();
      name.ParameterName = "@stylistFirstName";
      stylistFirstName.Value = this.stylistFirstName;
      cmd.Parameters.Add(name);

      ySqlParameter name = new MySqlParameter();
      name.ParameterName = "@stylistLastName";
      stylistLastName.Value = this.stylistLastName;
      cmd.Parameters.Add(name);

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
    public static List<Stylist> GetAll()
    {
      List<Stylist> allStylists = new List<Stylist> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM stylists ORDER BY first_name ASC;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int StylistId = rdr.GetInt32(0);
        string StylistFirstName = rdr.GetString(1);
        string StylistLastName = rdr.GetString (2);
        Stylist newStylist = new Stylist(StylistFirstName, StylistLastName, StylistId);
        allStylists.Add(newStylist);
      }

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allStylists;
    }
  }
}
