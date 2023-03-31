using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductFinder.Entities
{
	public class Category
	{
	    [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CategoryId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

		public List<Product> Product { get; set; }
	}
}

