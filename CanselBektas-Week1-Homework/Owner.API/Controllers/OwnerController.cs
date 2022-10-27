using Microsoft.AspNetCore.Mvc;
namespace Owner.API.Controllers;
using Owner.API.Model;


[ApiController]
[Route("[controller]s")]

public class OwnerController: ControllerBase{

   public static List<Owner> Owners=new List<Owner>(){
               new Owner{
                Id=1,
                Name="cansu",
                Surname="turan",
                Date=new DateTime(2017,05,04),
                Comment="cansu turan",
                Type="owner"

               },

                 new Owner{
                Id=8,
                Name="turna",
                Surname="turan",
                Date=new DateTime(2022,11,10),
                Comment="turna turan",
                Type="owner"
               },

               
                 new Owner{
                Id=5,
                Name="canan",
                Surname="bektas",
                Date=new DateTime(1990,11,04),
                Comment="canan bektas",
                Type="owner"
                 }

   };


   [HttpGet]
   [Route("All")]
   public List<Owner> Get(){
 
    var owners=Owners.OrderBy(x=>x.Id).ToList();
    return owners;

   }





   [HttpDelete]
   [Route("Delete")]
   public IActionResult DeleteOwner(int id){
     var owner=Owners.SingleOrDefault(x=>x.Id==id);
     if(owner is null)
       return NotFound("searched ID not found");
    
      Owners.Remove(owner);
      return Ok("Deleted");
   }




   [HttpPut]
   [Route("Update")]
   public IActionResult UpdateOwner(int id,[FromBody] Owner updateOwner){
      
      var owner=Owners.SingleOrDefault(x=>x.Id==id);
      if(owner is null)
        return NotFound("searched ID not found");
     
     owner.Id=updateOwner.Id != default ? updateOwner.Id : owner.Id;
     owner.Name=updateOwner.Name != default ? updateOwner.Name : owner.Name;
     owner.Surname=updateOwner.Surname != default ? updateOwner.Surname : owner.Surname;
     owner.Comment=updateOwner.Comment != default ? updateOwner.Comment : owner.Comment;
     owner.Type=updateOwner.Type != default ? updateOwner.Type : owner.Type;

     return Ok("Updated");
   }






    [HttpPost]
    [Route("Create")]
     public  IActionResult AddOwner([FromBody] Owner newOwner)
    {
        
        var owner= Owners.SingleOrDefault(x=>x.Id==newOwner.Id);
        if(owner != null)
          return BadRequest("WRONG!!! exist Id");

        if (newOwner.Comment.Contains("hack"))
                return BadRequest("no \"hack\"");


        Owners.Add(newOwner);
        return Ok("Created");

    }



   }






