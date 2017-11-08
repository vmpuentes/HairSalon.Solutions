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
      return View(Stylist.GetAll());
    }

    [HttpPost("/")]
    public ActionResult IndexPost()
    {
      string stylistFirstName = Request.Form["stylistFirstName"];
      string stylistLastName = Request.Form["stylistLastName"];
      Stylist newStylist = new Stylist(stylistFirstName, stylistLastName);
      newStylist.Save();
      List<Stylist> allStylists = Stylist.GetAll();
      return View("/", allStylists);
    }

    [HttpGet("/stylistdetails/{id}")]
    public ActionResult StylistDetails(int id)
    {
      Stylist newStylist = Stylist.Find(id);

      return View(newStylist);
    }

    [HttpPost("/stylistdetails/{id}")]
    public ActionResult StylistDetailsPost(int id)
    {
      Client newClient = new Client(Request.Form["clientName"], id);

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

    [HttpPost("/stylistdetails/{stylistId}/client-edited/{clientId}")]
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
