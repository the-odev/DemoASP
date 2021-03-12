using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class GameOfThrone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string language { get; set; }
        public string status { get; set; }
        public int runtime { get; set; }
        public string premiered { get; set; }
        public string officialSite { get; set; }
        public Schedule schedule { get; set; }
        public Rating rating { get; set; }
        public int weight { get; set; }
        public Network network { get; set; }
        public WebChannel webChannel { get; set; }
        public Externals externals { get; set; }
        public Image image { get; set; }
        public string summary { get; set; }
        public int updated { get; set; }
        public Links _links { get; set; }
        public List<Episode> episodes { get; set; }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Schedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string time { get; set; }
    }

    public class Rating
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public double average { get; set; }
    }

    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string timezone { get; set; }
    }

    public class Network
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        public string name { get; set; }
        public Country country { get; set; }
    }

    public class WebChannel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        public string name { get; set; }
        public Country country { get; set; }
    }

    public class Externals
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int tvrage { get; set; }
        public int thetvdb { get; set; }
        public string imdb { get; set; }
    }

    public class Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string medium { get; set; }
        public string original { get; set; }
    }

    public class Self
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string href { get; set; }
    }

    public class Previousepisode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string href { get; set; }
    }

    public class Links
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public Self self { get; set; }
        public Previousepisode previousepisode { get; set; }
    }

    public class Episode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        public int season { get; set; }
        public int number { get; set; }
        public string type { get; set; }
        public string airdate { get; set; }
        public string airtime { get; set; }
        public DateTime airstamp { get; set; }
        public int runtime { get; set; }
        public Image image { get; set; }
        public string summary { get; set; }
        public Links _links { get; set; }
    }



}