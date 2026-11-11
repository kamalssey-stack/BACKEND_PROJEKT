using System.Collections.Generic;
using BACKEND_PROJEKT.Models;

namespace BACKEND_PROJEKT.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; } = new();
        public List<ServiceFeature> ServiceFeatures { get; set; } = new();
        public List<Product> Products { get; set; } = new();
    }
}
