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
    private string _clientid;

    public Stylist(string firstName, string lastName, int id = 0)
    {
      _id = id;
      _firstName = firstName;
      _lastName = lastName;

    }

    //...GETTERS AND SETTERS WILL GO HERE...

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
