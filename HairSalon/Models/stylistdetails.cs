using System.Collections.Generic;
using MySql.Data.MySqlClient;
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

  public string GetName()
  {
    return _name;
  }

  public int GetFee()
  {
    return _fee;
  }
  public static Stylist Find(int id)
  {
    MySqlConnection conn = DB.Connection();
    conn.Open();
    var cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = @"SELECT * FROM `stylists` WHERE id = @thisId ORDER BY id DESC;";

    MySqlParameter searchId = new MySqlParameter();
    searchId.ParameterName = "@thisId";
    searchId.Value = id;
    cmd.Parameters.Add(searchId);

    var rdr = cmd.ExecuteReader() as MySqlDataReader;

    int stylistId = 0;
    string stylistName = "";
    int stylistFee = 0;

    while (rdr.Read())
    {
      stylistId = rdr.GetInt32(0);
      stylistName = rdr.GetString(1);
      stylistFee = rdr.GetInt32(2);
    }

    Stylist newStylist = new Stylist(stylistName, stylistFee, stylistId);
    conn.Close();
    if (conn != null)
    {
      conn.Dispose();
    }
    return newStylist;
  }


  public static List<Stylist> GetAll()
  {
    List<Stylist> allStylists = new List<Stylist> {};
    MySqlConnection conn = DB.Connection();
    conn.Open();
    MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = @"SELECT * FROM stylists ORDER BY name ASC;";
    MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
    while(rdr.Read())
    {
      int StylistId = rdr.GetInt32(0);
      string StylistName = rdr.GetString(1);
      int StylistFee = rdr.GetInt32 (2);
      Stylist newStylist = new Stylist(StylistName, StylistFee, StylistId);
      allStylists.Add(newStylist);
    }

    conn.Close();
    if (conn != null)
    {
      conn.Dispose();
    }
    return allStylists;
   }

   public List<Client> SearchAllClients()
   {
     return Client.GetAllForStylist(this._id);
   }

    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM stylists;";
      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
}
  public void Save()
  {
    MySqlConnection conn = DB.Connection();
    conn.Open();

    var cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = @"INSERT INTO stylists (name, fee) VALUES (@stylist_name, @stylist_fee);";

    MySqlParameter name = new MySqlParameter();
    name.ParameterName = "@stylist_name";
    name.Value = this._name;
    cmd.Parameters.Add(name);

    MySqlParameter fee = new MySqlParameter();
    fee.ParameterName = "@stylist_fee";
    fee.Value = this._fee;
    cmd.Parameters.Add(fee);

    cmd.ExecuteNonQuery();

    var cmdGetNewId = conn.CreateCommand() as MySqlCommand;
    cmdGetNewId.CommandText = @"SELECT LAST_INSERT_ID();";
    
    _id = (int) cmd.LastInsertedId;
    // UInt64 newId = (UInt64) cmdGetNewId.ExecuteScalar();
    this._id = (int)newId;

    conn.Close();
    if (conn != null)
    {
      conn.Dispose();
    }
    }
  }
}
