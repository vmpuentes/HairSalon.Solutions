using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      List<Stylist> stylistList = Stylist.GetAll();
      List<Client> stylistClients = Client.GetAll();
      model.Add("stylist", stylistList);
      model.Add("client", stylistClients);

      return View("Index", model);
    }

    [HttpPost("/")]
    public ActionResult IndexPost()
    {

      Stylist newStylist = new Stylist(
      Request.Form["stylistname"],
      int.Parse(Request.Form["stylistfee"]));
      // Stylist newStylistfee = new Stylist("stylistfee");
      newStylist.Save();
      // List<Stylist> allStylists = Stylist.GetAll();
      return View("stylistdetails", Stylist.GetAll());
    }

    [HttpGet("/stylistdetails/{id}")]
    public ActionResult StylistDetails(int id)
    {
      Stylist newStylist = new Stylist(
      Request.Form["stylistName"],
      int.Parse(Request.Form["stylistfee"]));

      return View(newStylist);
    }

     [HttpPost("/stylistdetails/{id}")]
     public ActionResult StylistDetailsPost(int id)
     {
       Client newClient = new Client(Request.Form["newClient"]);

       newClient.Save();

       return View("stylistdetails", Stylist.Find(id));
     }

      [HttpGet("/stylistdetails/{stylistId}/edit/{clientId}")]
     public ActionResult ClientEdit(int stylistId, int clientId)
     {
       Dictionary<string,object> model = new Dictionary<string,object>{};
       Stylist myStylist = Stylist.find(stylistId);
       Client myClient = Client.Find(clientId);

       model.Add("stylist", myStylist);
       model.Add("client", myClient);
       return View(model);
     }

     [HttpPost("/stylistdetails/{stylistId}/newClient/{clientId}")]
     public ActionResult ClientEdited(int stylistId, int clientId)
     {
       Client updatedClient = Client.Find(clientId);
       updatedClient.Update(Request.Form["newClient"]);

       return View("StylistDetails", Stylist.Find(stylistId));
     }

     [HttpPost("/stylistdetails/{stylistId}/deleted/{clientId}")]
     public ActionResult ClientDeleted(int stylistId, int clientId)
     {
       Client deletedClient = Client.Find(clientId);
       deletedClient.Delete();


       return View("stylistdetails", Stylist.Find(stylistId));
     }
   }
 }
