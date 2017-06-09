﻿using BuyalotXamarinMobileApp.Models;
using BuyalotXamarinMobileApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BuyalotXamarinMobileApp.ViewModels
{
    public class CategoryViewModel : INotifyPropertyChanged
    {

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