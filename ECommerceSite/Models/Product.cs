using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceSite.Models
{
    [Bind(Exclude = "ID")]
    public class Product
    {
        //private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();


        [Key]
        [ScaffoldColumn(false)]
        public int ProductId { get; set; }

        [DisplayName("Categorie")]
        public int CategorieId { get; set; }

        [Required(ErrorMessage = "An Product Name is required")]
        [StringLength(160)]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 999.99, ErrorMessage = "Price must be between 0.01 and 999.99")]
        public decimal Price { get; set; }

        public byte[] InternalImage { get; set; }

        [Display(Name = "Local file")]
        [NotMapped]
        public HttpPostedFileBase File
        {
            get
            {
                return null;
            }

            set
            {
                try
                {
                    MemoryStream target = new MemoryStream();

                    if (value.InputStream == null)
                        return;

                    value.InputStream.CopyTo(target);
                    InternalImage = target.ToArray();
                }
                catch (Exception ex)
                {
                    //logger.Error(ex.Message);
                    //logger.Error(ex.StackTrace);
                }
            }
        }

        [DisplayName("Product Picture URL")]
        [StringLength(1024)]
        public string ProductPictureUrl { get; set; }

        public virtual Category Catagorie { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}