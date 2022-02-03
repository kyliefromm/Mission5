using System;
using System.ComponentModel.DataAnnotations;

namespace MovieCollection.Models
{
    public class MovieForm
    {
        [Key]
        [Required]
        public int MovieID { get; set; }
        [Required(ErrorMessage = "Title is Required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Year is Required")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Director is Required")]
        public string Director { get; set; }
        [Required(ErrorMessage = "Rating is Required")]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string Lent { get; set; }
        [StringLength(25)]
        public string Notes { get; set; }



        public int CategoryId { get; set; }
        public Category Category { get; set; }

       
    }
 }
