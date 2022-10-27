namespace Owner.API.Model;
using System;


public class Owner{

    public int Id{set; get;}
    
    public string Name{set; get;}

    public string Surname{set; get;}

    public DateTime Date { get; set; }

    public string Comment  {get; set;}

    public string Type {get; set;}

}