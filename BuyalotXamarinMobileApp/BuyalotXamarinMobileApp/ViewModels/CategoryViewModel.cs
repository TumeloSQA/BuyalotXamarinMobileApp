using BuyalotXamarinMobileApp.Models;
using BuyalotXamarinMobileApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BuyalotXamarinMobileApp.ViewModels
{
    public class CategoryViewModel : INotifyPropertyChanged
    {
        private ProductCategory _selectedCategory;

        private List<ProductCategory> _categoryList { get; set; }

        public List<ProductCategory> CategoryList
        {
            get { return _categoryList; }
            set
            {
                _categoryList = value;
                OnPropertyChanged();
            }

        }


        public ProductCategory SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value; 
                OnPropertyChanged();
            }
        }

        public Command PostCommand
        {
            get
            {
                return new Command(async () =>
                {

                    var categoryServices = new CategoryService();
                    await categoryServices.PostCategoryAsync(_selectedCategory);

                });
            }

       
        }

       

        public CategoryViewModel()
        {
            InitializeDataAsync();
        }

        public async Task InitializeDataAsync()
        {
            var categoryServices = new CategoryService();
            CategoryList = await categoryServices.GetCategoriesAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertName = null)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertName));
        }

    }
}
