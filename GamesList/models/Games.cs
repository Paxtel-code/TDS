namespace Games.API.Model
{
    public class Games{
        public int Id {get;set;}
        public string? Name {get;set;}
        public string? Genre {get;set;}
        public double? Price {get;set;}
        public int? Amount {get;set;}
        public bool Wish {get;set;} = false;
    }
}