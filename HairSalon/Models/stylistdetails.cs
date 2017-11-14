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
      Stylist newStylist = new Stylist(StylistName, StylistFee);
      allStylists.Add(newStylist);
    }

    conn.Close();
    if (conn != null)
    {
      conn.Dispose();
    }
    return allStylists;
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

  public void Save()
  {
    MySqlConnection conn = DB.Connection();
    conn.Open();

    var cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = @"INSERT INTO `stylist` ('stylist_id',`stylist_name`,'stylist_fee') VALUES (@stylistid, @stylistName, @stylistfee);";

    MySqlParameter name = new MySqlParameter();
    name.ParameterName = "@stylist_name";
    name.Value = this._name;
    cmd.Parameters.Add(name);

    MySqlParameter fee = new MySqlParameter();
    fee.ParameterName = "@stylist_fee";
    fee.Value = this._fee;
    cmd.Parameters.Add(fee);

    conn.Close();
    if (conn != null)
    {
      conn.Dispose();
    }
    return allStylists;
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
  }
}
