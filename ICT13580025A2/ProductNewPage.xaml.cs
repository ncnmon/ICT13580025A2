using System;
using System.Collections.Generic;
using ICT13580025A2.Models;
using Xamarin.Forms;

namespace ICT13580025A2
{
    public partial class ProductNewPage : ContentPage
    {
        Product product;
        public ProductNewPage(Product product=null)
        {
            InitializeComponent();

            this.product = product;
			saveButton.Clicked += SaveButton_Clicked;
			cancelButton.Clicked += CancelButton_Clicked;
			categoryPicker.Items.Add("เสื้อ");
			categoryPicker.Items.Add("กางเกง");
			categoryPicker.Items.Add("ถุงเท้า");

            if(product!=null)
            {
                productNameEntry.Text = product.Name;
                productDetailEntry.Text = product.Description;
                categoryPicker.SelectedItem = product.Category;
                productPriceEntry.Text = product.ProductPrice.ToString();
                sellEntry.Text = product.SellPrice.ToString();
                stockEntry.Text = product.Stock.ToString();

            }
        }
		async void SaveButton_Clicked(object sender, EventArgs e)
		{
			var isOk = await DisplayAlert("ยืนยัน", "คุณต้องการบันทึกใช่หรือไม่", "ใช่", "ไม่");
			if (isOk)
			{
				if (product == null)
				{
					product.Name = productNameEntry.Text;
					product.Description = productDetailEntry.Text;
					product.Category = categoryPicker.SelectedItem.ToString();
					product.ProductPrice = decimal.Parse(productPriceEntry.Text);
					product.SellPrice = decimal.Parse(sellEntry.Text);
					product.Stock = int.Parse(stockEntry.Text);
					var id = App.DbHelper.AddProduct(product);
					await DisplayAlert("บันทึกสำเร็จ", "รหัสสินค้าของท่านคือ" + id, "ตกลง");

				}
				else
				{
					product.Name = productNameEntry.Text;
					product.Description = productDetailEntry.Text;
					product.Category = categoryPicker.SelectedItem.ToString();
					product.ProductPrice = decimal.Parse(productPriceEntry.Text);
					product.SellPrice = decimal.Parse(sellEntry.Text);
					product.Stock = int.Parse(stockEntry.Text);
					var id = App.DbHelper.AddProduct(product);
					await DisplayAlert("บันทึกสำเร็จ", "แก้ไขข้อมูลสินค้าเรียบร้อย" , "ตกลง");
				}
				await Navigation.PopModalAsync();
			}
		}


		void CancelButton_Clicked(object sender, EventArgs e)
		{
			Navigation.PopModalAsync();
		}
    }
}
