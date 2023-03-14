namespace APIs.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        //even if we user UserName typing here, our .net api will return camel case convension here
        //like userName in json response thats why we use .userNmae in html page


    }
}
