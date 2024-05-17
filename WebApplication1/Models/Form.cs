using Newtonsoft.Json;

namespace WebApplication1.Models
{
    public class Form
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }


        [JsonProperty(PropertyName = "firstname")]
        public string FName { get; set; }


        [JsonProperty(PropertyName = "lastname")]
        public string LName { get; set; }



        [JsonProperty(PropertyName = "email")]

        public string Email { get; set; }


        [JsonProperty(PropertyName = "phone")]

        public Setstatus Phone { get; set; }



        [JsonProperty(PropertyName = "nationality")]

        public Setstatus Nationality { get; set; }



        [JsonProperty(PropertyName = "residence")]

        public Setstatus Residence { get; set; }


        [JsonProperty(PropertyName = "Idnumber")]

        public Setstatus IdNumber { get; set; }


        [JsonProperty(PropertyName = "dob")]

        public Setstatus DOB { get; set; }


        [JsonProperty(PropertyName = "gender")]

        public Setstatus Gender { get; set; }


    }

    public class Setstatus
    {
        [JsonProperty(PropertyName = "isInternal")]
        public bool IsInternal { get; set; } = false;

        [JsonProperty(PropertyName = "isHide")]
        public bool IsHide { get; set; } = false;
    }
}
